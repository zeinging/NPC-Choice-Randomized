using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace NPCChoiceRandomized.DialogueSystem.Lua.MethodRegister
{
    public class ProgressionManagerLuaRegister : MonoBehaviour
    {
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
        [Tooltip(
            "Typically leave unticked so temporary Dialogue Managers don't unregister your functions."
        )]
        public bool unregisterOnDisable = false;

        private void OnEnable()
        {
            // Make the functions available to Lua: (Replace these lines with your own.)i
            Lua.RegisterFunction(
                "GetWeightedValueLua",
                this,
                SymbolExtensions.GetMethodInfo(() => GetWeightedValueLua(0))
            );
        }

        private void OnDisable()
        {
            if (unregisterOnDisable)
            {
                // Remove the functions from Lua: (Replace these lines with your own.)
                Lua.UnregisterFunction("GetWeightedValueLua");
            }
        }

        public double GetWeightedValueLua(double ending)
        {
            int parsedInt = (int)ending;
            Endings targetedEnding = (Endings)parsedInt;

            Dictionary<Endings, int> returnedDictionary = GetWeightedValues(targetedEnding);

            return returnedDictionary[0]; // Should acccess first item since we targeted and Ending
        }
    }
}
