using System.Collections.Generic;
using LD41;
using UnityEngine;

public class AudioManager : SingletonBehaviour<AudioManager> {

    public AudioSource audioSource_Music;
    public AudioSource audioSource_Note;
    public AudioSource audioSource_SoundEffect;
    public List<AudioClip> audioClips_Note;
    public List<AudioClip> audioClips_Song;
    public List<AudioClip> audiosClips_Bomb;

    public UnityEngine.Events.UnityAction delayedCallback;

    private System.DateTime unMuteTime;

	public void PlayNote(NoteData note)
    {
        int noteIndex = GetNoteIndex(note);
        PlayNoteByIndx(noteIndex);
    }

    public void PlayMusic(Song song)
    {
        audioSource_Music.clip = audioClips_Song[0];
        audioSource_Music.Play();
    }


    public void ReduceMusicVolumnForSeconds(float time)
    {
        unMuteTime = System.DateTime.UtcNow.AddSeconds(time);
        audioSource_Music.volume = 0.5f;
        delayedCallback += ResumeMusicVolumn;
        BulletHellUtil.CallFunctionAfterTime(time, delayedCallback);
    }

    public void ResumeMusicVolumn()
    {
        System.DateTime nowTime = System.DateTime.UtcNow;
        if ((nowTime - unMuteTime).TotalMilliseconds < 0)
            return;
        
        audioSource_Music.volume = 1.0f;
    }


    private void PlayNoteByIndx(int noteIdx)
    {
        audioSource_Note.clip = audioClips_Note[noteIdx];
        audioSource_Note.Play();
    }

    private int GetNoteIndex(NoteData note)
    {
        //int noteIndex = Random.Range(0, 3);
        int noteIndex = note.key;
        return noteIndex;
    }

    public void PlayBombBG()
    {
        StartCoroutine(PlayBombBGCoroutine());
    }

    private System.Collections.IEnumerator PlayBombBGCoroutine()
    {
        yield return new WaitForSeconds(11);

        int firstRound = 1000;
        for (int i = 0; i < firstRound; i++)
        {
            int randomSoundIdx = Random.Range(1, 5);
            audioSource_SoundEffect.clip = audiosClips_Bomb[randomSoundIdx];
            audioSource_SoundEffect.Play();

            int randomDelay = Random.Range(1, 5);
            yield return new WaitForSeconds(randomDelay);
        }
    }




}
