using CodeCombat.Domain_Layer.Models.Course.Modules;

namespace CodeCombat.Domain_Layer.Models.Course;

public class Course : Content
{
    public Course(Guid id, User? creator, string? contentType, DateTime publicTime, ICollection<string>? tags,
        string? name, int up, int down, int inFavoriteUser, ICollection<Comment>? comments,
        ICollection<Module> modules) : base(id, creator, contentType, publicTime, tags, name, up, down, inFavoriteUser,
        comments)
    {
        Modules = modules;
    }

    public ICollection<Module> Modules { get; set; }
}