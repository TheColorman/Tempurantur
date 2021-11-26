using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeLockTimer : Interactable
{
    public float time = 0;
    public TMP_Text text;
    bool activated = false;
    AudioSource audioSource;
    Door door;
    public Door otherDoor;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        door = GetComponentInParent<Door>();
    }
    void Update()
    {
        if (activated)
        {
            time += Time.deltaTime;
            int twelveYearsInSeconds = 12 * 365 * 24 * 60 * 60;
            float secondsRemaning = twelveYearsInSeconds - time;
            float minutesRemaning = secondsRemaning / 60;
            float hoursRemaning = minutesRemaning / 60;

            int displayedHours = (int)hoursRemaning;
            int displayedMinutes = (int)minutesRemaning - (displayedHours * 60);
            int displayedSeconds = (int)secondsRemaning - (displayedHours * 60 * 60) - (displayedMinutes * 60);

            string timeString = displayedHours.ToString("00") + ":" + displayedMinutes.ToString("00") + ":" + displayedSeconds.ToString("00");

            text.text = timeString;
        }
    }
    public override void OnFocus()
    {
    }
    public override void OnLooseFocus()
    {
    }
    public override void OnInteract()
    {
        DoorToggle(door);
        if (otherDoor != null)
        {
            DoorToggle(otherDoor);
        }

        if (activated)
        {
            return;
        }
        activated = true;
        audioSource.Play();
    }
    void DoorToggle(Door Door)
    {
        Door.open = !Door.open;
        if (Door.open)
        {
            Door.Open();
        } else
        {
            Door.Close();
        }
    }

}
