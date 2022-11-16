using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DoorInteraction : InteractionBase{
    bool alreadyOpen = false;
    [SerializeField] bool openToInside;
    [SerializeField] Animator doorAnimator;
    [SerializeField] GameObject keyObject;
    protected override void ActionBehavior(){
        if (!alreadyOpen && keyObject){
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

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(GameTags.Key.ToString())){
            keyObject = other.gameObject;
            keyObject.GetComponent<GetObjectInteraction>().CanThrowTheObject = false;
        }    
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag(GameTags.Key.ToString())){
            keyObject = null;
            keyObject.GetComponent<GetObjectInteraction>().CanThrowTheObject = true;
        } 
    }

}
