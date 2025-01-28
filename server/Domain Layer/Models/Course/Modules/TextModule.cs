using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace CodeCombat.Domain_Layer.Models.Course.Modules;

public class TextModule : Module
{    
    public string? Text { get; set; }

    public override Result GetResult(JsonObject obj)
    {
        throw new Exception("no need result");
    }
}