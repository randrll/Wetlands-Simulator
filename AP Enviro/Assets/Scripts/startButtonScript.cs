using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButtonScript : MonoBehaviour
{
    public void LaunchGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
