using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetFactors : MonoBehaviour {
    [SerializeField] private Slider CO2, sediment, nutrient, msw, sewage, metals;
    private environment enviroscript;

    private void Start() {
       enviroscript = GameObject.FindGameObjectWithTag("enviro").GetComponent<environment>(); 
    }

    public void resetStuff() {
        CO2.value = 0;
        sediment.value = 0;
        nutrient.value = 0;
        msw.value = 0;
        sewage.value = 0;
        metals.value = 0;

        enviroscript.resetValues(); // comment
   }
}
