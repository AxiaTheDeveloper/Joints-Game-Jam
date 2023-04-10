using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    [SerializeField]GameInput gameInput;
    [SerializeField]private GameObject Player1,Player2, Player3;
    [SerializeField]private PlayerMovement playerMove;
    [SerializeField]private float changeCooldownTimer;
    private bool canChange;

    [Header("Player1 Identity1")]
    [SerializeField]private float speedPlayer1;
    [SerializeField]private float jumpForce1;
    [Header("Player1 Identity2")]
    [SerializeField]private float speedPlayer2;
    [SerializeField]private float jumpForce2;
    [Header("Player1 Identity3")]
    [SerializeField]private float speedPlayer3;
    [SerializeField]private float jumpForce3;
    
    private void Start() {
        Player1.SetActive(true);
        Player2.SetActive(false);
        Player3.SetActive(false);
        SetIdentity(Player1,speedPlayer1,jumpForce1);
        
        canChange = true;
    }
    private void Update() {
        //ntr br kasih syarat
        changeCharacter();
    }
    private void changeCharacter(){
        if(canChange){
            if(gameInput.GetInputChangePlayer1() && !Player1.activeSelf){
                SetIdentity(Player1,speedPlayer1,jumpForce1);
                Player1.SetActive(true);
                Player2.SetActive(false);
                Player3.SetActive(false);
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer2() && !Player2.activeSelf){
                SetIdentity(Player2,speedPlayer2,jumpForce2);
                Player1.SetActive(false);
                Player2.SetActive(true);
                Player3.SetActive(false);
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer3() && !Player3.activeSelf){
                SetIdentity(Player3,speedPlayer3,jumpForce3);
                Player1.SetActive(false);
                Player2.SetActive(false);
                Player3.SetActive(true);
                resetCooldown();
            }
            
        }   
    }

    private void SetIdentity(GameObject player, float speed, float forceJump){
        playerMove.SetCollider2D(player.GetComponent<Collider2D>());
        playerMove.SetPlayerJumpForce(forceJump);
        playerMove.SetPlayerSpeed(speed);
    }

    private void resetCooldown(){
        canChange = false;
        StartCoroutine(ChangeCooldown());
    }
    private IEnumerator ChangeCooldown(){
        yield return new WaitForSeconds(changeCooldownTimer);
        canChange = true;
    }
}
