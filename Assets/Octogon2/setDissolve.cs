using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDissolve : MonoBehaviour
{


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

    public void SetDissolve(float dissolve){
        Debug.Log(dissolve);
        _material.SetFloat("_AdvancedDissolveCutoutStandardClip", dissolve);

    }

}
