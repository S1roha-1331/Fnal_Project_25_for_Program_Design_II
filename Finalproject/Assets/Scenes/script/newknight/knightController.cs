using UnityEngine;

public class knightController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isWalk;

    private knightMovement knightMovement;
    private knightAnimator knightAnimator;
    void Start()
    {
        knightMovement = GetComponent<knightMovement>();
        knightAnimator = GetComponentInChildren<knightAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        isWalk = knightMovement.isMoving();
        knightAnimator.setWalking(isWalk);
    }
}
