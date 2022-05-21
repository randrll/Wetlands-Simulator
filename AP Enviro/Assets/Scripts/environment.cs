using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class environment : MonoBehaviour 
{
    private int pH, totalCarbon, waterTemp, turbidity, biodiversity, dissolvedOxygen, biochemicalOxygenDemand; 

    [SerializeField] private Slider carbonSlider, sedimentRSlider, nutrientRSlider, municipalWasteSlider, sewageSlider, heavyMetalsSlider;

    public environment() {
        pH = 7; totalCarbon = 0; waterTemp = 0; turbidity = 0; biodiversity = 0; dissolvedOxygen = 10; biochemicalOxygenDemand = 5; // temporary values 
    }

    public int getpH() {
        return pH;
    }

    public int getCarbon() {
        return totalCarbon;
    }

    public int getWaterTemp() {
        return waterTemp;
    }

    public int getTurbidity() {
        return turbidity;
    }

    public int getBiodiversity() {
        return biodiversity;
    }

    public int getDissolvedOxygen() {
        return dissolvedOxygen;
    }

    public int getOxyDemand() {
        return biochemicalOxygenDemand;
    }
}
