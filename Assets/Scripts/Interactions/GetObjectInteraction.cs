using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GetObjectInteraction : InteractionBase{
    [SerializeField] Rigidbody objectRb;
    [SerializeField] Collider objectCollider;
    [SerializeField] float toHoldPointSpeed;
    [SerializeField] float throwForce;
    [SerializeField] float triggerCoolDownTime = 2;
    [SerializeField] bool isUsing = false;
    [SerializeField] bool canThrowTheObject = true; 
    [SerializeField] ItemAssetBase itemAsset;
    GameObject MeshObject { get => PlayerManager.instance.MeshObject; }
    GameObject HoldObject { get => PlayerManager.instance.HoldObject; }
    public bool CanThrowTheObject { get => canThrowTheObject; set => canThrowTheObject = value; }
    public ItemAssetBase ItemAsset { get => itemAsset; }

    protected override void ActionBehavior(){
        if (!isUsing){
            isUsing = true;
            triggerCollider.enabled = false;
            ToHoldPoint(HoldObject, toHoldPointSpeed);
            this.transform.SetParent(HoldObject.transform);
        }
    }

    protected override void CancelActionBehavior(){
        if(isUsing && canThrowTheObject){
            isUsing = false;
            this.transform.SetParent(null);
            ThrowObject(throwForce);
            CoolDownTrigger(triggerCoolDownTime);
        }
    }

    async void ToHoldPoint(GameObject point, float speed) {
        const float END_TIME = 1;
        float percent = 0;
        Vector3 startPosition = transform.position;
        objectRb.isKinematic = true;
        objectCollider.enabled = false;
        while (percent < END_TIME) {
            percent += speed * Time.fixedDeltaTime;
            transform.position = Vector3.Slerp(startPosition, point.transform.position, percent);
            await Task.Yield();
        }
    }

    void ThrowObject(float throwForce){
        const float FORWARD_FORCE = 4;
        objectRb.isKinematic = false;
        objectCollider.enabled = true;
        var direction = (MeshObject.transform.up + (MeshObject.transform.forward * FORWARD_FORCE)).normalized;
        objectRb.AddForce(direction * throwForce, ForceMode.Impulse);
    }
}
