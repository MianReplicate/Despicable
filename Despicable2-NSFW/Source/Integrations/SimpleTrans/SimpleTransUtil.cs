using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Despicable.NSFW.Integrations.SimpleTrans;
internal static class SimpleTransUtil
{
    private const string MaleReproTag = "PregnancySire";
    private const string FemaleReproTag = "PregnancyCarry";

    internal static bool HasMaleReproductiveOrgan(Pawn pawn)
    {
        return HasMaleReproductiveOrganTag(pawn);
    }

    internal static bool HasFemaleReproductiveOrgan(Pawn pawn)
    {
        return HasFemaleReproductiveOrganTag(pawn);
    }

    internal static bool HasAnyReproductiveSignal(Pawn pawn)
    {
        return HasMaleReproductiveOrganTag(pawn)
            || HasFemaleReproductiveOrganTag(pawn);
    }

    internal static bool TryResolveForDespicable(Pawn pawn, out bool wantsPenis, out bool wantsVagina)
    {
        wantsPenis = false;
        wantsVagina = false;

        if (pawn == null)
            return false;

        wantsPenis = HasMaleReproductiveOrganTag(pawn);
        wantsVagina = HasFemaleReproductiveOrganTag(pawn);

        if (wantsPenis || wantsVagina)
            return true;

        return false;
    }

    internal static bool HasMaleReproductiveOrganTag(Pawn pawn) => HasHediffTag(pawn, MaleReproTag);

    internal static bool HasFemaleReproductiveOrganTag(Pawn pawn) => HasHediffTag(pawn, FemaleReproTag);

    internal static bool HasHediffTag(Pawn pawn, string tag)
    {
        try
        {
            if (tag.NullOrEmpty()) return false;
            if (pawn?.health?.hediffSet?.hediffs == null) return false;
            var hs = pawn.health.hediffSet.hediffs;
            for (int i = 0; i < hs.Count; i++)
            {
                var def = hs[i]?.def;
                var tags = def?.tags;
                if (tags == null) continue;
                for (int t = 0; t < tags.Count; t++)
                {
                    if (tags[t] == tag)
                        return true;
                }
            }
        }
        catch
        {
        }
        return false;
    }
}
