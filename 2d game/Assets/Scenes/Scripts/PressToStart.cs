using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    public void PressToStarts()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
