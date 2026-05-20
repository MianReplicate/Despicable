using Despicable.Core.Compatibility;
using Despicable.NSFW.Integrations;

namespace Despicable.NSFW.Integrations.SimpleTrans;
/// <summary>
/// Lightweight status module for Gender Works integration.
/// There is no eager patch work today, but standardizing the shape keeps startup predictable.
/// </summary>
internal sealed class SimpleTransCompatModule : IModCompat
{
    public string Id
    {
        get { return "SimpleTrans"; }
    }

    public bool CanActivate()
    {
        return IntegrationGuards.IsSimpleTransLoaded();
    }

    public void Activate()
    {
        // No eager warmup required at the moment.
    }

    public string ReportStatus()
    {
        return "available";
    }
}
