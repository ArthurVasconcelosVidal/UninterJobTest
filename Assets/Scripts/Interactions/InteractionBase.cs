using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public abstract class InteractionBase : MonoBehaviour{
    protected InputManager PlayerInput { get => PlayerManager.instance.InputManager; }
    [SerializeField] protected Collider triggerCollider;
    
    protected abstract void ActionBehavior();

    protected async void CoolDownTrigger(float coolDownTime){
        PlayerInput.OnActionButtonPerformed -= OnAction;
        triggerCollider.enabled = false;
        const int MILLISECONDS_CONVERSION = 1000;
        await Task.Delay((int)(coolDownTime * MILLISECONDS_CONVERSION));
        triggerCollider.enabled = true;
    }

    void OnAction(object sender, InputAction.CallbackContext buttonContext) {
        ActionBehavior();
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(GameTags.Player.ToString()) )
            PlayerInput.OnActionButtonPerformed += OnAction;
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag(GameTags.Player.ToString()))
            PlayerInput.OnActionButtonPerformed -= OnAction;
    }
}
