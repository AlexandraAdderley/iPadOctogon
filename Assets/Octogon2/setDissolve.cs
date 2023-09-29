using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDissolve : MonoBehaviour
{
    public float dissolveInSpeed = 0.05f;
    public float dissolveOutSpeed = 0.05f;

public float fadeDuration = 1f;
    private float dissolve = 0f;

    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _material = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        StartCoroutine(FadeIn());
    }

    public void TurnOff(){
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            _material.SetFloat("_AdvancedDissolveCutoutStandardClip", elapsedTime / fadeDuration);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            _material.SetFloat("_AdvancedDissolveCutoutStandardClip", 1f - (elapsedTime / fadeDuration));
            yield return null;
        }
    }


    public void SetDissolve(float dissolve){
        Debug.Log(dissolve);
        _material.SetFloat("_AdvancedDissolveCutoutStandardClip", dissolve);

    }

}
