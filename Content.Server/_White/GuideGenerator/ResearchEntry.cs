using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Robust.Shared.Prototypes;

namespace Content.Server._White.GuideGenerator;

public sealed class ResearchEntry
{
    [JsonPropertyName("id")]
    public string Id { get; }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("tier")]
    public int Tier { get; }

    [JsonPropertyName("cost")]
    public int Cost { get; }

    [JsonPropertyName("discipline")]
    public string Discipline { get; }

    [JsonPropertyName("recipeUnlocks")]
    public List<string> RecipeUnlocks { get; }

    public ResearchEntry(Shared.Research.Prototypes.TechnologyPrototype proto)
    {
        Id = proto.ID;
        Name = proto.Name;
        Tier = proto.Tier;
        Cost = proto.Cost;
        Discipline = proto.Discipline.Id;
        RecipeUnlocks = proto.RecipeUnlocks.Select(x => x.Id).ToList();
    }
}
