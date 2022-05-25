// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Turbidity : MonoBehaviour
// {
//     [SerializeField] private Sprite circleSprite;
//     private RectTransform graphContainer;

//     private void Awake()
//     {
//                 Debug.Log("MADE A CIRCLE");
       
//         graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

      
//       //  add(environment.getPH*2,4);
//         add(50,4);
//        // add(50,4);
//         //add(50,4);

//     }

//     private void CreateCircle(Vector2 anchoredPosition)
//     {
//         GameObject gameObject = new GameObject("circle", typeof(Image));
//         gameObject.transform.SetParent(graphContainer, false);
//         gameObject.GetComponent<Image>().sprite = circleSprite;
//         RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
//         rectTransform.anchoredPosition = anchoredPosition;
//         rectTransform.sizeDelta = new Vector2(3, 3);
//         rectTransform.anchorMin = new Vector2(0, 0);
//         rectTransform.anchorMax = new Vector2(0, 0);
//         Debug.Log("MADE A CIRCLE");
//     }
    

//     private void add(int y, int x){
 

//         CreateCircle(new Vector2 (x, y));
        
//     }
// }
