using Verse;

namespace Polyipseity.IndiscriminatingSpikeTrap {
	public class EarlyModStartup : Mod {
		public EarlyModStartup(ModContentPack content) : base(content) {}
	}

	[StaticConstructorOnStartup]
	public static class ModStartup {
		public const string ID = nameof(Polyipseity.IndiscriminatingSpikeTrap);

		static ModStartup() {}
	}
}
