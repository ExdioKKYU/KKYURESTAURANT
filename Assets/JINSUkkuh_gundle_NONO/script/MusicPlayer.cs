using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip musicClip; // 인스펙터 창에서 설정할 음악 파일
    private AudioSource musicSource;

    void Start()
    {
        // AudioSource 컴포넌트를 가져오기
        musicSource = GetComponent<AudioSource>();

        // 음악 파일 설정
        musicSource.clip = musicClip;

        // 노래 재생
        musicSource.Play();
    }

    void Update()
    {
        // (옵션) 노래를 반복하려면 아래 주석 해제
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
