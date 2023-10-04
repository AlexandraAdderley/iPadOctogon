using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleMaterials : MonoBehaviour
{
    public GameObject waterObject;
    private Material _waterMaterial;
    private float _scale;


    private float _waterNormalTile;
    private float _waterNormalSpeed;
    private float _waterNormalStrength;
    private float _waterWaveTile;

    private float _waterWaveSpeed;

    private float _waterWaveStrength;
    private float _waterFoamDistance;

    private float _waterFoamStrength;

    private float _waterFoamTiling;
    
    private float _waterFoamMovementSpeed;
    
    private float _waterDepth;
    private float _vector2a;
    private float _vector2b;

    private Vector2 _vector2;

    void Start()
    {
        // water
        _waterMaterial = waterObject.GetComponent<Renderer>().material;
        _waterNormalTile = _waterMaterial.GetFloat("_NormalTile");
        _waterNormalStrength = _waterMaterial.GetFloat("_NormalStrength");  
        _waterNormalSpeed = _waterMaterial.GetFloat("_NormalSpeed");
        _waterWaveTile = _waterMaterial.GetFloat("_WaveTile");
        _waterWaveSpeed = _waterMaterial.GetFloat("_WaveSpeed");
        _waterWaveStrength = _waterMaterial.GetFloat("_WaveStrength");
        _waterFoamDistance = _waterMaterial.GetFloat("_FoamDistance");
        _waterFoamStrength = _waterMaterial.GetFloat("_FoamStrength");
        _waterFoamTiling = _waterMaterial.GetFloat("_FoamTiling");
        _waterFoamMovementSpeed = _waterMaterial.GetFloat("_FoamMovementSpeed");
        _waterDepth = _waterMaterial.GetFloat("_Depth");

        _vector2 = _waterMaterial.GetVector("_Vector2");

        Rescale();
    }

    public void Rescale(){
        _scale = gameObject.transform.localScale.x;

        Debug.Log("SCALE IS " + _scale);

        _waterMaterial.SetFloat("_NormalTile", _waterNormalTile / _scale);
        _waterMaterial.SetFloat("_NormalSpeed", _waterNormalSpeed * _scale);
        _waterMaterial.SetFloat("_NormalStrength", _waterNormalStrength * _scale);
        _waterMaterial.SetFloat("_WaveTile", _waterWaveTile * _scale);
        _waterMaterial.SetFloat("_WaveSpeed", _waterWaveSpeed * _scale);
        _waterMaterial.SetFloat("_WaveStrength", _waterWaveStrength * _scale);
    //    _waterMaterial.SetFloat("_FoamDistance", _waterFoamDistance * _scale);
    //    _waterMaterial.SetFloat("_FoamStrength", _waterFoamStrength * _scale);
        _waterMaterial.SetFloat("_FoamTiling", _waterFoamTiling * _scale);
        _waterMaterial.SetFloat("_FoamMovementSpeed", _waterFoamMovementSpeed * _scale);
        _waterMaterial.SetFloat("_Depth", _waterDepth * _scale);

        _vector2 = new Vector2(_vector2.x * _scale, _vector2.y * _scale);


  //      Debug.Log("tile  =" + _waterNormalTile * _scale);
  //      Debug.Log(_vector2);
    }
}
