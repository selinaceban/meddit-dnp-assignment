﻿using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.AuthorId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.AuthorId} was not found.");
        }

        Post post = new Post(user, dto.Title);

        ValidatePost(post);

        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    public async Task UpdateAsync(PostUpdateDto dto)
    {
        Post? existing = await postDao.GetByIdAsync(dto.Id);

        if (existing == null)
        {
            throw new Exception($"Post with ID {dto.Id} not found!");
        }

        User? user = null;
        if (dto.AuthorId != null)
        {
            user = await userDao.GetByIdAsync((int)dto.AuthorId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.AuthorId} was not found.");
            }
        }

        if (dto.IsPosted != null && existing.IsPosted && !(bool)dto.IsPosted)
        {
            throw new Exception("Cannot un-complete a completed Post");
        }

        User userToUse = user ?? existing.Author;
        string titleToUse = dto.Title ?? existing.Title;
        bool completedToUse = dto.IsPosted ?? existing.IsPosted;
        
        Post updated = new (userToUse, titleToUse)
        {
            IsPosted = completedToUse,
            Id = existing.Id,
        };

        ValidatePost(updated);

        await postDao.UpdateAsync(updated);
    }

    public async Task DeleteAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with ID {id} was not found!");
        }

        if (!post.IsPosted)
        {
            throw new Exception("Cannot delete un-completed Post!");
        }

        await postDao.DeleteAsync(id);
    }

    public async Task<PostBasicDto> GetByIdAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        return new PostBasicDto(post.Id, post.Author.UserName, post.Title, post.IsPosted);
    }

    private void ValidatePost(Post dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }
}