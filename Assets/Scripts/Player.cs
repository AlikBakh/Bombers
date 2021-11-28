using System;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GlobalStateManager GlobalManager;

    [Range(1, 2)]
    public int playerNumber = 1;
    public float moveSpeed = 5f;
    public bool canDropBombs = true;
    public bool canMove = true;
    public bool dead = false;
    public GameObject bombPrefab;
    private GameObject player;

    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
        animator = myTransform.Find("PlayerModel").GetComponent<Animator>();
    }

    private void Update() => UpdateMovement();

    private void UpdateMovement()
    {
        animator.SetBool("Walking", false);

        if (!canMove)
            return;

        KeyCode[] param = playerNumber == 1 ? new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space }
                                            : new KeyCode[] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.KeypadEnter };
        if (param != null)
            UpdatePlayerMovement(param[0], param[1], param[2], param[3], param[4]);
    }

    private void UpdatePlayerMovement(KeyCode W, KeyCode A, KeyCode S, KeyCode D, KeyCode Space)
    {
        if (Input.GetKey(W))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(A))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(S))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(D))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKeyDown(Space))
            DropBomb();
    }
    private void DropBomb()
    {
        player = playerNumber == 1 ? GameObject.Find("CamZone/PlayerPanel1") : GameObject.Find("CamZone/PlayerPanel2");
        canDropBombs = CheckBombCount();
        if (canDropBombs && bombPrefab)
            Instantiate(bombPrefab,
                new Vector3(Mathf.RoundToInt(myTransform.position.x), bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)),
                bombPrefab.transform.rotation, player.transform);
    }
    private bool CheckBombCount()
    {
        int bombCount = 0;

        foreach (Transform child in player.transform)
            if (child.name.StartsWith("Bomb"))
                bombCount++;
        return bombCount <= 3;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!dead && other.CompareTag("Explosion"))
        {
            dead = true;
            GlobalManager.PlayerDied(playerNumber);
            Destroy(gameObject);
        }
    }
}
