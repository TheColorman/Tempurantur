using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFutureCarriable : Carriable
{
    public Carriable presentVersion;
    public TimeTravel presentTimeTravel;
    public TimeTravel futureTimeTravel;
    Rigidbody _rb;
    Vector3 TimeTravelDifference;
    Manager manager;
    bool disabled = false;
    public override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody>();
        TimeTravelDifference = futureTimeTravel.transform.position - presentTimeTravel.transform.position;
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<Manager>();
    }
    public override void FixedUpdate()
    {
        if (!presentVersion.inPresent)
        {
            Disable();
        }
        else
        {
            Enable();
        }
        if (disabled)
        {
            return;
        }
        base.FixedUpdate();
        if (!inPresent && manager.playerInPresent)
        {
            MatchTransform();
        }
        else if (presentVersion.isBeingCarried && inPresent)
        {
            MatchTransform();
            inPresent = false;
        }
    }
    void Disable()
    {
        disabled = true;
        _rb.transform.position = Vector3.zero;
    }
    void Enable()
    {
        disabled = false;
    }
    void MatchTransform()
    {
        transform.position = presentVersion.transform.position + TimeTravelDifference;
        transform.rotation = presentVersion.transform.rotation;
    }
}
