using UnityEngine;
using UnityEngine.Events;

public class CollectableItem : MonoBehaviour
{
    public UnityEvent action;
    public bool destroyAfterCollected = true;
    public AudioSource coin;
    public AudioClip coinSound;
    
    private void OnTriggerEnter(Collider other)
    {
        var controller = other.GetComponent<PlayerController>();
        if (!controller) return;
        AudioSource.PlayClipAtPoint(coinSound, transform.position);

        action.Invoke();
        
        if (!destroyAfterCollected) return;
        Destroy(gameObject);
    }
}
