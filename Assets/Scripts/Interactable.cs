using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float radius = 2f;

    void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);  
    }

    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLooseFocus();
}
