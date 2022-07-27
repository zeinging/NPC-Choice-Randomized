using System.Collections.Generic;
using UnityEngine;

public class NPCRandom : MonoBehaviour
{
    public float Probablity = 0.5f,
        influence = 0.3f;

    public int Ending = 0,
        fractionNumber = 6;

    public PlayerUICTRL controls;

    public bool FilterOutRepeats = true;

    public int Rand;
    public int SelectedNumber;
    public List<int> remainingNumbers;

    // Start is called before the first frame update
    private void Start()
    {
        controls = new PlayerUICTRL();

        //controls.UI.Submit.performed += ctx => NPCDecisionCalculation();

        controls.Enable();

        GetListOfNumbers();

        //repeateList = new List<int>(new int[Length]);
        //repeateList = new int[fractionNumber];
    }

    // Update is called once per frame
    private void Update()
    {
        if (controls.UI.Submit.triggered)
        {
            NPCDecisionCalculation();
        }
    }

    private void GetListOfNumbers()
    {
        for (int i = 1; i < fractionNumber; i++)
        {
            remainingNumbers.Add(i);
        }
    }

    public void NPCDecisionCalculation()
    {
        _ = Random.Range(0, 3);

        Rand = Random.Range(0, remainingNumbers.Count);

        SelectedNumber = remainingNumbers[Rand];

        if (remainingNumbers.Count > 1)
        {
            //remainingNumbers.Add(Rand);
            //SelectedNumber = remainingNumbers[Rand];
            if (FilterOutRepeats)
            {
                remainingNumbers.RemoveAt(Rand);
            }
        }
        else
        {
            //remainingNumbers.Clear();
            remainingNumbers.Clear();
            GetListOfNumbers();
        }

        switch (SelectedNumber)
        {
            case 1:
                print("1");
                break;

            case 2:
                print("2");
                break;

            case 3:
                print("3");
                break;

            case 4:
                print("4");
                break;

            case 5:
                print("5");
                break;

            case 6:
                print("6");
                break;

            default:
                print("range out of bounds");
                break;
        }
    }
}
