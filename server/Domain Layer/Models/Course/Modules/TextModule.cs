namespace CodeCombat.Domain_Layer.Models.Course.Modules;

public class TextModule : Module
{    
    public string? Text { get; set; }

    public override Result GetResult()
    {
        throw new Exception("no need result");
    }
}