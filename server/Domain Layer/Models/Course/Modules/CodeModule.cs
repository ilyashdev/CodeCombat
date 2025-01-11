using Newtonsoft.Json.Linq;

namespace CodeCombat.Domain_Layer.Models.Course.Modules;

public class CodeModule : Module
{    
    public string? Problem { get; set; }
    public ICollection<string>? Inputs  { get; set; }
    public ICollection<string>? Outputs  { get; set; }
    public override Result GetResult(JObject obj)
    {
        throw new Exception("no need result");
    }
}