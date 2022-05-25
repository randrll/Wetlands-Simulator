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

    [SerializeField] private GameObject seagullPreFab;
    [SerializeField] private GameObject fishPreFab;
    [SerializeField] private GameObject lSpawn0;
    [SerializeField] private GameObject lSpawn1;
    [SerializeField] private GameObject lSpawn2;
    [SerializeField] private GameObject lSpawn3;
    private GameObject[] lSpawns = new GameObject[4];

    [SerializeField] private GameObject wSpawn;

    private List<GameObject> seagulls = new List<GameObject>();
    private List<GameObject> fishes = new List<GameObject>();

    public void spawnSeagull() {

    }

    public void AutoSpawnAndDeleteFish() {
        // int numberOfSupposedFish = (int) (biodiversity / 2);
        // int numberOfCurrentFish = 0;

        // while (numberOfCurrentFish != numberOfSupposedFish) {
        //     if (numberOfCurrentFish < numberOfSupposedFish) {
        //         GameObject clone = Instantiate(fishPreFab, wSpawn.transform.position, Quaternion.identity);
        //         clone.name += "1";
        //         fishes.Add(clone);
        //         numberOfCurrentFish++;
        //         Debug.Log("Spawned fish. Supposed to stop at: " + numberOfSupposedFish + "\nFish count: " + numberOfCurrentFish);
        //     } else if (numberOfCurrentFish > numberOfSupposedFish) {

        //     }
        // }
    }

    public void Start() {
        submitButton.onClick.AddListener(setFactorValues);
    }

    public void Update() {
        AutoSpawnAndDeleteFish();
        Instantiate(fishPreFab, wSpawn.transform.position, Quaternion.identity);
        handleEnvironment();
        

        // chart num
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
        pH = 7; carbonInWater = 0; waterTemp = 58; turbidity = 3; biodiversity = 100; dissolvedOxygen = 10; biochemicalOxygenDemand = 10;
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
        waterTemp += carbonAtmo / 500;
        pH -= carbonAtmo / 5000;

        waterTemp += sediment / 500;
        turbidity += sediment / 5000;

        dissolvedOxygen -= nutrient / 1000;
        biochemicalOxygenDemand = 10 - dissolvedOxygen;

        biodiversity -= municipalWaste / 5000;

        biodiversity -= sewage / 5000;

        dissolvedOxygen -= sewage / 1000;
        biochemicalOxygenDemand += sewage / 1000;

        biodiversity -= (heavyMetals*heavyMetals) / 1000;

        if(dissolvedOxygen < 3)
        {
            biodiversity -= (dissolvedOxygen * dissolvedOxygen) / 100;
        }

        if(turbidity > 5)
        {
            biodiversity -= (turbidity * turbidity) / 2000;
        }

        if(waterTemp > 65)
        {
            biodiversity -= (waterTemp*(waterTemp/3)) / 20000;
            dissolvedOxygen -= waterTemp / 20000;
        }

        if(waterTemp < 45)
        {
            biodiversity -= ( (100-waterTemp) * ( (100-waterTemp) / 3)) / 20000;
        }

        if (pH <  6.5)
        {
            biodiversity -= ((20-pH)*(10-pH) / 2000);
        }
        if(pH > 8.5)
        {
            biodiversity -= (pH * pH) / 2000;
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

        if(turbidity < 0)
        {
            turbidity = 0;
        }

    }
}
