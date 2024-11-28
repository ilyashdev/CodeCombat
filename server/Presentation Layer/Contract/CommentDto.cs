namespace CodeCombat.Contract;
public record CommentDto(Guid Id,UserDto Creator,string Text, DateTime PublicTime,ICollection<CommentDto>? Subcomment);