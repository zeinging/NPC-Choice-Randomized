using System.Collections.Generic;
using UnityEngine;

namespace NPCChoiceRandomized.DialogueSystem
{
    public static class ProgressionManagerLuaRegister
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
        public static bool unregisterOnDisable = false;

        public static double GetWeightedValueLua(double ending)
        {
            int parsedInt = (int)ending;
            Endings targetedEnding = (Endings)parsedInt;

            Dictionary<Endings, int> returnedDictionary =
                ProgressionManager.Instance.GetWeightedValues(targetedEnding);

            return returnedDictionary[0]; // Should acccess first item since we targeted and Ending
        }
    }
}
