using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DoorInteraction : InteractionBase{
    PlayerManager PlayerManager { get => PlayerManager.instance; }
    NotificationManager NotificationManager { get => MainCanvasManager.instance.NotificationManager; }
    bool alreadyOpen = false;
    [SerializeField] bool openToInside;
    [SerializeField] Animator doorAnimator;
    [SerializeField] ItemAssetBase keyToOpenDoor;
    protected override void ActionBehavior(){
        if (!alreadyOpen && VerifyTheKey()){
            alreadyOpen = true;
            UseTheKeyToUnlock();
        }
    }

    bool VerifyTheKey(){
        if(PlayerManager.HoldObject.transform.childCount == 0)
            return false;

        ItemAssetBase playerObject = PlayerManager.HoldObject.GetComponentInChildren<GetObjectInteraction>().ItemAsset;

        if (playerObject != null && playerObject == keyToOpenDoor)
            return true;
        else 
            return false;
    }

    void UseTheKeyToUnlock(){
        doorAnimator.Play(DoorAnimations.UnlockWithKey.ToString());
    }

    void OpenDoor(){
        //Called by UnlockWithKey animation
        if (openToInside) doorAnimator.Play(DoorAnimations.DoorOpenToInside.ToString());
        else doorAnimator.Play(DoorAnimations.DoorOpenToOutside.ToString());
        NotificationManager.ShowNotification("A porta está aberta");
    }

}
