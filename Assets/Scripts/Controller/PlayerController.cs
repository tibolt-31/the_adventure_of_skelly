using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 8;
    public float velocity = 0;
    public float turnSpeed = 10;
    public PlayerCombat playerCombat;

    Vector2 input;
    float angle;
    Quaternion targetRotation;
    Transform cam;

    CharacterController ch;
    PlayerAnimation playerAnimation;
    
    Vector3 moveDir;
    float timerAttack = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
        playerAnimation = new PlayerAnimation(GetComponent<Animator>());
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timerAttack += Time.deltaTime;

        if (FindObjectOfType<DialogManager>().isDialoguePlayed)
            return;
        GetInput();

        playerAnimation.PlayRunHorizontal(velocity);
        if ((Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) || playerCombat.isBlocking) return;

        CalculateDirection();
        Rotate();
        if (timerAttack < 0.3f || playerCombat.isBlocking)
            return;
        Move();
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            velocity = 0f;
            playerAnimation.PlayAttack();
            timerAttack = 0f;
        }

        if (input.x == 0 && input.y == 0)
        {
            velocity = 0;
        }
        else
        {
            velocity = maxSpeed;
        }
    }

    void Move()
    {
        moveDir = transform.forward * velocity;
        moveDir.y = moveDir.y + (Physics.gravity.y * 2 * Time.deltaTime);
        ch.Move(moveDir * Time.deltaTime);
    }

    public float GetTimeAttack()
    {
        return timerAttack;
    }
}
