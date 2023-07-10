using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem runEffect;

    private CharacterController controller;
    
    private Vector3 playerVelocity;
    private Vector3 move;
    private bool groundedPlayer;
    private float gravityValue = -12f;
    
    private bool jumpInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        if(!GameManager.Instance.IsGameStarted) return;
        
        if (groundedPlayer && playerVelocity.y <= 0f)
        {
            playerVelocity.y = 0f;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * (Time.deltaTime * moveSpeed));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            runEffect.gameObject.SetActive(true);
        }
        else
        {
            runEffect.gameObject.SetActive(false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}
