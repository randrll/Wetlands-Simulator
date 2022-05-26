using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class graphScript : MonoBehaviour
{
    [SerializeField] private GameObject graph;
    [SerializeField] private Sprite circleSprite;

    [SerializeField] private float yAxisMaxValue;
    [SerializeField] private float xAxisGapSize;

    private readonly float[] testNumbers = new float[] {10, 20, 50, 40, 60, 90, 100, 20, 0, 10}; // test numbers
    private float[] values = new float[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    private environment enviroScript;

    private GameObject lastDot;
    [SerializeField] private float dotSize;
    [SerializeField] private Color dotColor;

    [SerializeField] private int waitTime;

    private List<GameObject> drawnObjects = new List<GameObject>();
    
    private void Start() {
        enviroScript = GameObject.FindGameObjectWithTag("enviro").GetComponent<environment>();
        graphPoints(values);
        StartCoroutine(startUpdatingPoints());
    }


    /*
    *
    * parameters = size 10 array, floats of value
    *
    */
    private void graphPoints(float[] values) {
        lastDot = null;
        for (int i = 0; i < values.Length; i++) {
            float x = i * xAxisGapSize;
            float y = (values[i] / yAxisMaxValue) * graph.GetComponent<RectTransform>().sizeDelta.y;
            GameObject currentDot = dotPoint(new Vector2(x,y));
            drawnObjects.Add(currentDot);
            if (lastDot != null) {
                drawLines(lastDot.GetComponent<RectTransform>().anchoredPosition, currentDot.GetComponent<RectTransform>().anchoredPosition);
            }
            lastDot = currentDot;
        }
    }

    private GameObject dotPoint(Vector2 dotPosition) {
        GameObject dot = new GameObject("dot", typeof(Image));
        dot.transform.SetParent(graph.transform, false);
        dot.GetComponent<Image>().sprite = circleSprite;
        dot.GetComponent<Image>().color = dotColor;
        dot.transform.localScale = new Vector3(dotSize, dotSize, 0f); 
        dot.GetComponent<RectTransform>().anchoredPosition = dotPosition;
        dot.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        dot.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);

        return dot;
    }
    private void drawLines(Vector2 dot1, Vector2 dot2) {
        GameObject line = new GameObject("line", typeof(Image));
        line.transform.SetParent(graph.transform, false);
        line.GetComponent<Image>().color = dotColor;

        Vector2 direction = (dot2 - dot1).normalized;
        float distance = Vector2.Distance(dot1, dot2);

        line.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        line.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
        line.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, 3f);
        line.GetComponent<RectTransform>().anchoredPosition = dot1 + direction * distance * 0.5f;

        line.GetComponent<RectTransform>().localEulerAngles = new Vector3 (0f, 0f, (Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI));
        drawnObjects.Add(line);
    }

    private IEnumerator startUpdatingPoints() {
        WaitForSecondsRealtime actualWait = new WaitForSecondsRealtime(waitTime);
        while (true) {
            string currentArray = "";

            for (int i = 0; i < drawnObjects.Count; i++) { // deletes previous graph
                Destroy(drawnObjects[i], 0f);
            }

            for (int i = 0; i < values.Length; i++) { // debug.log stuff
                currentArray += (values[i] + " ");
            }

            Debug.Log(currentArray);

            graphPoints(values); // graphs 
            
            yield return actualWait; // 5 second wait time
            Debug.Log("passed wait");
            
            float valueAtTime = (float) enviroScript.getpH(); // use get method here

            for (int i = 0; i < values.Length - 1; i++) { // modifies array input
                Debug.Log("doing");
                values[i] = values[i + 1];
            }
            values[values.Length - 1] = valueAtTime;
        }
    }
}
