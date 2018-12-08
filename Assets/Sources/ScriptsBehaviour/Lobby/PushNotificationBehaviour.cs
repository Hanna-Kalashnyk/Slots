using System;
using Assets.Libraries.SimpleAndroidNotifications;
using UnityEngine;

public class PushNotificationBehaviour : MonoBehaviour
{
	private static PushNotificationBehaviour _instance;

	void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else if (_instance != this)
		{
			Destroy(this);
		}
	}

	void Start()
	{
#if UNITY_IOS
		// Subscribe On IOS Notifications
		UnityEngine.iOS.NotificationServices.RegisterForNotifications(
			UnityEngine.iOS.NotificationType.Alert |
			UnityEngine.iOS.NotificationType.Badge |
			UnityEngine.iOS.NotificationType.Sound);
#endif
	}

	void OnApplicationPause(bool pauseStatus)
	{
#if UNITY_ANDROID
		if (pauseStatus)
		{
            NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(Constants.PUSH_NOTIFICATIONS_REPEAT_TIME), Constants.PUSH_NOTIFICATIONS_TITLE,
				Constants.PUSH_NOTIFICATIONS_BODY, new Color(0, 0.6f, 1), NotificationIcon.Message);
		}
		else
		{
			NotificationManager.CancelAll();
		}
#elif UNITY_IOS
		if (pauseStatus)
		{
			var notification = new UnityEngine.iOS.LocalNotification
			{
				fireDate = DateTime.Now.AddSeconds(Constants.PUSH_NOTIFICATIONS_REPEAT_TIME),
				alertAction = Constants.PUSH_NOTIFICATIONS_TITLE,
				alertBody = Constants.PUSH_NOTIFICATIONS_BODY
			};
		
			UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notification);
		}
		else
		{
			UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();
		}
#endif
	}
}