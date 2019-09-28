using System;
using System.Reflection;
using Terraria.ModLoader;

namespace Localizer.DataModel.Default
{
    public class ModWrapper : IMod
    {
        private readonly WeakReference<Mod> wrapped;

        public ModWrapper(Mod mod)
        {
            wrapped = new WeakReference<Mod>(mod);
        }

        public Mod Mod
        {
            get
            {
                Mod mod = null;
                wrapped?.TryGetTarget(out mod);
                return mod;
            }
        }

        public string Name => Mod?.Name ?? "";

        public Assembly Code => Mod?.Code;
        public string DisplayName => Mod.DisplayName ?? "";
        public Version Version => Mod?.Version;
    }
}
