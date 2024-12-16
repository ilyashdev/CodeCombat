using System.Text.Json.Nodes;

namespace CodeCombat.Presentation_Layer.Contract;
public record ModuleRequest
(
    string ModuleType,
    string Name,
    JsonObject Data
);