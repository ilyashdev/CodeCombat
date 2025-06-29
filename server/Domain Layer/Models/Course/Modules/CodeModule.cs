using System.Text.Json.Nodes;

namespace CodeCombat.Domain_Layer.Models.Course.Modules;

public class CodeModule : Module
{    
    public string? Problem { get; set; }
    public ICollection<string>? Inputs  { get; set; }
    public ICollection<string>? Outputs  { get; set; }
    public override Result GetResult(JsonObject obj)
    {
        throw new Exception("no need result");
    }
}