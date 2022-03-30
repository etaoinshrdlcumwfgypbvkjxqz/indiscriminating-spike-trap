using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using RimWorld;
using Verse;
using HarmonyLib;

namespace Polyipseity.IndiscriminatingSpikeTrap {
	public class EarlyModStartup : Mod {
		internal static readonly Harmony HARMONY = new Harmony(ModStartup.ID);

		public EarlyModStartup(ModContentPack content) : base(content) {}
	}

	[StaticConstructorOnStartup]
	public static class ModStartup {
		public const string ID = nameof(Polyipseity.IndiscriminatingSpikeTrap);

		static ModStartup() {
			EarlyModStartup.HARMONY.PatchAll();
			Log.Message($"[{ID}] Patches applied.");
		}
	}

	[HarmonyPatch(typeof(Building_Trap), "SpringChance")]
	internal static class Patch_NullifyKnowledgeeOfTrap {
		private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
			bool transpiling = true;
			foreach (var instruction in instructions) {
				yield return instruction;
				if (transpiling && instruction.opcode == OpCodes.Call) {
					MethodInfo operand = (MethodInfo) instruction.operand;
					if (operand.ReturnType == typeof(bool) && operand.DeclaringType == typeof(Building_Trap)) {
						var parameters = operand.GetParameters();
						if (parameters.Length == 1 && parameters[0].ParameterType == typeof(Pawn)) {
							// BuildingTrap::(?): Pawn -> bool
							yield return new CodeInstruction(OpCodes.Pop); // discard the result
							yield return new CodeInstruction(OpCodes.Ldc_I4_0); // load false
							transpiling = false;
						}
					}
				}
			}
		}
	}
}
