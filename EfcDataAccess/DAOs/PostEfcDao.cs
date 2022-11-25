using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        var added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        var query = context.Posts.Include(post => post.Author).AsQueryable();

        if (!string.IsNullOrEmpty(searchParameters.Username))
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.Author.UserName.ToLower().Equals(searchParameters.Username.ToLower()));

        if (searchParameters.UserId != null) query = query.Where(t => t.Author.Id == searchParameters.UserId);

        if (searchParameters.PostedStatus != null)
            query = query.Where(t => t.IsPosted == searchParameters.PostedStatus);

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));

        var result = await query.ToListAsync();
        return result;
    }

    public async Task UpdateAsync(Post post)
    {
        context.Posts.Update(post);
        await context.SaveChangesAsync();
    }

    public async Task<Post?> GetByIdAsync(int postId)
    {
        var found = await context.Posts
            .AsNoTracking()
            .Include(post => post.Author)
            .SingleOrDefaultAsync(post => post.Id == postId);
        return found;
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await GetByIdAsync(id);
        if (existing == null) throw new Exception($"Todo with id {id} not found");

        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }
}