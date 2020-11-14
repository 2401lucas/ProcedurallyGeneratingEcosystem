using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =  "Level/HeightMapSettings")]
public class HeightMapSettings : UpdatableData
{
    public NoiseSettings noiseSettings;


    public bool useFallOffMap;

    public float heightMultiplier;
    public AnimationCurve heightCurve;

    public float minHeight
    {
        get
        {
            return heightMultiplier * heightCurve.Evaluate(0);
        }
    }

    public float maxHeight
    {
        get
        {
            return heightMultiplier * heightCurve.Evaluate(1);
        }
    }


#if UNITY_EDITOR
    //Everytime a variable is changed in the editor, OnValidate checks variables, here you can set limitations on 
    protected override void OnValidate()
    {
        noiseSettings.ValidateValues();

        base.OnValidate();
    }
    #endif
}
