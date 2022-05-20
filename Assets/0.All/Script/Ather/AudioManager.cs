using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    public void SEPlay(string sheet, string name, GameObject go, bool loop, float volume = 0)
    {
        CriAtomSource audio;
        if(!go.TryGetComponent<CriAtomSource>(out audio))
        {
            audio = go.AddComponent<CriAtomSource>();
        }
        audio.cueSheet = sheet;
        audio.cueName = name;
        audio.loop = loop;
        if(volume > 0)
        {
            audio.volume = volume;
        }
        else
        {
            audio.volume = 1;
        }
        audio.Play();
    }

    public void SEStop(GameObject go)
    {
        CriAtomSource audio;
        if (!go.TryGetComponent<CriAtomSource>(out audio))
        {
            audio = go.AddComponent<CriAtomSource>();
        }
        audio.Stop();
    }
    
    public void SEPause(GameObject go, bool isPause)
    {
        CriAtomSource audio;
        if (!go.TryGetComponent<CriAtomSource>(out audio))
        {
            audio = go.AddComponent<CriAtomSource>();
        }
        audio.Pause(isPause);
    }
}
