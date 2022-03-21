using CuttingRoom;
using CuttingRoom.VariableSystem;
using CuttingRoom.VariableSystem.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YourSelectionController : MonoBehaviour
{
    [SerializeField]
    private Text selectionText = null;

    [SerializeField]
    private VariableName variableName = null;

    private DateTime finish = default;

    private void OnEnable()
    {
        finish = DateTime.Now + TimeSpan.FromSeconds(10);
    }

    private void Update()
    {
        NarrativeSpace narrativeSpace = FindObjectOfType<NarrativeSpace>();

        List<StringVariable> variables = narrativeSpace.globalVariableStore.GetVariables<StringVariable>(variableName);

        if (variables.Count > 0)
        {
            selectionText.text = $"You chose to view footage of {variables[0].Value}\n\nPrepare to select again in {Mathf.Clamp((finish - DateTime.Now).Seconds, 0.0f, 10.0f) + 1.0f}s";

            if(SceneManager.GetActiveScene().name != "Demo1")
            {
                selectionText.text += "\n\nThe audience footage is on a triggered layer.";
            }
        }
    }
}
