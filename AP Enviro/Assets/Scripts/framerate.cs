using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class framerate : MonoBehaviour
{
    [SerializeField] int maxFPS;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 9;
        Application.targetFrameRate = maxFPS;
    }
}
