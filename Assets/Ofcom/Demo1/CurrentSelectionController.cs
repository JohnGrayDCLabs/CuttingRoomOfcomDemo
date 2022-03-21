using CuttingRoom;
using CuttingRoom.VariableSystem;
using CuttingRoom.VariableSystem.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSelectionController : MonoBehaviour
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
            selectionText.text = $"You are going to see content related to\n\n{variables[0].Value}\n\nin {Mathf.Clamp((finish - DateTime.Now).Seconds, 0.0f, 10.0f) + 1.0f}s";
        }
    }

}
