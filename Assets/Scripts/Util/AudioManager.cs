using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;
public enum Sfxs
{
    Fire1,
    Fire2,
    Build,
    HitHQ
}

public enum Bgms
{
    Main
}


public class AudioManager : MonoSingleton<AudioManager>
{
    
    
    Dictionary<Sfxs, AudioClip> sfxsClips = new Dictionary<Sfxs, AudioClip>();
    Dictionary<Bgms, AudioClip> bgmsClips = new Dictionary<Bgms, AudioClip>();

    [SerializeField]private AudioSource bgmAudioSource;
    [SerializeField]private AudioSource sfxAudioSource;
    
    // 아래는 단순 기능 구현으로는 필요 없지만 나중에 메모리 해제등 최적화 할때 쓸수도 
    //private List<AsyncOperationHandle<AudioClip>> handles = new List<AsyncOperationHandle<AudioClip>>();

    private void Start()
    {
        Init();
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

        float volume = 1;
        // 메인메뉴의 SoundOption 스크립트에서 볼륨을 변경해줘야 반영되는 값이라 메인메뉴 안가면 사운드가 재생이 안됨
        // float volume;
        // sfxAudioSource.outputAudioMixerGroup.audioMixer.GetFloat("SFX", out volume);
        // Debug.Log(volume);
        AudioSource.PlayClipAtPoint(sfxsClips[_playSfx], _playTrs.position, volume);
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
    // 에셋 불러오기
    private AudioClip LoadAssetClip(string _loadName)
    {
        AudioClip clip = null;
        AsyncOperationHandle<AudioClip> handle;

        handle = Addressables.LoadAssetAsync<AudioClip>(_loadName);
        clip = handle.WaitForCompletion(); // 동기식으로 불러오기
        return clip;
    }
}
