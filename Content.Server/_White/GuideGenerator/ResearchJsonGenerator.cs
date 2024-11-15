using Robust.Shared.Prototypes;
using System.IO;
using System.Linq;
using System.Text.Json;
using Content.Shared.Research.Prototypes;

namespace Content.Server._White.GuideGenerator;

public static class ResearchJsonGenerator
{
    public static void PublishJson(StreamWriter file)
    {
        var prototype = IoCManager.Resolve<IPrototypeManager>();
        var prototypes =
            prototype
                .EnumeratePrototypes<TechnologyPrototype>()
                .Where(x => !x.Hidden)
                .Select(x => new ResearchEntry(x))
                .ToDictionary(x => x.Id, x => x);

        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        file.Write(JsonSerializer.Serialize(prototypes, serializeOptions));
    }
}
