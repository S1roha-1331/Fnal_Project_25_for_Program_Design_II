using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private PlayerInputActions inputActions;
    private Camera mainCam;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        // 移動輸入
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        // 滑鼠 Look
        inputActions.Player.Lookmouse.performed += ctx =>
        {
            if (mainCam == null) return;
            Vector2 mouseScreenPos = ctx.ReadValue<Vector2>();
            Vector2 worldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
            lookInput = worldPos - (Vector2)transform.position;
        };
        inputActions.Player.Lookmouse.canceled += ctx => lookInput = Vector2.zero;

        // 搖桿 Look
        inputActions.Player.Lookstick.performed += ctx =>
        {
            lookInput = ctx.ReadValue<Vector2>();
        };
        inputActions.Player.Lookstick.canceled += ctx => lookInput = Vector2.zero;
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        mainCam = Camera.main;
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
