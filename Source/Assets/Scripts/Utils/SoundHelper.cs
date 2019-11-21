using UnityEngine;

public class SoundHelper : MonoBehaviour
{
    private static int buttonSoundID;
    private static int musicID;
    private static int insectSoundID;
    private static int rainSoundID;
    private static int windSoundID;

    private void Start()
    {
        AndroidNativeAudio.makePool(16);

        musicID = ANAMusic.load("melody.ogg");
        ANAMusic.setLooping(musicID, true);
        ANAMusic.setVolume(musicID, 0.5f);
        ANAMusic.play(musicID);

        buttonSoundID = AndroidNativeAudio.load("button.ogg");
        insectSoundID = AndroidNativeAudio.load("insect.mp3");

        rainSoundID = ANAMusic.load("rain.mp3");
        windSoundID = ANAMusic.load("wind.mp3");
    }

    //Play sounds
    public static void PlayButtonSound()
    {
        AndroidNativeAudio.play(buttonSoundID);
    }

    public static void PlayInsectSound()
    {
        AndroidNativeAudio.play(insectSoundID);
    }

    public static void PlayRainSound()
    {
        ANAMusic.setLooping(rainSoundID, true);
        ANAMusic.play(rainSoundID);
    }

    public static void PlayWindSound()
    {
        ANAMusic.setLooping(windSoundID, true);
        ANAMusic.play(windSoundID);
    }

    //Stop sounds
    public static void StopRainSound()
    {
        if (ANAMusic.isPlaying(rainSoundID))
            ANAMusic.pause(rainSoundID);
    }

    public static void StopWindSound()
    {
        if (ANAMusic.isPlaying(windSoundID))
            ANAMusic.pause(windSoundID);
    }
}
