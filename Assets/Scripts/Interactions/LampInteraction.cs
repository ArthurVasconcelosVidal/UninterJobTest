using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampInteraction : InteractionBase{
    [SerializeField] GameObject LightLamp;
    [SerializeField] GameObject NoLightLamp;
    [SerializeField] bool lampState = false;
    [SerializeField] float actionCoolDown = 2;
    protected override void ActionBehavior(){
        if (lampState){
            LightLamp.SetActive(false);
            NoLightLamp.SetActive(true);
        }else{
            LightLamp.SetActive(true);
            NoLightLamp.SetActive(false);
        }
        lampState = !lampState;
        CoolDownTrigger(actionCoolDown);
    }
}
