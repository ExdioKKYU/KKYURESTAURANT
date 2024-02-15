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

    private bool BGM_Muted = true; // ���Ұ� ���¸� ��Ÿ���� ����
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
        // ���� ���Ұ� ���¿� ���� ���� ����
        if (BGM_Muted) // ���ҰŰ� �ƴ� ���
        {
            // ������ -80���� �����Ͽ� �ּҷ� ���� (���Ұ� ����)
            m_AudioMixer.SetFloat("BGM", -80f);
            m_MusicBGMSlider.value = 0f;
            BGM_Muted = false; // ���Ұ� ���·� ����
        }
        else // ���Ұ��� ���
        {
            // ������ ���� ������ ����
            m_AudioMixer.SetFloat("BGM", 0f);
            m_MusicBGMSlider.value = 0.5f;
            BGM_Muted = true; // ���Ұ� ���� ����
        }
    }

    public void Toggle_SFX_Mute()
    {
        // ���� ���Ұ� ���¿� ���� ���� ����
        if (SFX_Muted) // ���ҰŰ� �ƴ� ���
        {
            // ������ -80���� �����Ͽ� �ּҷ� ���� (���Ұ� ����)
            m_AudioMixer.SetFloat("SFX", -80f);
            m_MusicSFXSlider.value = 0f;
            SFX_Muted = false; // ���Ұ� ���·� ����
        }
        else // ���Ұ��� ���
        {
            // ������ ���� ������ ����
            m_AudioMixer.SetFloat("SFX", 0f);
            m_MusicSFXSlider.value = 0.5f;
            SFX_Muted = true; // ���Ұ� ���� ����
        }
    }

    public void Toggle_Skill_Voice_Mute()
    {
        // ���� ���Ұ� ���¿� ���� ���� ����
        if (Skill_Voice_Muted) // ���ҰŰ� �ƴ� ���
        {
            // ������ -80���� �����Ͽ� �ּҷ� ���� (���Ұ� ����)
            m_AudioMixer.SetFloat("Skill_Voice", -80f);
            m_MusicSkill_VoiceSlider.value = 0f;
            Skill_Voice_Muted = false; // ���Ұ� ���·� ����
        }
        else // ���Ұ��� ���
        {
            // ������ ���� ������ ����
            m_AudioMixer.SetFloat("Skill_Voice", 0f);
            m_MusicSkill_VoiceSlider.value = 0.5f;
            Skill_Voice_Muted = true; // ���Ұ� ���� ����
        }
    }
}
