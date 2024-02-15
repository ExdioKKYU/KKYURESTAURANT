using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio_controller : MonoBehaviour
{
    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] private Slider m_MusicMasterSlider;
    [SerializeField] private Slider m_MusicBGMSlider;
    [SerializeField] private Slider m_MusicSFXSlider;
    [SerializeField] private Slider m_MusicSkill_VoiceSlider;

    private bool BGM_Muted = true; // 음소거 상태를 나타내는 변수
    private bool SFX_Muted = true;
    private bool Skill_Voice_Muted = true;

    private void Awake()
    {
        //m_MusicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        m_MusicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        m_MusicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
        m_MusicSkill_VoiceSlider.onValueChanged.AddListener(SetSkill_VoiceVolume);
    }

    void Update()
    {
        if (m_MusicBGMSlider.value > 0.001f)
        {
            BGM_Muted = true;
        }
        if (m_MusicSFXSlider.value > 0.001f)
        {
            SFX_Muted = true;
        }
        if (m_MusicSkill_VoiceSlider.value > 0.001f)
        {
            Skill_Voice_Muted = true;
        }

        if (m_MusicBGMSlider.value <= 0.001f)
        {
            BGM_Muted = false;
        }
        if (m_MusicSFXSlider.value <= 0.001f)
        {
            SFX_Muted = false;
        }
        if (m_MusicSkill_VoiceSlider.value <= 0.001f)
        {
            Skill_Voice_Muted = false;
        }
    }

    public void SetMasterVolume(float volume)
    {
        m_AudioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetBGMVolume(float volume)
    {
        m_AudioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        m_AudioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SetSkill_VoiceVolume(float volume)
    {
        m_AudioMixer.SetFloat("Skill_Voice", Mathf.Log10(volume) * 20);
    }


    public void Toggle_BGM_Mute()
    {
        // 현재 음소거 상태에 따라 동작 결정
        if (BGM_Muted) // 음소거가 아닌 경우
        {
            // 볼륨을 -80으로 설정하여 최소로 만듦 (음소거 상태)
            m_AudioMixer.SetFloat("BGM", -80f);
            m_MusicBGMSlider.value = 0f;
            BGM_Muted = false; // 음소거 상태로 변경
        }
        else // 음소거인 경우
        {
            // 볼륨을 이전 값으로 복원
            m_AudioMixer.SetFloat("BGM", 0f);
            m_MusicBGMSlider.value = 0.5f;
            BGM_Muted = true; // 음소거 상태 해제
        }
    }

    public void Toggle_SFX_Mute()
    {
        // 현재 음소거 상태에 따라 동작 결정
        if (SFX_Muted) // 음소거가 아닌 경우
        {
            // 볼륨을 -80으로 설정하여 최소로 만듦 (음소거 상태)
            m_AudioMixer.SetFloat("SFX", -80f);
            m_MusicSFXSlider.value = 0f;
            SFX_Muted = false; // 음소거 상태로 변경
        }
        else // 음소거인 경우
        {
            // 볼륨을 이전 값으로 복원
            m_AudioMixer.SetFloat("SFX", 0f);
            m_MusicSFXSlider.value = 0.5f;
            SFX_Muted = true; // 음소거 상태 해제
        }
    }

    public void Toggle_Skill_Voice_Mute()
    {
        // 현재 음소거 상태에 따라 동작 결정
        if (Skill_Voice_Muted) // 음소거가 아닌 경우
        {
            // 볼륨을 -80으로 설정하여 최소로 만듦 (음소거 상태)
            m_AudioMixer.SetFloat("Skill_Voice", -80f);
            m_MusicSkill_VoiceSlider.value = 0f;
            Skill_Voice_Muted = false; // 음소거 상태로 변경
        }
        else // 음소거인 경우
        {
            // 볼륨을 이전 값으로 복원
            m_AudioMixer.SetFloat("Skill_Voice", 0f);
            m_MusicSkill_VoiceSlider.value = 0.5f;
            Skill_Voice_Muted = true; // 음소거 상태 해제
        }
    }
}
