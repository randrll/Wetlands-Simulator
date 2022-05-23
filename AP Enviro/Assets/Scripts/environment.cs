using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class environment : MonoBehaviour 
{
    private double pH, carbonInWater, waterTemp, turbidity, biodiversity, dissolvedOxygen, biochemicalOxygenDemand; // enviro elements
    private double carbonAtmo, sediment, nutrient, municipalWaste, sewage, heavyMetals; // iv



    [SerializeField] private Slider carbonSlider, sedimentRSlider, nutrientRSlider, municipalWasteSlider, sewageSlider, heavyMetalsSlider;

    [SerializeField] private Button submitButton;

    [SerializeField] private TextMeshProUGUI pHNumText, turbidityNumText, oxygenNumText, waterTempNumText, oxygenDemandNumText, biodiversityNumText;
    public void Start() {
        submitButton.onClick.AddListener(setFactorValues);
    }

    public void Update() {
      
        handleEnvironment();




        pHNumText.text = pH.ToString();
        turbidityNumText.text = turbidity.ToString();
        oxygenNumText.text = dissolvedOxygen.ToString();
        waterTempNumText.text = waterTemp.ToString();
        oxygenDemandNumText.text = biochemicalOxygenDemand.ToString();
        biodiversityNumText.text = biodiversity.ToString();
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
        pH = 7; carbonInWater = 0; waterTemp = 58; turbidity = 0; biodiversity = 100; dissolvedOxygen = 100; biochemicalOxygenDemand = 50;
    }

    public void setFactorValues() {
        Debug.Log("Clicked.");



        carbonAtmo = (double) carbonSlider.value;
        sediment = (double) sedimentRSlider.value;
        nutrient = (double) nutrientRSlider.value;
        municipalWaste = (double) municipalWasteSlider.value;
        sewage = (double) sewageSlider.value;
        heavyMetals = (double) heavyMetalsSlider.value;
        Debug.Log("carbon: " + carbonAtmo + "\nsediment: " + sediment + "\nnutrient: " + nutrient + "\ntrash: " + municipalWaste + "\nsewage: " + sewage + "\nheavymetals: " + heavyMetals);
    }

    //prints all enviormetn stats
    public void stats() 
    {
        Debug.Log("pH is " + pH);
        Debug.Log("carbonInWater is " + carbonInWater);
        Debug.Log("waterTemp is " + waterTemp);
        Debug.Log("turbidity is " + turbidity);
        Debug.Log("biodiversity is " + biodiversity);
        Debug.Log("dissolvedOxygen is " + dissolvedOxygen);
        Debug.Log("biochemicalOxygenDemand is " + biochemicalOxygenDemand);
    }




    /* enviro formula methods
    *
    *   carbonAtmo = carbonInWater goes up
    *   carbonInWater = pH and water temp goes upS
    *   sediment = turbidity goes down
    *   nutrient = oxygen goes down 
    *   municipalwaste = tubidity goes down
    *   sewage = turbidity goes down
    *
    */

    // private double pH, carbonInWater, waterTemp, turbidity, biodiversity, dissolvedOxygen, biochemicalOxygenDemand; // enviro elements
    //    private double carbonAtmo, sediment, nutrient, municipalWaste, sewage, heavyMetals; // iv
    public void handleEnvironment() {
        waterTemp += carbonAtmo / 500;
        pH -= carbonAtmo / 5000;

        waterTemp += sediment / 500;
        turbidity += sediment / 5000;

        dissolvedOxygen -= nutrient / 1000;
        biochemicalOxygenDemand += nutrient / 1000;

        biodiversity -= municipalWaste / 5000;

        biodiversity -= sewage / 5000;
        dissolvedOxygen -= sewage / 1000;
        biochemicalOxygenDemand += sewage / 1000;

        biodiversity -= (heavyMetals*heavyMetals) / 1000;


        if(waterTemp > 65)
        {
            biodiversity -= (waterTemp*(waterTemp/3)) / 10000;
        }

        if (pH <  6.5)
        {
            biodiversity -= ((20-pH)*(10-pH) / 1000);
        }

        if (pH < 0)
        {
            pH = 0;
        }
        if (dissolvedOxygen < 0)
        {
            dissolvedOxygen = 0;
        }
        if (biodiversity < 0)
        {
            biodiversity = 0;
        }


        /*   if (carbonAtmo > 0 && carbonInWater < (carbonAtmo / 2)) {
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

         */
    }

    // setter and getter methods here:  
    public double getpH() {
        return pH;
    }

    public double getCarbonWater() {
        return carbonInWater;
    }

    public double getWaterTemp() {
        return waterTemp;
    }

    public double getTurbidity() {
        return turbidity;
    }

    public double getBiodiversity() {
        return biodiversity;
    }

     public double getDissolvedOxygen() {
        return dissolvedOxygen;
    }

    public double getOxyDemand() {
        return biochemicalOxygenDemand;
    }

    public void setpH(double input) {
        pH = input;
    }

    public void setCarbonInWater(double input) {
        carbonInWater = input;
    }

    public void setWaterTemp(double input) {
        waterTemp = input;
    }

    public void setTurbidity(double input) {
        turbidity = input;
    }

    public void setBiodiverse(double input) {
        biodiversity = input;
    }

    public void setOxygen(double input) {
        dissolvedOxygen = input;
    }

    public void setOxyDemand(double input) {
        biochemicalOxygenDemand = input;
    }
}
