using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour{

    InputManager PlayerInput { get => PlayerManager.instance.InputManager; }
    Rigidbody PlayerRigidbody { get => PlayerManager.instance.PlayerRigidbody; }
    GameObject MeshObject { get => PlayerManager.instance.MeshObject; }
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    void FixedUpdate(){
        float stickMag = PlayerInput.StickValue.SqrMagnitude();
        if (PlayerInput.StickValue.x != 0) SelfRotation(PlayerInput.StickValue.x, stickMag, rotationSpeed);
        if (PlayerInput.StickValue.y != 0) Movement(PlayerInput.StickValue.y, stickMag, moveSpeed);
    }

    void Movement(float uniDirection, float stickMag, float movementSpeed){
        float finalDirectionValue = UniDirectionNormalizer(uniDirection);
        finalDirectionValue = finalDirectionValue * (stickMag * movementSpeed) * Time.fixedDeltaTime;
        PlayerRigidbody.MovePosition(transform.position + MeshObject.transform.forward * finalDirectionValue);
    }

    void SelfRotation(float uniDirection, float stickMag, float rotationSpeed){
        float finalDirectionValue = UniDirectionNormalizer(uniDirection);
        finalDirectionValue = finalDirectionValue * stickMag * rotationSpeed;
        Vector3 newRotation = new Vector3(0f,finalDirectionValue,0f); 
        MeshObject.transform.Rotate(newRotation);
    }

    float UniDirectionNormalizer(float uniDirection) => uniDirection > 0 ? 1 : -1;
}
