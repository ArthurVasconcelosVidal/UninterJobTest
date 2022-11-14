using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public static PlayerManager instance;
    
    [SerializeField] MovementManager movementManager;
    [SerializeField] InputManager inputManager;

    public MovementManager MovementManager { get => movementManager; }
    public InputManager InputManager { get => inputManager; }

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
