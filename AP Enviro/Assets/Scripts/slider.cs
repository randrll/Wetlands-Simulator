using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class slider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText; // picks which TMP object to change to value

    public void updateValue (float input) {
        valueText.text = input.ToString();
    }

    public int returnSliderValue(float input) {
        return (int) input;
    }
}
