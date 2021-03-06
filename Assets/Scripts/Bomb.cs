using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AudioClip explosionSound;
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false;

    private void Start() => Invoke(nameof(Explode), 3f);

    private void Explode()
    {
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        transform.Find("Collider").gameObject.SetActive(false);
        Destroy(gameObject, .3f);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (!exploded && col.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i < 3; i++)
        {
            Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out RaycastHit hit, i, levelMask);
            if (hit.collider)
                break;
            Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
            yield return new WaitForSeconds(.05f);
        }
    }
}