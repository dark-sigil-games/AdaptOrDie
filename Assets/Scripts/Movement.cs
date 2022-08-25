using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    private Rigidbody _rocketRigidBody;

    [SerializeField] 
    private float forwardThrust = 1000f;
    
    [SerializeField] 
    private float rotationThrust = 100f;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rocketRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rocketRigidBody.AddRelativeForce(Vector3.up * forwardThrust * Time.deltaTime);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rocketRigidBody.freezeRotation = true;
        
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

        _rocketRigidBody.freezeRotation = false;
    }
}
