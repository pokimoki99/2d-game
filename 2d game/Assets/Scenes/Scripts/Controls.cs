using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public Text jump;
    public Text slide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Control());
    }

    IEnumerator Control()
    {
        yield return new WaitForSeconds(5);
        jump.enabled = false;
        slide.enabled = false;

    }
}
