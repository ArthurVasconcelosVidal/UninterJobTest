using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class EndGameButtonInteraction : InteractionBase{
    NotificationManager NotificationManager { get => MainCanvasManager.instance.NotificationManager; }
    [SerializeField] float timeToRestart;
    protected override void ActionBehavior(){
        triggerCollider.enabled = false;
        SubscribeActions(false);
        RestartScene(timeToRestart);
    }

    async void RestartScene(float timeToRestart){
        NotificationManager.ShowNotification($"Você finalizou o teste. O nivel irá reiniciar em {timeToRestart} segundos");
        const int MILLISECONDS_CONVERSION = 1000;
        await Task.Delay((int)(timeToRestart * MILLISECONDS_CONVERSION));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
