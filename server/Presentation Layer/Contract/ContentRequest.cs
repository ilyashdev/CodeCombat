using System.Runtime.InteropServices.JavaScript;

namespace CodeCombat.Presentation_Layer.Contract;
public record ContentRequest
(
    string ContentType,
    ICollection<string>? Tags,
    string Name,
    string Description
);