using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEstimation : MonoBehaviour{


    public float testValue = 0.5f;

    void OnValidate(){
      setGlobalLightEstimation(testValue);
    }

    void setGlobalLightEstimation(float lightValue){
      Shader.SetGlobalFloat("_GlobalLightEstimation", lightValue);
    }


    void Update()
    {

    }
}
