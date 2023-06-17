using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public enum Sfxs
{
    Fire1,
    Fire2,
    Build,
    Item,
    HitHQ

}

public enum Bgms
{
    Main,
    Stage
}


public class AudioManager : MonoSingleton<AudioManager>
{
    
    
    Dictionary<Sfxs, AudioClip> sfxsClips = new Dictionary<Sfxs, AudioClip>();
    Dictionary<Bgms, AudioClip> bgmsClips = new Dictionary<Bgms, AudioClip>();

    [SerializeField]private AudioSource bgmAudioSource;
    [SerializeField]private AudioSource sfxAudioSource;
    
    // �Ʒ��� �ܼ� ��� �������δ� �ʿ� ������ ���߿� �޸� ������ ����ȭ �Ҷ� ������ 
    //private List<AsyncOperationHandle<AudioClip>> handles = new List<AsyncOperationHandle<AudioClip>>();

    private void Start()
    {
        DontDestroyOnLoad(this);
        Init();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "GameLobby" :
                PlayBgm(Bgms.Main);
                break;
            case "DesingDevelop" :
                PlayBgm(Bgms.Stage);
                break;
        }
    }
    
    private void Init()
    {
        foreach(Sfxs s in Enum.GetValues(typeof(Sfxs)))
        {
            sfxsClips.Add(s, null);
        }
        foreach(Bgms b in Enum.GetValues(typeof(Bgms)))
        {
            bgmsClips.Add(b, null);
        }
    }
    
    public void PlaySfx(Sfxs _playSfx, Transform _playTrs = null)
    {
        if (sfxsClips[_playSfx] == null)
        {
            sfxsClips[_playSfx] = LoadAssetClip("Sfx/" + _playSfx.ToString());
        }

        if (_playTrs == null)
            _playTrs = Camera.main.transform;
        
        AudioSource.PlayClipAtPoint(sfxsClips[_playSfx], _playTrs.position);
    }

    public void PlayBgm(Bgms _playBgm)
    {
        if (bgmsClips[_playBgm] == null)
        {
            bgmsClips[_playBgm] = LoadAssetClip("Bgm/" + _playBgm.ToString());
        }
        bgmAudioSource.Stop();
        bgmAudioSource.clip = bgmsClips[_playBgm];
        bgmAudioSource.Play();
    }
    // ���� �ҷ�����
    private AudioClip LoadAssetClip(string _loadName)
    {
        AudioClip clip = null;
        AsyncOperationHandle<AudioClip> handle;

        handle = Addressables.LoadAssetAsync<AudioClip>(_loadName);
        clip = handle.WaitForCompletion(); // ��������� �ҷ�����
        return clip;
    }
}
