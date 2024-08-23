using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutriggerAnim : MonoBehaviour
{
    //public ForkMovement forkMovement;
   // public float forkMove;
    public Animator animator;
    public string knuckleAnimName = "Forklift_Up";
    public float animSpeed = 1f;
   // public Transform colliderTransform;
  //  public float movementPerFrame = 0.01f;

   // public float minYPosition = 0f;
  //  public float maxYPosition = 10f;

    private float currentFrame = 0f; 
    public float totalFrames = 95;
    private float direction = 0f;

    void Update()
    {
       // forkMove = forkMovement.forkValue;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("1");
            direction = 1f;
            currentFrame += direction * animSpeed * Time.deltaTime * (totalFrames / animator.GetCurrentAnimatorStateInfo(0).length);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("2");
            direction = -1f;
            currentFrame += direction * animSpeed * Time.deltaTime * (totalFrames / animator.GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            Debug.Log("0");
            direction = 0f;
        }

        currentFrame = Mathf.Clamp(currentFrame, 0f, totalFrames);

        PlayAnimation(currentFrame);
    //    MoveCollider(currentFrame);
    }

    private void PlayAnimation(float frame)
    {
        animator.Play(knuckleAnimName, 0, frame / totalFrames);
    }

  //  private void MoveCollider(float frame)
  // {
  //      float moveY = direction * movementPerFrame * Time.deltaTime;
  //
  //      Vector3 newLocalPosition = colliderTransform.localPosition + new Vector3(0f, moveY, 0f);
  //      newLocalPosition.y = Mathf.Clamp(newLocalPosition.y, minYPosition, maxYPosition);
  //
  //      colliderTransform.localPosition = newLocalPosition;
  //  }
}
