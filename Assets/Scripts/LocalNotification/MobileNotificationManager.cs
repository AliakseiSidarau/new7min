using System;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotificationManager : MonoBehaviour
{
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        
        var channel = new AndroidNotificationChannel()
        {
            Id = "main",
            Name = "Main Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        
        var notification = new AndroidNotification();
        notification.Title = "Hey! Open App!";
        notification.Text = "Open and improve your code =)";
        notification.FireTime = System.DateTime.Now.AddMinutes(5);

        var id = AndroidNotificationCenter.SendNotification(notification, "main");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllDisplayedNotifications();
            AndroidNotificationCenter.SendNotification(notification, "main");
        }
    }
}
