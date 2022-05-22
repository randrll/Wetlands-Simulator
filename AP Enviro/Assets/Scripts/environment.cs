using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class environment : MonoBehaviour 
{
    private int pH, carbonInWater, waterTemp, turbidity, biodiversity, dissolvedOxygen, biochemicalOxygenDemand; // enviro elements
    private int carbonAtmo, sediment, nutrient, municipalWaste, sewage, heavyMetals; // iv

    [SerializeField] private Slider carbonSlider, sedimentRSlider, nutrientRSlider, municipalWasteSlider, sewageSlider, heavyMetalsSlider;

    [SerializeField] private Button submitButton;

    public void Start() {
        submitButton.onClick.AddListener(setFactorValues);
    }

    public void Update() {

    }

    /* neutral values (ie no effect)
    *   pH = 7
    *   carbonInWater = 0;
    *   waterTemp = 58 // water temp (F) off the port of los angeles (coldest temp)
    *   turbidity = 0;
    *   biodiversity = !?!?
    *   dissolvedOxygen = 10 // max
    *   oxygen demand = 0.5 per animal
    */
    public environment() {
        pH = 7; carbonInWater = 0; waterTemp = 58; turbidity = 0; biodiversity = 0; dissolvedOxygen = 10; biochemicalOxygenDemand = 5;
    }

    public void setFactorValues() {
        Debug.Log("Clicked.");
        carbonAtmo = (int) carbonSlider.value;
        sediment = (int) sedimentRSlider.value;
        nutrient = (int) nutrientRSlider.value;
        municipalWaste = (int) municipalWasteSlider.value;
        sewage = (int) sewageSlider.value;
        heavyMetals = (int) heavyMetalsSlider.value;
        Debug.Log("carbon: " + carbonAtmo + "\nsediment: " + sediment + "\nnutrient: " + nutrient + "\ntrash: " + municipalWaste + "\nsewage: " + sewage + "\nheavymetals: " + heavyMetals);
    }   

    /* enviro formula methods
    *
    *   carbonAtmo = carbonInWater goes up
    *   carbonInWater = pH and water temp goes up
    *   sediment = turbidity goes down
    *   nutrient = oxygen goes down
    *   municipalwaste = tubidity goes down
    *   sewage = turbidity goes down
    *
    */ 
    public void handleEnvironment() {        
        if (carbonAtmo > 0 && carbonInWater < (carbonAtmo / 2)) {
            carbonInWater += 1;
        }
        
        if (carbonInWater > 0 && pH > (carbonAtmo - carbonInWater)) {
            pH =- 1;
        }

        if (pH < 7 && waterTemp < (pH * 10)) {
            waterTemp += 2;
        }

        if (waterTemp > 58) {
            dissolvedOxygen =- (waterTemp - 58) / 100;
        }
    }

    // setter and getter methods here:  
    public int getpH() {
        return pH;
    }

    public int getCarbonWater() {
        return carbonInWater;
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

    public void setpH(int input) {
        pH = input;
    }

    public void setCarbonInWater(int input) {
        carbonInWater = input;
    }

    public void setWaterTemp(int input) {
        waterTemp = input;
    }

    public void setTurbidity(int input) {
        turbidity = input;
    }

    public void setBiodiverse(int input) {
        biodiversity = input;
    }

    public void setOxygen(int input) {
        dissolvedOxygen = input;
    }

    public void setOxyDemand(int input) {
        biochemicalOxygenDemand = input;
    }
}
