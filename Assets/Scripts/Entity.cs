using UnityEngine;

public class Entity : MonoBehaviour
{

    private GameObject player;
    private Vector2 playerDirection;

    public GameObject Player { get { return player; } }
    public Vector2 PlayerDirection { get { return playerDirection; } }

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {

    }

    void Update()
    {
        playerDirection = (Vector2)player.transform.position - (Vector2)transform.position;
    }

}
