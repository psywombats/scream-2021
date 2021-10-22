﻿using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;

public class AudioManager : SingletonBehavior {

    public static AudioManager Instance => Global.Instance.Audio;

    private EventInstance bgmEvent;

    public const string NoBGMKey = "none";
    private const string NoChangeBGMKey = "no_change";
    private const float FadeSeconds = 0.5f;

    private float baseVolume = 1.0f;
    private float bgmVolumeMult = 1.0f;
    private Setting<float> bgmVolumeSetting;
    private Setting<float> sfxVolumeSetting;

    public string CurrentBGMKey { get; private set; }

    private EventInstance sfxEvent;

    public void Start() {
        CurrentBGMKey = NoBGMKey;
        sfxVolumeSetting = Global.Instance.Serialization.SystemData.SettingSoundEffectVolume;
        bgmVolumeSetting = Global.Instance.Serialization.SystemData.SettingMusicVolume;
        SetVolume();
        sfxVolumeSetting.OnModify += SetVolume;
        bgmVolumeSetting.OnModify += SetVolume;
    }

    public void PlayBGM(string key) {
        if (Global.Instance.Data.GetSwitch("disable_bgm")) {
            return;
        }
        if (key != CurrentBGMKey && key != NoChangeBGMKey && key != null && key.Length > 0) {
            if (bgmEvent.hasHandle()) {
                bgmEvent.stop(STOP_MODE.ALLOWFADEOUT);
                bgmEvent.clearHandle();
            }
            baseVolume = 1f;
            SetVolume();
            CurrentBGMKey = key;
            bgmEvent = RuntimeManager.CreateInstance($"event:/BGM/{key}");
            bgmEvent.start();
        }
    }

    public void PlaySFX(string sfxKey) {
        sfxEvent = RuntimeManager.CreateInstance($"event:/SFX/{sfxKey}");
        sfxEvent.start();
    }

    public void StopSFX() {
        sfxEvent.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void SetVolume() {
        var sfxBus = RuntimeManager.GetBus("bus:/SFX");
        var bgmBus = RuntimeManager.GetBus("bus:/BGM");
        sfxBus.setVolume(sfxVolumeSetting.Value * baseVolume);
        bgmBus.setVolume(bgmVolumeSetting.Value * baseVolume);
    }

    public IEnumerator FadeOutRoutine(float durationSeconds) {
        CurrentBGMKey = NoBGMKey;
        while (baseVolume > 0.0f) {
            baseVolume -= Time.deltaTime / durationSeconds;
            if (baseVolume < 0.0f) {
                baseVolume = 0.0f;
            }
            SetVolume();
            yield return null;
        }
        baseVolume = 1.0f;
        PlayBGM(NoBGMKey);
    }

    public IEnumerator CrossfadeRoutine(string tag) {
        if (CurrentBGMKey != null && CurrentBGMKey != NoBGMKey) {
            yield return FadeOutRoutine(FadeSeconds);
        }
        PlayBGM(tag);
    }

    private IEnumerator MuteRoutine(float muteDuration) {
        muteDuration += 0.2f;
        bgmVolumeMult = 0.0f;
        SetVolume();
        yield return CoUtils.Wait(muteDuration - 0.2f);
        var elapsed = 0.0f;
        while (elapsed < 0.2f) {
            elapsed += Time.deltaTime;
            bgmVolumeMult = elapsed / 0.2f;
            SetVolume();
            yield return null;
        }
        bgmVolumeMult = 1.0f;
    }
}
