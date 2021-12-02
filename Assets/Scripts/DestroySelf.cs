using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void Start() => Destroy(gameObject, 0.5f);
}