using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyManager.instance?.CollectKey();
            gameObject.SetActive(false);
        }
    }
}
