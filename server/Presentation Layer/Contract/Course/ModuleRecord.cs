using Newtonsoft.Json.Linq;

namespace CodeCombat.Presentation_Layer.Contract.Course;

public record ModuleRecord(string Name, string Type, JObject Data);