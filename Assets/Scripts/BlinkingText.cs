using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{

    public TextMeshProUGUI blinkingText;
    public float blinkingTimer = 0.5f;

    void Start()
    {
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {

        while (gameObject.activeSelf)
        {
            blinkingText.enabled = !blinkingText.enabled; 

            yield return new WaitForSeconds(blinkingTimer);
        }

    }
    
}
