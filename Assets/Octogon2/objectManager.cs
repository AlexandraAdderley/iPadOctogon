using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{
    private scaleMaterials _scaleMaterials;
    public float initialSize = 1.0f;
    public float incrementSize = 0.1f;

    public float initialRotation = 0f;
    public float incrementRotation = 45f;
    private float rotation;
    private int currentOption = 0;

    private float dissolve = 0f;

    public List<GameObject> options = new List<GameObject>();

    public float fadeSpeed = 0.1f;

    void Start()
    {
        _scaleMaterials = gameObject.GetComponent<scaleMaterials>();
        transform.localScale = new Vector3(initialSize, initialSize, initialSize);
        _scaleMaterials.Rescale();
        transform.transform.rotation = Quaternion.Euler(0f, initialRotation, 0f);
        rotation = initialRotation;

        foreach(GameObject go in options){
            go.SetActive(false);


        }

        options[currentOption].SetActive(true);

    }

    public void SizeUp(){
        transform.localScale = new Vector3(transform.localScale.x * (1f + incrementSize), transform.localScale.y * (1f + incrementSize), transform.localScale.z * (1f + incrementSize));
        _scaleMaterials.Rescale();
    }


    public void SizeDown(){
        transform.localScale = new Vector3(transform.localScale.x * (1f - incrementSize), transform.localScale.y * (1f - incrementSize), transform.localScale.z * (1f - incrementSize));
        _scaleMaterials.Rescale();
    }

    public void RotateClock(){
        rotation += incrementRotation;
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);

    }

    public void RotateAntiClock(){
        rotation -= incrementRotation;
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);

    }

    public void OptionNext(){
        options[currentOption].GetComponent<setDissolve>().TurnOff();
        currentOption++;
        if(currentOption > options.Count -1){
            currentOption = 0;
        }
        options[currentOption].SetActive(true);
        options[currentOption].GetComponent<setDissolve>().TurnOn();
    }

    public void OptionPrevious(){
        options[currentOption].GetComponent<setDissolve>().TurnOff();
        currentOption--;
        if(currentOption < 0){
            currentOption = options.Count -1;
        }
        options[currentOption].SetActive(true);
        options[currentOption].GetComponent<setDissolve>().TurnOn();
    }

    void Update()
    {
        
    }
}
