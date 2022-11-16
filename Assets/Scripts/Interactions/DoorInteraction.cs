using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DoorInteraction : InteractionBase{
    PlayerManager PlayerManager { get => PlayerManager.instance; }
    NotificationManager NotificationManager { get => MainCanvasManager.instance.NotificationManager; }
    AudioManager AudioManager { get => AudioManager.instance; }
    bool alreadyOpen = false;
    [SerializeField] bool openToInside;
    [SerializeField] Animator doorAnimator;
    [SerializeField] ItemAssetBase keyToOpenDoor;
    GameObject keyObject;
    protected override void ActionBehavior(){
        if (!alreadyOpen && VerifyTheKey()){
            alreadyOpen = true;
            UseTheKeyToUnlock();
        }else if(!alreadyOpen){
            AudioManager.PlayAudio(SoundList.DoorLocked);
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

    void KeyMeshToggle(){
        //Called by UnlockWithKey animation
        if (PlayerManager.HoldObject.activeSelf){
            PlayerManager.HoldObject.SetActive(false);
        }
        else
            PlayerManager.HoldObject.SetActive(true);
    }

    void OpenDoor(){
        //Called by UnlockWithKey animation
        if (openToInside) doorAnimator.Play(DoorAnimations.DoorOpenToInside.ToString());
        else doorAnimator.Play(DoorAnimations.DoorOpenToOutside.ToString());
        AudioManager.PlayAudio(SoundList.DoorSqueak);
        NotificationManager.ShowNotification("A porta está aberta");
    }

    void PlayUnlockSound(){
        AudioManager.PlayAudio(SoundList.DoorUnlock);
    }
}
