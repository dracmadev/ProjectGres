using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectGeneral : MonoBehaviour
{
    [Header("AR OBJECT")]
    [Space(25)]
    [Header("Object model:")]
    [SerializeField] private GreModelsEnum modelType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GreModelsEnum GetActualModel()
    {
        return modelType;
    }
}
