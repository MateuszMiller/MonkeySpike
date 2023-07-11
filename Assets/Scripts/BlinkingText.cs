using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public static BlinkingText instance;

    public TextMeshProUGUI blinkingText;
    public float blinkingTimer = 0.5f;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _StartCoroutine();
    }

    

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void _StartCoroutine()
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
