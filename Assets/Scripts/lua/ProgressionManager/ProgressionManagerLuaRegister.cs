using UnityEngine;
using PixelCrushers.DialogueSystem;

// Rename this class to the same name that you used for the script file.
// Add the script to your Dialogue Manager. You can optionally make this
// a static class and remove the inheritance from MonoBehaviour, in which
// case you won't add it to the Dialogue Manager.
//
// This class registers two example functions:
//
// - DebugLog(string) writes a string to the Console using Unity's Debug.Log().
// - AddOne(double) returns the value plus one.
//
// You can use these functions as models and then replace them with your own.
namespace NPCChoiceRandomized.DialogueSystem.LuaRegisters
{
    public class ProgressionManagerLuaRegister : MonoBehaviour // Rename this class.
    {
        [Tooltip(
            "Typically leave unticked so temporary Dialogue Managers don't unregister your functions."
        )]
        public bool unregisterOnDisable = false;

        private void OnEnable()
        {
            Debug.Log("Test");
            // Make the functions available to Lua: (Replace these lines with your own.)
            Lua.RegisterFunction(
                "IncrementEndingWeightValue",
                ProgressionManager.Instance,
                SymbolExtensions.GetMethodInfo(
                    () => ProgressionManager.Instance.IncrementEndingWeightValue(0d, 0d)
                )
            );
            // Lua.RegisterFunction("AddOne", this, SymbolExtensions.GetMethodInfo(() => AddOne(0)));
        }

        private void OnDisable()
        {
            if (unregisterOnDisable)
            {
                // Remove the functions from Lua: (Replace these lines with your own.)
                Lua.UnregisterFunction("IncrementEndingWeightValue");
                // Lua.UnregisterFunction("AddOne");
            }
        }
    }
}
