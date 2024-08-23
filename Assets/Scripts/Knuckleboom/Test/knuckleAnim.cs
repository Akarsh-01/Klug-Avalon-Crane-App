using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knuckleAnim : MonoBehaviour
{
    public Animator animator;
    public List<string> allAnimNames = new List<string>(); // List to store animation names
    public float animSpeed = 1f;

    private float currentFrame = 0f;
    private float direction = 0f;
    private int currentAnimIndex = 0; // Index to keep track of the current animation
    private float totalFrames; // Total frames for the current animation

    void Start()
    {
        UpdateTotalFrames(); // Initialize totalFrames for the first animation
    }

    void Update()
    {
        if (currentAnimIndex < allAnimNames.Count)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = 1f;
                currentFrame += direction * animSpeed * Time.deltaTime * totalFrames / animator.runtimeAnimatorController.animationClips[currentAnimIndex].length;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = -1f;
                currentFrame += direction * animSpeed * Time.deltaTime * totalFrames / animator.runtimeAnimatorController.animationClips[currentAnimIndex].length;
            }
            else
            {
                direction = 0f;
            }

            currentFrame = Mathf.Clamp(currentFrame, 0f, totalFrames);

            if (currentFrame >= totalFrames)
            {
                if (currentAnimIndex < allAnimNames.Count - 1)
                {
                    currentFrame = 0f;
                    currentAnimIndex++;
                    UpdateTotalFrames(); // Update totalFrames for the new animation
                }
                else
                {
                    currentFrame = totalFrames; // Stop at the last frame of the last animation
                }
            }

            PlayAnimation(currentFrame);
        }
    }

    private void PlayAnimation(float frame)
    {
        animator.Play(allAnimNames[currentAnimIndex], 0, frame / totalFrames);
    }

    private void UpdateTotalFrames()
    {
        // Get the current animation clip by name
        AnimationClip currentClip = animator.runtimeAnimatorController.animationClips[currentAnimIndex];

        // Calculate totalFrames based on the length of the current animation clip in seconds
        totalFrames = currentClip.length * 60f; // Assuming 60 FPS, adjust if needed
    }
}
