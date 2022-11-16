using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public static PlayerManager instance;
    
    [SerializeField] MovementManager movementManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] GameObject meshObject;
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] GameObject holdObject;

    public MovementManager MovementManager { get => movementManager; }
    public InputManager InputManager { get => inputManager; }
    public GameObject MeshObject { get => meshObject; }
    public Rigidbody PlayerRigidbody { get => playerRigidBody; }
    public GameObject HoldObject { get => holdObject; }
    
    void Awake() {
        SingletonCreation();    
    }

    void SingletonCreation(){
        if(instance)
            Destroy(this);
        else
            instance = this;
    }
}
