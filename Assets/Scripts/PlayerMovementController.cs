using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerMovementController : NetworkBehaviour
{
    public Rigidbody2D rb;
    private float moveH, moveV;
    public GameObject PlayerModel;
    [SerializeField] private float moveSpeed = 1.0f;

    private void Start()
    {
        PlayerModel.SetActive(false);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if(SceneManager.GetActiveScene().name == "Game")
        {
            if(PlayerModel.activeSelf == false)
            {
                SetPosition();
                PlayerModel.SetActive(true);
            }

            if(hasAuthority)  //PONER AQUI ACCIONES QUE PUEDE REALIZAR EL JUGADOR A SU PROPIO PERSONAJE
            {
                moveH = Input.GetAxis("Horizontal");
                moveV = Input.GetAxis("Vertical");
                rb.velocity = new Vector2(moveH * moveSpeed, moveV * moveSpeed);

            }
        }
    }

    public void SetPosition()   //REVISAR DONDE HACE SPAWN EL PLAYER
    {
        transform.position = new Vector3(Random.Range(-5, 5), 0.8f, Random.Range(-15,7));
    }
}
