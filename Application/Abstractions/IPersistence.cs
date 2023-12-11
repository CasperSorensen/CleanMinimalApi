using Domain.Models;

namespace Application.Abstractions;

public interface IStorage
{
  Task<ICollection<Post>> GetAllPosts();
  Task<Post> GetPostById(int postid);
  Task<Post> CreatePost(Post postToCreate);
  Task<Post> UpdatePost(string updatedContent, int postid);
  Task DeletePost(int postid);
}
