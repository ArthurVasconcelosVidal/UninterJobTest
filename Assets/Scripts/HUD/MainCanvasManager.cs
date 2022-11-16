using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour{
    public static MainCanvasManager instance;
    [SerializeField] Canvas mainCanvas;
    [SerializeField] NotificationManager notificationManager;

    public Canvas MainCanvas { get => mainCanvas; }
    public NotificationManager NotificationManager { get => notificationManager; }

    void Awake() {
        SingletonCreation();    
    }

    void SingletonCreation(){
        if(instance == null) instance = this;
        else Destroy(this);
    }
}
