using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimationManager : MonoBehaviour
{
    public GameObject button;
    public Vector3 shrinkSize, enlargeSize;
    public float animationDuration;
    public Vector3 finalPositon;
    public Vector3 initialPositon;
    public Ease easing;
    public Vector3 rotation;
    public void ShrinkUI()
    {
        button.transform.DOScale(shrinkSize,animationDuration).OnComplete(() => button.transform.DOScale(Vector3.one, animationDuration));
    }
    public void EnlargeUI()
    {
        button.transform.DOScale(enlargeSize, animationDuration);
    }
    public void MoveButton()
    {
        //move = vector 3 end value, animation duration 
        button.transform.DOLocalMove(finalPositon, animationDuration).SetEase(easing).OnComplete(()=> ReversePositionButton());
    }
    public void ReversePositionButton()
    {
        button.transform.DOLocalMove(initialPositon, animationDuration).SetEase(easing).OnComplete(() => MoveButton());
    }
    public void ShakeButton()
    {
        //float duration, strength = 1 min, vibrato = 10 min, randomness = 90 max
        button.transform.DOShakePosition(5,600,10,90);
        button.transform.DOShakeScale(5, 600, 10, 90);
    }
    public void FadeButton()
    {
        Image colorButton;
        colorButton = button.GetComponent<Image>();
        colorButton.DOFade(0,animationDuration);
    }
    public void RotateButton()
    {
        //Fast
        //FastBeyond360
        //WorldAxisAdd
        //LocalAxisAdd
        button.transform.DOLocalRotate(rotation,5,RotateMode.FastBeyond360);
    }
    public void JumpButton()
    {
        //jump = vector 3 emd position, float jump power, int number of jumps, float duration
        button.transform.DOLocalJump(finalPositon,8.5f, 2,3);
    }
}
