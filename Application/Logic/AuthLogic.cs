﻿using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class AuthLogic : IAuthLogic
{
    private readonly IUserDao _userDao;

    public AuthLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public async Task<User> ValidateUserAsync(string username, string password)
    {
        var existingUser = await _userDao.GetByUsernameAsync(username);
        if (existingUser == null) throw new Exception("User not found");

        if (!existingUser.Password.Equals(password)) throw new Exception("Password mismatch");

        return existingUser;
    }

    public async Task<User> RegisterUserAsync(UserCreationDto dto)
    {
        var existing = await _userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        var toCreate = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Password = dto.Password
        };

        var created = await _userDao.CreateAsync(toCreate);

        return created;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var existingUser = await _userDao.GetByIdAsync(id);
        if (existingUser == null) throw new Exception("User not found");

        return existingUser;
    }


    private static void ValidateData(UserCreationDto userToCreate)
    {
        var userName = userToCreate.UserName;

        if (string.IsNullOrEmpty(userToCreate.UserName))
            throw new ValidationException("Username cannot be null");

        if (string.IsNullOrEmpty(userToCreate.Password))
            throw new ValidationException("Password cannot be null");

        //TODO: More validation
        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters long");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters long");
    }
}