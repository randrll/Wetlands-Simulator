using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< Updated upstream:AP Enviro/Assets/Scripts/Turbidity.cs
public class Turbidity : MonoBehaviour
=======
public class Window_Graph : MonoBehaviour
>>>>>>> Stashed changes:AP Enviro/Assets/Scripts/Window_Graph.cs
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
                Debug.Log("MADE A CIRCLE");
       
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

      
      //  add(environment.getPH*2,4);
<<<<<<< Updated upstream:AP Enviro/Assets/Scripts/Turbidity.cs
        add(50,4);
=======
       // add(50,4);
>>>>>>> Stashed changes:AP Enviro/Assets/Scripts/Window_Graph.cs
       // add(50,4);
        //add(50,4);

    }

    private void CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(3, 3);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        Debug.Log("MADE A CIRCLE");
    }
    

    private void add(int y, int x){
 

        CreateCircle(new Vector2 (x, y));
        
    }
}
