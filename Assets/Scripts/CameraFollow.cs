using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMax;
    [SerializeField]
    private float yMin;

    private Transform characterTransform;

    [SerializeField]
    private GameObject ellen;

   


    private void Start()
    {
        characterTransform = ellen.transform;
        
    }

  
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(characterTransform.position.x, xMin, xMax), (Mathf.Clamp(characterTransform.position.y, yMin, yMax)), transform.position.z);
    }
}
