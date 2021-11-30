using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void Start() => Destroy(gameObject, 1f);
}