using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ARObjectManipulation : MonoBehaviour
{
    [Header("AR OBJECT MANIPULATION")]
    [Space(25)]
    [Header("Object manipulation variables:")]
    [SerializeField] private GameObject currentARObject;
    [SerializeField] private bool bIsARObjectSelected;
    [SerializeField] private Touch initialTouchPos_Touch;
    [SerializeField] private Vector2 initialTouchPos;
    [SerializeField] private Vector2 currentTouchPos;
    float screenFactor = 0.0001f;
    [SerializeField] private float speedMovement = 4.0f;
    [SerializeField] private float speedRotation = 5.0f;
    [SerializeField] private float scaleFactor = 0.1f;
    [Header("AR Camera:")]
    [SerializeField] private Camera _ARCamera;
  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ARObjectManipulatingBehaviour();
    }

    public void ARObjectManipulatingBehaviour()
    {
        if(Input.touchCount > 0 ||Input.GetMouseButton(0))
        {
            if (Input.touchCount > 0)  // Si es un dispositivo táctil
            {
                initialTouchPos_Touch = Input.GetTouch(0);
                initialTouchPos = initialTouchPos_Touch.position;
                bIsARObjectSelected = CheckIfItsAnARObj(initialTouchPos);
            }
            else if (Input.GetMouseButton(0))  // Si es el editor (con el mouse)
            {
                initialTouchPos = Input.mousePosition;
                bIsARObjectSelected = CheckIfItsAnARObj(initialTouchPos);
            }



            if (bIsARObjectSelected)
            {
                currentTouchPos = initialTouchPos;
                MoveARObject();
            }


        }
    }

    public bool CheckIfItsAnARObj(Vector2 initPos)
    {
        Ray rayCast = _ARCamera.ScreenPointToRay(initPos);

        if(Physics.Raycast(rayCast, out RaycastHit hitARObject))
        {
            if(hitARObject.collider.CompareTag("ARModel"))
            {
                currentARObject = hitARObject.transform.gameObject;
                return true;
            }
        }

        return false;
    }

    public void MoveARObject()
    { 
        Ray rayCast = _ARCamera.ScreenPointToRay(currentTouchPos);

        if (Physics.Raycast(rayCast, out RaycastHit hitARObject))
        {
           
            Vector3 newPosition = hitARObject.point;
            newPosition.y = currentARObject.transform.position.y; 

            currentARObject.transform.position = newPosition;
        }
    }
}
