using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool playerInPresent = true;
    public Door StartDoor;
    public bool keyCardOne = false;
    public bool keyCardTwo = false;
    public bool keyCardThree = false;
    public bool keyCardOneUnlocked = false;
    public bool keyCardTwoUnlocked = false;
    public bool keyCardThreeUnlocked = false;
    public float totalTime;
    AudioSource audioSource;
    public AudioClip Chime;
    public AudioClip timeReactor;
    public List<AudioClip> Announcements = new List<AudioClip>();
    float ElevenMinutes = 11 * 60;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(LateStart(1));
        StartCoroutine(PlayAnnouncement(Announcements[0]));

    }
    bool ten = false;
    bool nine = false;
    bool eight = false;
    bool seven = false;
    bool six = false;
    bool five = false;
    bool four = false;
    bool three = false;
    bool two = false;
    bool one = false;
    bool thirty = false;
    bool countdown = false;
    void Update()
    {
        totalTime += Time.deltaTime;
        float TimeRemaining = ElevenMinutes - totalTime;
        // 10 minutes left
        if (TimeRemaining <= 600 && ten == false)
        {
            StartCoroutine(PlayTime(Announcements[1]));
            ten = true;
        }
        // 9 minutes left
        if (TimeRemaining <= 540 && nine == false)
        {
            StartCoroutine(PlayTime(Announcements[2]));
            nine = true;
        }
        // 8 minutes left
        if (TimeRemaining <= 480 && eight == false)
        {
            StartCoroutine(PlayTime(Announcements[3]));
            eight = true;
        }
        // 7 minutes left
        if (TimeRemaining <= 420 && seven == false)
        {
            StartCoroutine(PlayTime(Announcements[4]));
            seven = true;
        }
        // 6 minutes left
        if (TimeRemaining <= 360 && six == false)
        {
            StartCoroutine(PlayTime(Announcements[5]));
            six = true;
        }
        // 5 minutes left
        if (TimeRemaining <= 300 && five == false)
        {
            StartCoroutine(PlayTime(Announcements[6]));
            five = true;
        }
        // 4 minutes left
        if (TimeRemaining <= 240 && four == false)
        {
            StartCoroutine(PlayTime(Announcements[7]));
            four = true;
        }
        // 3 minutes left
        if (TimeRemaining <= 180 && three == false)
        {
            StartCoroutine(PlayTime(Announcements[8]));
            three = true;
        }
        // 2 minutes left
        if (TimeRemaining <= 120 && two == false)
        {
            StartCoroutine(PlayTime(Announcements[9]));
            two = true;
        }
        // 1 minute left
        if (TimeRemaining <= 60 && one == false)
        {
            StartCoroutine(PlayTime(Announcements[10]));
            one = true;
        }
        // 30 seconds left
        if (TimeRemaining <= 30 && thirty == false)
        {
            StartCoroutine(PlayTime(Announcements[11]));
            thirty = true;
        }
        // Count down from 10
        if (TimeRemaining <= 10 && countdown == false)
        {
            StartCoroutine(CountFromTen());
            countdown = true;
        }
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartDoor.Open();
    }
    IEnumerator PlayAnnouncement(AudioClip clip)
    {
        audioSource.PlayOneShot(Chime);
        yield return new WaitForSeconds(Chime.length);
        audioSource.PlayOneShot(clip);
    }
    IEnumerator PlayTime(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        audioSource.PlayOneShot(timeReactor);
    }
    IEnumerator CountFromTen()
    {
        for (int i = 12; i < Announcements.Count; i++)
        {
            audioSource.PlayOneShot(Announcements[i]);
            yield return new WaitForSeconds(1f);
        }
    }
}
