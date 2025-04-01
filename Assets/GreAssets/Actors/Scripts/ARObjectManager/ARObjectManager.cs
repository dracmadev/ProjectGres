using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("AR OBJECT MANAGER")]
    [Space(25)]
    [Header("Model to visualize:")]
    [SerializeField] private GreModelsEnum currentGreModel;
    [Header("Model list:")]
    [SerializeField] List<GameObject> arObjects;



    void Start()
    {
        InitARObjectManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InitARObjectManager()
    {
        SetARObjectsList();

        ShowCurrentGreModel();
    }

    public void SetARObjectsList()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("ARModel"))
            {
                arObjects.Add(child.gameObject);
            }
        }
    }

    public GameObject GetCurrentGreModel()
    {
        foreach (GameObject obj in arObjects)
        {
            if(obj.GetComponent<ARObjectGeneral>().GetActualModel() == currentGreModel)
            {
                return obj;
            }
        }

        return null;
    }

    public void DesactiveAllModelsExceptOne(GameObject exception)
    {
        foreach (GameObject obj in arObjects)
        {
            if (exception != obj)
            {
                obj.SetActive(false);
            }
        }
    }

    public void ShowCurrentGreModel()
    {
        if(GetCurrentGreModel() != null)
        {
            GetCurrentGreModel().SetActive(true);
            DesactiveAllModelsExceptOne(GetCurrentGreModel());
        }
        else
        {
            Debug.LogError("GetCurrentGreModel() == NULL    //->Alvaro");
        }
    }
}
