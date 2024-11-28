namespace CodeCombat.Domain_Layer.Models.Course.Modules;

public class TextModule : Module
{
    public TextModule(string name, string type, string text) : base(name, type)
    {
        Text = text;
    }

    public string Text { get; set; }
}