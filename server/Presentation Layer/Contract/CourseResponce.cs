namespace CodeCombat.Contracts;
public record CourseResponce
(
    string Username,
    string Title,
    string Desc,
    int Like,
    int Dislike, 
    DateTime PublicTime,
    List<string> Tags,
    List<Module> Modules
);