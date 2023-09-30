using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float moveForce;
    public float moveDeadzone = 0.3f;
    public float lookDeadzone = 0.3f;


    [SerializeField]
    Transform DirTransform;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private Camera mainCamera;
    Vector3 camTransform;

    [SerializeField] Vector3 InputDirection;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per physics tick
    private void FixedUpdate()
    {
        camTransform = new Vector3(-mainCamera.transform.right.x, 0, -mainCamera.transform.right.z);
        camTransform = camTransform.normalized;
        DirTransform.forward = camTransform;

        //FixRotation();
        UpdateLook();
        UpdateMovement();
        //Debug.Log("moveInput: " + moveInput);
    }

    // ------------------------------------------------------------------------------------------------
    // Functions:
    // ------------------------------------------------------------------------------------------------
    private void UpdateLook()
    {
        transform.forward = DirTransform.right* lookInput.x + DirTransform.forward* lookInput.y;
    }

    private void UpdateMovement()
    {
        //Debug.Log(mainCamera.transform.right);

        gameObject.GetComponent<Rigidbody>().AddForce(-DirTransform.forward * moveForce * moveInput.x + DirTransform.right * moveForce * moveInput.y, ForceMode.Impulse);
    }

    private void FixRotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }

    // ------------------------------------------------------------------------------------------------
    // Input System Functions:
    // ------------------------------------------------------------------------------------------------
    void OnJump()
    {
        //Debug.Log("Jump!");
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,5,0), ForceMode.Impulse);
    }

    void OnMove(InputValue mInput)
    {
        //Debug.Log("mInput: "+ mInput);

        if (mInput.Get<Vector2>().x < -moveDeadzone || mInput.Get<Vector2>().x > moveDeadzone)
        {
            moveInput.x = mInput.Get<Vector2>().x;
        }
        else
        {
            moveInput.x = 0;
        }

        if (mInput.Get<Vector2>().y < -moveDeadzone || mInput.Get<Vector2>().y > moveDeadzone)
        {
            moveInput.y = mInput.Get<Vector2>().y;
        }
        else
        {
            moveInput.y = 0;
        }
    }

    void OnLook(InputValue lInput)
    {
        //Debug.Log("mInput: "+ mInput);

        if (lInput.Get<Vector2>().x < -moveDeadzone || lInput.Get<Vector2>().x > lookDeadzone)
        {
            lookInput.x = lInput.Get<Vector2>().x;
        }
        else
        {
            moveInput.x = 0;
        }

        if (lInput.Get<Vector2>().y < -moveDeadzone || lInput.Get<Vector2>().y > lookDeadzone)
        {
            lookInput.y = lInput.Get<Vector2>().y;
        }
        else
        {
            moveInput.y = 0;
        }
    }
}
