using UnityEngine;
using UnityEngine.InputSystem;

<<<<<<< Updated upstream:Finalproject/Assets/Scenes/NewBehaviourScript.cs
public class PlayerController : MonoBehaviour
=======
public class playController : MonoBehaviour
>>>>>>> Stashed changes:Finalproject/Assets/script/playerController.cs
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 翻轉角色圖像
        if (moveInput.x < 0)
            sr.flipX = true;
        else if (moveInput.x > 0)
            sr.flipX = false;

        // 控制動畫播放
        animator.SetBool("isWalking", moveInput != Vector2.zero);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    public Vector2 GetAttackDirection()
    {
        return lookInput.normalized;
    }
}
