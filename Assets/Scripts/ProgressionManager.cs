using System;
using System.Collections.Generic;
using NPCChoiceRandomized.DialogueSystem.LuaRegisters;
using UnityEngine;

namespace NPCChoiceRandomized.DialogueSystem
{
    public class ProgressionManager : MonoBehaviour
    {
        // Implementing the Singleton Pattern to ensure there's only one source of information
        // Source for implementation: https://medium.com/nerd-for-tech/implementing-a-game-manager-using-the-singleton-pattern-unity-eb614b9b1a74
        private static ProgressionManager _instance;

        public static ProgressionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("ProgressionManager is NULL!");
                }
                return _instance;
            }
        }

        [SerializeField]
        private Dictionary<Endings, int> ProgressionDictionary = new Dictionary<Endings, int>();

        // This syntax initializes the dictionary with all endings starting at 0;


        private void Awake()
        {
            _instance = this;

            // Initializes the dictionary with all of the endings
            foreach (Endings ending in Enum.GetValues(typeof(Endings)))
            {
                ProgressionDictionary.Add(ending, 5);
            }

            GetComponent<ProgressionManagerLuaRegister>().enabled = true;
        }

        public void IncrementEndingWeightValue(double endingDouble, double incrementDouble)
        {
            Debug.Log("Running Increment Function");
            Endings ending = (Endings)endingDouble;
            int increment = (int)incrementDouble;

            if (!ProgressionDictionary.ContainsKey(ending))
            {
                HandleEndingNotInDictionary(ending);

                return;
            }

            ProgressionDictionary[ending] += increment;

            Debug.Log("VALUE AFTER INCREMENT");
            Debug.Log(ProgressionDictionary[ending]);
        }

        public Dictionary<Endings, int> GetWeightedValues(Endings? ending = null)
        {
            // The copying of this method will hopefully prevent accidental
            // Mutations to the original Dictionary
            if (ending == null)
            {
                Dictionary<Endings, int> copiedDictionary = new Dictionary<Endings, int>();

                foreach (Endings e in Enum.GetValues(typeof(Endings)))
                {
                    copiedDictionary.Add(e, ProgressionDictionary[e]);
                }
                return copiedDictionary;
            }
            else
            {
                Endings notNullEnding = (Endings)ending;
                if (!ProgressionDictionary.ContainsKey(notNullEnding))
                {
                    HandleEndingNotInDictionary(notNullEnding);

                    return null;
                }

                Dictionary<Endings, int> singleDictionary = new Dictionary<Endings, int>
                {
                    { notNullEnding, ProgressionDictionary[notNullEnding] }
                };
                return singleDictionary;
            }
        }

        private void HandleEndingNotInDictionary(Endings ending)
        {
            Debug.LogError(
                "ENDING " + ending + " IS NOT PRESET IN DICTIONARY. THIS SHOULDN'T BE POSSIBLE"
            );
        }
    }
}
