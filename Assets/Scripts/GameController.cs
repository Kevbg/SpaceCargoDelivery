using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
    private ScreenFader fader;
    public static GameController current;
    public bool gamePaused { get; private set; }
    public string saveFilePath { get; private set; }
    public float aspectRatio { get; private set; }
    public float screenWidth { get; private set; }
    public float screenHeight { get; private set; }
    public enum Languages {
        english,
        portuguese
    }

    // Variáveis globais
    public static float sfxVolume;
    public static float bgmVolume;
    public static Languages language;

    void Awake() {
        if (current == null) {
            DontDestroyOnLoad(gameObject);
            current = this;

            fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            aspectRatio = (float)Screen.width / (float)Screen.height;
            screenWidth = (Camera.main.orthographicSize * 2) * aspectRatio;
            screenHeight = Camera.main.orthographicSize * 2;

            saveFilePath = Application.persistentDataPath + "/SCDPrefs.dat";
            Load();
        } else if (current != this) {
            Destroy(gameObject);
        }
    }

    public IEnumerator ExitGame(float fadeOutDuration) {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        GameObject bgm = GameObject.FindGameObjectWithTag("BGM");

        if (bgm != null) {
            bgm.GetComponent<BGMControl>().FadeOut(fadeOutDuration);
        }

        sf.FadeOut(fadeOutDuration);

        yield return new WaitForSeconds(fadeOutDuration);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(saveFilePath);
        Preferences prefs = new Preferences();

        prefs.sfxVolume = sfxVolume;
        prefs.bgmVolume = bgmVolume;
        prefs.language = language;

        bf.Serialize(fs, prefs);
        fs.Close();
    }

    public void Load() {
        if (File.Exists(saveFilePath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(saveFilePath, FileMode.Open);
            Preferences prefs = (Preferences)bf.Deserialize(fs);
            fs.Close();

            sfxVolume = prefs.sfxVolume;
            bgmVolume = prefs.bgmVolume;
            language = prefs.language;
        } else {
            // Valores padrão
            sfxVolume = 1;
            bgmVolume = 1;
            language = Languages.english;

            throw new FileNotFoundException("Could not load prefs file", saveFilePath);
        }
    }

    public void Pause() {
        Time.timeScale = 0;
        gamePaused = true;
        fader.QuickFadeOut();
    }

    public void Resume() {
        Time.timeScale = 1;
        gamePaused = false;
        fader.QuickFadeIn();
    }

    void OnApplicationQuit() {
        Save();
    }
}

[Serializable]
class Preferences {
    internal float sfxVolume;
    internal float bgmVolume;
    internal GameController.Languages language;
}
