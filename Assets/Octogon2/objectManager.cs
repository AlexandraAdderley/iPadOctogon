using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{

    public float initialSize = 1.0f;
    public float incrementSize = 0.1f;

    public float initialRotation = 0f;
    public float incrementRotation = 45f;
    private float rotation;
    private int currentOption = 0;

    public List<GameObject> options = new List<GameObject>();

    void Start()
    {
        transform.localScale = new Vector3(initialSize, initialSize, initialSize);
        transform.transform.rotation = Quaternion.Euler(0f, initialRotation, 0f);
        rotation = initialRotation;

        foreach(GameObject go in options){
            go.SetActive(false);


        }

        options[currentOption].SetActive(true);

    }

    public void SizeUp(){
        transform.localScale = new Vector3(transform.localScale.x * (1f + incrementSize), transform.localScale.y * (1f + incrementSize), transform.localScale.z * (1f + incrementSize));

    }


    public void SizeDown(){
        transform.localScale = new Vector3(transform.localScale.x * (1f - incrementSize), transform.localScale.y * (1f - incrementSize), transform.localScale.z * (1f - incrementSize));

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
        options[currentOption].SetActive(false);
        currentOption++;
        if(currentOption > options.Count -1){
            currentOption = 0;
        }
        options[currentOption].SetActive(true);
    }

    public void OptionPrevious(){
        options[currentOption].SetActive(false);
        currentOption--;
        if(currentOption < 0){
            currentOption = options.Count -1;
        }
        options[currentOption].SetActive(true);

    }

    void Update()
    {
        
    }
}
