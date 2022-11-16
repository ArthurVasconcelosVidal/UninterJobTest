using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class NotificationManager : MonoBehaviour{
    [SerializeField] Canvas notificationCanvas;
    [SerializeField] Text notificationTxT;
    [SerializeField] GameObject notificationPanel;
    
    public Canvas NotificationCanvas { get => notificationCanvas; }

    public void ShowNotification(string notificationText, float time = 3){
        notificationTxT.text = notificationText;
        ShowNotificationPanel(time);
    }

    async void ShowNotificationPanel(float time){
        const int MILLISECONDS_CONVERSION = 1000;
        notificationCanvas.gameObject.SetActive(true);
        await Task.Delay((int)(time * MILLISECONDS_CONVERSION));
        notificationCanvas.gameObject.SetActive(false);
    }
}
