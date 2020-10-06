using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSettings : MonoBehaviour
{
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            if (!PlayerPrefs.HasKey("Orientation"))
                PlayerPrefs.SetInt("Orientation", 0);

            if (PlayerPrefs.GetInt("Orientation") == 0)
                Screen.orientation = ScreenOrientation.LandscapeRight;
            else
                Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            if (Display.displays.Length > 1)
            {
                Display.displays[1].Activate();
            }
        }

        SceneManager.LoadScene("Menu");
    }
}
