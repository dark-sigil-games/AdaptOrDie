using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rocketRigidBody;
    private AudioSource _rocketAudioSource;

    [SerializeField] 
    private float forwardThrust = 1000f;
    
    [SerializeField] 
    private float rotationThrust = 100f;
    
    private void Start()
    {
        _rocketRigidBody = GetComponent<Rigidbody>();
        _rocketAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!_rocketAudioSource.isPlaying)
            {
                _rocketAudioSource.Play();
            }
            
            _rocketRigidBody.AddRelativeForce(Vector3.up * forwardThrust * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rocketAudioSource.Stop();
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
