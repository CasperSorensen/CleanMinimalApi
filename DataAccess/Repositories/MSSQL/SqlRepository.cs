using System.Reflection;
using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class SqlRespository(SocialDbContext ctx) : IStorage
{
  private readonly SocialDbContext _ctx = ctx;

  public async Task<Post> CreatePost(Post newPost)
  {
    newPost.DateCreated = DateTime.Now;
    newPost.LastModified = DateTime.Now;

    _ctx.Posts.Add(newPost);

    await _ctx.SaveChangesAsync();

    return newPost;
  }

  public async Task DeletePost(int postid)
  {
    var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postid);

    if (post == null) return;

    _ctx.Posts.Remove(post);

    await _ctx.SaveChangesAsync();
  }

  public async Task<ICollection<Post>> GetAllPosts()
  {
    return await _ctx.Posts.ToListAsync();
  }

  public async Task<Post> GetPostById(int postid)
  {
    return await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postid);
  }

  public async Task<Post> UpdatePost(string updatedContent, int postid)
  {
    var postresult = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postid);

    postresult.LastModified = DateTime.Now;
    postresult.Content = updatedContent;
    await _ctx.SaveChangesAsync();

    return postresult;
  }
}