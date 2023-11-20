using Microsoft.Maui;
public class DeviceOrientationService
{
    public void SetOrientation()
    {
#if ANDROID
        Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.RequestedOrientation =
            Android.Content.PM.ScreenOrientation.Portrait;
#endif
    }

    public void ResetOrientation()
    {
#if ANDROID
        Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.RequestedOrientation =
            Android.Content.PM.ScreenOrientation.User;
#endif
    }
}