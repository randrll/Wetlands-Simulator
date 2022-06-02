using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class environment : MonoBehaviour 
{
    // Environment Elements
    private double pH, carbonInWater, waterTemp, turbidity, biodiversity, dissolvedOxygen, biochemicalOxygenDemand;

    // Independent Factors (Human Elements)
    private double carbonAtmo, sediment, nutrient, municipalWaste, sewage, heavyMetals; 

    // Sliders
    [SerializeField] private Slider carbonSlider, sedimentRSlider, nutrientRSlider, municipalWasteSlider, sewageSlider, heavyMetalsSlider;

    // Button to activate Sliders
    [SerializeField] private Button submitButton;

    // Graph Value Text
    [SerializeField] private TextMeshProUGUI pHNumText, turbidityNumText, oxygenNumText, waterTempNumText, oxygenDemandNumText, biodiversityNumText;

    // Animal PreFabs (Models / Sprites)
    [SerializeField] private GameObject seagullPreFab;
    [SerializeField] private GameObject fishPreFab;

    // Spawnpoints on land
    [SerializeField] private GameObject[] lSpawns;


    // Spawnpoint(s) on water
    [SerializeField] private GameObject wSpawn;

    // List of animals and their movepoints
    private List<GameObject> seagulls = new List<GameObject>();
    private List<GameObject> fishes = new List<GameObject>();
    private List<GameObject> seagullsMovePoints = new List<GameObject>();
    private List<GameObject> fishesMovePoints = new List<GameObject>();

    // Values of animals and what they should be
    private int numberOfSupposedBirds;
    private int numberOfCurrentBirds = 0;

    private double numberOfSupposedFish;
    private double numberOfCurrentFish = 0;
    public double Co2 = 0;
    public double sed = 0;
    public double nut = 0;
    public double waste = 0;
    public double sew = 0;
    public double metal = 0; 

    /*  Constructor:
    *   
    *   neutral values (ie no effect)
    *   pH = 7
    *   carbonInWater = 0;
    *   waterTemp = 58 // water temp (F) off the port of los angeles (coldest temp)
    *   turbidity = 0;
    *   biodiversity = !?!?
    *   dissolvedOxygen = 10 // max
    *   oxygen demand = 0.5 per animal
    *
    *
    *
    */
    public environment() {
        pH = 7; carbonInWater = 0; waterTemp = 58; turbidity = 3; biodiversity = 100; dissolvedOxygen = 10; biochemicalOxygenDemand = 10;
        numberOfSupposedBirds = (int) (biodiversity / 10);
        numberOfSupposedFish = (int) (biodiversity / 2); 
    }

    public void Start() {
        submitButton.onClick.AddListener(setFactorValues);        
    }

    public void Update() {
        handleEnvironment();

        // update animal numbers
        numberOfSupposedBirds = (int) (biodiversity / 10);
        numberOfSupposedFish = (int) (biodiversity / 2);     
        AutoSpawnAndDeleteFish();
        AutoSpawnAndDeleteSeagull();

        // chart num
        pHNumText.text = (Mathf.Floor((float) (pH * 1000)) / 1000).ToString(); 
        turbidityNumText.text = (Mathf.Floor((float) (turbidity * 1000)) / 1000).ToString(); 
        oxygenNumText.text = (Mathf.Floor((float) (dissolvedOxygen * 1000)) / 1000).ToString(); 
        waterTempNumText.text = (Mathf.Floor((float) (waterTemp * 1000)) / 1000).ToString(); 
        oxygenDemandNumText.text = (Mathf.Floor((float) (biochemicalOxygenDemand * 1000)) / 1000).ToString(); 
        biodiversityNumText.text = (Mathf.Floor((float) (biodiversity * 1000)) / 1000).ToString(); 
    }

    /* Spawns and deletes seagulls based on the biodiversity number 
    *
    * Biodiversity handled each frame by the update() method
    *
    */
    public void AutoSpawnAndDeleteSeagull() {
        while (numberOfCurrentBirds != numberOfSupposedBirds) {
            if (numberOfCurrentBirds < numberOfSupposedBirds) {
                GameObject clone = Instantiate(seagullPreFab, lSpawns[(int) Random.Range(0,3)].transform.position, Quaternion.identity);
                clone.name += numberOfCurrentBirds.ToString();
                seagulls.Add(clone); 
                seagullsMovePoints.Add(clone.transform.GetChild(1).gameObject); // gets the movepoint object
                numberOfCurrentBirds++;
            } else if (numberOfCurrentBirds > numberOfSupposedBirds && numberOfCurrentBirds > 0) {
                Destroy(seagulls[seagulls.Count - 1], 0f);
                Destroy(seagullsMovePoints[seagullsMovePoints.Count - 1], 0f);
                seagulls.RemoveAt(seagulls.Count - 1);
                seagullsMovePoints.RemoveAt(seagullsMovePoints.Count - 1);
                numberOfCurrentBirds--;
            }
        }

    }

    /* Spawns and deletes fishes based on the biodiversity number 
    *
    * Biodiversity handled each frame by the update() method
    *
    */
    public void AutoSpawnAndDeleteFish() {
        while (numberOfCurrentFish != numberOfSupposedFish) {
            if (numberOfCurrentFish < numberOfSupposedFish) {
                GameObject clone = Instantiate(fishPreFab, wSpawn.transform.position, Quaternion.identity);
                clone.name += numberOfCurrentFish.ToString();
                fishes.Add(clone);
                fishesMovePoints.Add(clone.transform.GetChild(1).gameObject);
                numberOfCurrentFish++;
            } else if (numberOfCurrentFish > numberOfSupposedFish && numberOfCurrentFish > 0) {
                Destroy(fishes[fishes.Count - 1], 0f);
                Destroy(fishesMovePoints[fishesMovePoints.Count - 1], 0f);
                fishes.RemoveAt(fishes.Count - 1);
                fishesMovePoints.RemoveAt(fishesMovePoints.Count - 1);
                numberOfCurrentFish--;
            }
        }
    }

    /*  Method to change the factors
    *
    *   Update at every frame
    *
    */ 
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

    //prints all evniro stats
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

        if (Co2 < 10000  && carbonAtmo < 0){    
            waterTemp += carbonAtmo / 500;
            pH -= carbonAtmo / 5000;
            Co2 -= carbonAtmo;
        }
        if (carbonAtmo > 0){    
            waterTemp += carbonAtmo / 500;
            pH -= carbonAtmo / 5000;
            Co2 -= carbonAtmo;
        }
 
        if(sed < 200 && sediment < 0){
            Debug.Log("decrease");
            turbidity += sediment / 5000;
            waterTemp += sediment / 500;
            sed -= sediment ;
        }
        if(sediment > 0){
            Debug.Log("increase");
             turbidity += sediment / 5000;   
             waterTemp += sediment/500;       
            sed -= sediment ; 
        }

        if (nut < 500  && nutrient < 0){  
            dissolvedOxygen -= nutrient / 1000;
           
            nut -= nutrient;
        }
        if(nutrient > 0){
            dissolvedOxygen -= nutrient / 1000;
            
            nut -= nutrient;
        }
        
        biochemicalOxygenDemand = 11 - dissolvedOxygen;
        if(biochemicalOxygenDemand < 0){
            biochemicalOxygenDemand = 0;
        }
        if(waste < 100 && municipalWaste < 0){
            biodiversity -= municipalWaste / 2000;
            waste -= municipalWaste;
        }
        if (municipalWaste > 0){
            waste -= municipalWaste;
            biodiversity -= municipalWaste / 2000;

        }

        if(sew < 100 &&  sewage < 0){    
            biodiversity -= sewage / 2000;
             dissolvedOxygen -= sewage / 1000;           
            sew -= sewage;
        }
        if(sewage > 0 ){
            biodiversity -= sewage / 2000;            
            dissolvedOxygen -= sewage / 1000;
            biochemicalOxygenDemand += sewage / 1000;
            sew -= sewage;
        }
                
                
        if(metal < 100 && heavyMetals < 0){    
            biodiversity += (heavyMetals*heavyMetals) / 1000;
            metal -= heavyMetals;
        }
        if(heavyMetals > 0){
            biodiversity -= (heavyMetals*heavyMetals) / 1000;
            metal -= heavyMetals;
        }

            if(biochemicalOxygenDemand > 2)
            {
                if( ( nutrient / 1000 + sewage/1000) < 0){
                    biodiversity += (biochemicalOxygenDemand * biochemicalOxygenDemand) / 100;        
                }else{
                    biodiversity -= (biochemicalOxygenDemand * biochemicalOxygenDemand) / 100;                    
                }


            }

            if(turbidity > 5)
            {
                biodiversity -= (turbidity * turbidity) / 2000;
 //               waterTemp += (turbidity * turbidity) / 6000;
            } 
 

//            dissolvedOxygen -= waterTemp / 40000;
            if(waterTemp > 65)
            {
                if( (carbonAtmo / 500 +  sediment/500) < 0.0){
                    Debug.Log("here");
                    biodiversity += (waterTemp*(waterTemp/3)) / 20000;                    
                }else{
                  biodiversity -= (waterTemp*(waterTemp/3)) / 20000;                    
                }

            }else if(waterTemp > 62){
                if( (carbonAtmo / 500 +  sediment/500) < 0){
                    biodiversity += (waterTemp*(waterTemp/5)) / 20000;                    
                }else{
                    biodiversity -= (waterTemp*(waterTemp/5)) / 20000;                    
                }

            }


            if(waterTemp < 45)
            {
                if( (carbonAtmo / 500 +  sediment/500) > 0){
                    biodiversity += ( (100-waterTemp) * ( (100-waterTemp) / 3)) / 20000;                   
                }else{
                  biodiversity -= ( (100-waterTemp) * ( (100-waterTemp) / 3)) / 20000;                    
                }

            }else if(waterTemp < 53){
                if( (carbonAtmo / 500 +  sediment/500) > 0){
                   biodiversity -= ( (100-waterTemp) * ( (100-waterTemp) / 5)) / 20000;                 
                }else{
                    biodiversity -= ( (100-waterTemp) * ( (100-waterTemp) / 5)) / 20000;                    
                }

            }

        if (pH <  6.5)
        {
            if(carbonAtmo < 0){
                biodiversity += ((25-pH)*(25-pH) / 2000);
            }else{
                biodiversity -= ((25-pH)*(25-pH) / 2000);           
            }

        }else if( pH < 6.7){
             if(carbonAtmo < 0){
                 biodiversity += ((20-pH)*(20-pH) / 4000);
            }else{
                biodiversity -= ((20-pH)*(20-pH) / 4000);
            }
           
        }else if(pH < 7){
            if(carbonAtmo < 0){
            biodiversity += pH/2000;
            }else{
            biodiversity -= pH/2000;
            }

        }
        if(pH > 8.5)
        {
            if(carbonAtmo > 0){
               biodiversity += (pH * pH) / 2000;
            }else{
              biodiversity -= (pH * pH) / 2000;
            }
        }else if(pH > 8){
            if(carbonAtmo > 0){
             biodiversity += (pH * pH) / 4000;
            }else{
             biodiversity -= (pH * pH) / 4000;
            }
 
        }else if(pH > 7){
            if(carbonAtmo > 0){
               biodiversity += pH/2000;     
            }else{
              biodiversity -= pH/2000;     
            }
               
        }

        if(biodiversity >= 100){
            biodiversity = 100;
        }
        if (pH < 0)
        {
            pH = 0;
        }
        if(waterTemp > 100){
            waterTemp = 100;
        }
        if(pH > 11){
            pH =11;
        }
        if (dissolvedOxygen < 0)
        {
            dissolvedOxygen = 0;
        }
        if (biodiversity < 0)
        {
            biodiversity = 0;
        }

        if(turbidity < 0)
        {
            turbidity = 0;
        }
    }

    public void resetValues() {
        pH = 7; carbonInWater = 0; waterTemp = 58; turbidity = 3; biodiversity = 100; dissolvedOxygen = 10; biochemicalOxygenDemand = 10;
        carbonAtmo = 0; sediment = 0; nutrient = 0; municipalWaste = 0; sewage = 0; heavyMetals = 0; 
    }

    /*
    *
    *
    * G E T T E R  A N D  S E T  M E T H O D S  H E R E
    *
    *
    */  
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
  