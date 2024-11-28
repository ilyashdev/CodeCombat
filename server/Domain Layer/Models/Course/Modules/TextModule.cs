namespace CodeCombat.Model;
public class TextModule : Module
{
    public TextModule(string name, string type, string text) : base(name, type)
    {
        Text = text;
    }

    string Text {get;set;}
    
}