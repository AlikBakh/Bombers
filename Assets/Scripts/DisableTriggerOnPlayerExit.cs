using UnityEngine;

public class DisableTriggerOnPlayerExit : MonoBehaviour
{
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            GetComponent<Collider>().isTrigger = false;
    }
}
