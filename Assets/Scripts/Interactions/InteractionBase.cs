using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public abstract class InteractionBase : MonoBehaviour{
    protected InputManager PlayerInput { get => PlayerManager.instance.InputManager; }
    [SerializeField] protected Collider triggerCollider;
    protected abstract void ActionBehavior(); //Obligatory function
    protected virtual void CancelActionBehavior() {} //Optional function
    void OnAction(object sender, InputAction.CallbackContext buttonContext) => ActionBehavior();
    void OnCanceledAction(object sender, InputAction.CallbackContext buttonContext) => CancelActionBehavior();
     
    protected async void CoolDownTrigger(float coolDownTime){
        PlayerInput.OnActionButtonPerformed -= OnAction;
        triggerCollider.enabled = false;
        const int MILLISECONDS_CONVERSION = 1000;
        await Task.Delay((int)(coolDownTime * MILLISECONDS_CONVERSION));
        triggerCollider.enabled = true;
    }

    protected void SubscribeActions(bool state) {
        if (state){
            PlayerInput.OnActionButtonPerformed += OnAction;
            PlayerInput.OnCancelActionButtonPerformed += OnCanceledAction;
        }else{
            PlayerInput.OnActionButtonPerformed -= OnAction;
            PlayerInput.OnCancelActionButtonPerformed -= OnCanceledAction;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(GameTags.Player.ToString()) )
            SubscribeActions(true);
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag(GameTags.Player.ToString()))
            SubscribeActions(false);
    }
}
