using UnityEngine;

public class EOTAnimGrab : MonoBehaviour
{
    public EOTMovement allMovement;
    public float eotMove;
    public Animator animator;
    public string allAnimName = "Forklift_Up";
    public float animSpeed = 1f;
    public int animationLayer = 1; // Set this to the layer index of your animation

    public float button2 = 0;
    public float buttonValue;

    private float currentFrame = 0f;
    private float totalFrames;
    private float direction = 0f;

    void Start()
    {
        // Calculate total frames based on the clip's length and frame rate for the specified layer
        AnimationClip animClip = animator.runtimeAnimatorController.animationClips[animationLayer];
        totalFrames = animClip.length * animClip.frameRate;
    }

    void Update()
    {
        eotMove = allMovement.eotValue;
        button2 = allMovement.button2Value;
        if (eotMove > 0 && button2 == buttonValue)
        {
            direction = 1f;
            currentFrame += direction * animSpeed * Time.deltaTime * (totalFrames / animator.GetCurrentAnimatorStateInfo(animationLayer).length);
        }
        else if (eotMove < 0 && button2 == buttonValue)
        {
            direction = -1f;
            currentFrame += direction * animSpeed * Time.deltaTime * (totalFrames / animator.GetCurrentAnimatorStateInfo(animationLayer).length);
        }
        else
        {
            direction = 0f;
        }

        currentFrame = Mathf.Clamp(currentFrame, 0f, totalFrames);

        PlayAnimation(currentFrame);
    }

    private void PlayAnimation(float frame)
    {
        animator.Play(allAnimName, animationLayer, frame / totalFrames);
    }
}
