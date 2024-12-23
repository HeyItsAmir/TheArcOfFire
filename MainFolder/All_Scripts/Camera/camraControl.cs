using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camraControl : MonoBehaviour
{
    [SerializeField]Transform mCamTransform;
    [SerializeField] float TurnSpeed = 150f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = mCamTransform.position; 
    }
    public void AddYawInput(float amt)
    {
       transform.Rotate(Vector3.up, amt * Time.deltaTime * TurnSpeed); 
    }
}
