using UnityEngine;

public class ForkLiftAnim : MonoBehaviour
{
    public forkMovement allMovement;
    public float forkMove;
    public Animator animator;
    public string forkliftAnimName = "Forklift_Up";
    public float animSpeed = 1f;
    public Transform colliderTransform;
    public float movementPerFrame = 0.01f;

    public float minYPosition = 0f;
    public float maxYPosition = 10f;

    private float currentFrame = 0f;
    public float totalFrames = 100f;
    private float direction = 0f;

    void Update()
    {
        forkMove = allMovement.forkValue;
        if (forkMove > 0)
        {
            direction = 1f;
            currentFrame += direction * animSpeed * Time.deltaTime * (totalFrames / animator.GetCurrentAnimatorStateInfo(0).length);
        }
        else if (forkMove < 0)
        {
            direction = -1f;
            currentFrame += direction * animSpeed * Time.deltaTime * (totalFrames / animator.GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            direction = 0f;
        }

        currentFrame = Mathf.Clamp(currentFrame, 0f, totalFrames);

        PlayAnimation(currentFrame);
        MoveCollider(currentFrame);
    }

    private void PlayAnimation(float frame)
    {
        animator.Play(forkliftAnimName, 0, frame / totalFrames);
    }

    private void MoveCollider(float frame)
    {
        float moveY = direction * movementPerFrame * Time.deltaTime;

        Vector3 newLocalPosition = colliderTransform.localPosition + new Vector3(0f, moveY, 0f);
        newLocalPosition.y = Mathf.Clamp(newLocalPosition.y, minYPosition, maxYPosition);

        colliderTransform.localPosition = newLocalPosition;
    }
}
