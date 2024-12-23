using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    [SerializeField] JoyStik moveStick;
    [SerializeField] JoyStik aimStick;
    [SerializeField] CharacterController CharacterController;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float turnSpeed = 30f;
    [SerializeField] float AnimationTurnSpeed = 30f;

    playerHealth playerHealth;
    Enemy playerIsInRange;



    [Header("Inventoy")]
    [SerializeField] inventory inventorycomponent;

    float animeyTurnSpeed;

    Animator animator;

    Vector2 moveInput;
    Vector2 aimInput;

    Camera mainCam;
    camraControl camraControl;
    
    // Start is called before the first frame update
    void Start()
    {
     
        moveStick.onStickInputValueUpdate += moveStickUpdate;
        aimStick.onStickInputValueUpdate += aimStickUpdate;
        aimStick.onStickTabed += StartSwitchWeapon;
        mainCam = Camera.main;
        camraControl = FindObjectOfType<camraControl>();
        animator = GetComponent<Animator>();
    }

    public void DarhalShelik()
    {
        inventorycomponent.GetActiveWeapon().Attack();
    }

    void StartSwitchWeapon()
    {
        animator.SetTrigger("switch");
    }

    public void Switch()
    {
        inventorycomponent.nextWeapon();
    }


    void aimStickUpdate(Vector2 inputvalue)
    {
        aimInput = inputvalue;
        if (aimInput.magnitude > 0)
        {
            animator.SetBool("Hamleh", true);
        }
        else
        {
            animator.SetBool("Hamleh", false);
        }
    }
    void moveStickUpdate(Vector2 inputvalue) 
    { 
        moveInput = inputvalue; 
    }
  Vector3 SITWD (Vector2 inpuValu)
    {
        Vector3 rightDir = mainCam.transform.right;
        Vector3 upDir = Vector3.Cross(rightDir, Vector3.up);
        return rightDir * inpuValu.x + upDir * inpuValu.y;
    }
 
    // Update is called once per frame
    void Update()
    {
        peformMoveAndAim();
        UpdateCamera();
       
    }

    private void peformMoveAndAim()
    {
        Vector3 moveDir = SITWD(moveInput);
        CharacterController.Move(moveDir * Time.deltaTime * moveSpeed);
        UpdateAim(moveDir);
        float Forward = Vector3.Dot (moveDir, transform.forward);
        float right = Vector3.Dot(moveDir, transform.right);
        animator.SetFloat("forwardSpeed", Forward);
        animator.SetFloat("rightSpeed", right);

        CharacterController.Move(Vector3.down * Time.deltaTime * 10f);

    }

    private void UpdateAim(Vector3 currentMoveDir)
    {
        Vector3 aimDir = currentMoveDir;

        if (aimInput.magnitude != 0)
        {
            aimDir = SITWD(aimInput);
        }
        rotateTowards(aimDir);
    }

    private void UpdateCamera()
    {
        if (moveInput.magnitude != 0 && aimInput.magnitude ==0&& camraControl != null)
        {      
                camraControl.AddYawInput(moveInput.x);           
        }
    }

    private void rotateTowards(Vector3 aimDir)
    {
        float currentTurnSpeed = 0;
        if (aimDir.magnitude != 0)
        {
            Quaternion prevRot = transform.rotation;
            float tuenLerpAlpha = turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(aimDir, Vector3.up), tuenLerpAlpha);
            Quaternion currerntRot = transform.rotation;
            float dir = Vector3.Dot(aimDir, transform.right) > 0 ? 1 : -1;
            float rotationDelta = Quaternion.Angle(prevRot, currerntRot) * dir;
             currentTurnSpeed = rotationDelta / Time.deltaTime;
        }
        animeyTurnSpeed = Mathf.Lerp(animeyTurnSpeed, currentTurnSpeed, Time.deltaTime * AnimationTurnSpeed);
        animator.SetFloat("turnSpeed", animeyTurnSpeed);
    }
}
