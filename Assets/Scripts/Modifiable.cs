using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifiable : MonoBehaviour
{
    public GameObject present;
    public GameObject future;
    public abstract void Modify();
}
