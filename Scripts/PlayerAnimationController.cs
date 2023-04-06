using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator playerAnimator;

    // Start is called before the first frame update
    public void PlayAnimation(string animationName)
    {
        playerAnimator.Play(animationName);
    }
}
