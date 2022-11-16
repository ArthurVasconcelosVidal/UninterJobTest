using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DoorInteraction : InteractionBase{
    bool alreadyOpen = false;
    [SerializeField] bool openToInside;
    [SerializeField] Animator doorAnimator;
    protected override void ActionBehavior(){
        if (!alreadyOpen){
            alreadyOpen = true;
            UseTheKeyToUnlock();
        }
    }

    void UseTheKeyToUnlock(){
        doorAnimator.Play(DoorAnimations.UnlockWithKey.ToString());
    }

    void OpenDoor(){
        //Called by UnlockWithKey animation
        if (openToInside) doorAnimator.Play(DoorAnimations.DoorOpenToInside.ToString());
        else doorAnimator.Play(DoorAnimations.DoorOpenToOutside.ToString());
    }

}
