using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI blinkingText;
    public float blinkingTimer = 0.5f;
    
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        StartCoroutine();
    }

    public void StartCoroutine()
    {
        StartCoroutine(Blink());
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
