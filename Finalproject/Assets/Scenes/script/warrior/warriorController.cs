using UnityEngine;

public class warriorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isWalk;

    private warriorMovement warriorMovement;
    private warriorAnimator warriorAnimator;
    void Start()
    {
        warriorMovement = GetComponent<warriorMovement>();
        warriorAnimator = GetComponentInChildren<warriorAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        isWalk = warriorMovement.isMoving();
        warriorAnimator.setWalking(isWalk);
    }
}
