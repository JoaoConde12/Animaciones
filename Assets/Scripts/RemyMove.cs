using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking;
	public Transform playerTrans;
    
    void Start() {
        playerAnim.SetTrigger("Idle");
    }
	
	void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * w_speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed;
        }
        // else
        // {
        //     playerRigid.velocity = Vector3.zero;
        // }
    }


	void Update(){
		if(Input.GetKeyDown(KeyCode.W)){
			playerAnim.SetTrigger("Walking");
			playerAnim.ResetTrigger("Idle");
			walking = true;
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.W)){
			playerAnim.ResetTrigger("Walking");
			playerAnim.SetTrigger("Idle");
			walking = false;
			//steps1.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.S)){
			playerAnim.SetTrigger("Walking");
			playerAnim.ResetTrigger("Idle");
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.S)){
			playerAnim.ResetTrigger("Walking");
			playerAnim.SetTrigger("Idle");
			//steps1.SetActive(false);
		}
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
		if(walking == true){				
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				//steps1.SetActive(false);
				//steps2.SetActive(true);
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("run");
				playerAnim.ResetTrigger("walk");
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				//steps1.SetActive(true);
				//steps2.SetActive(false);
				w_speed = olw_speed;
				playerAnim.ResetTrigger("run");
				playerAnim.SetTrigger("walk");
			}
		}
        
        if (!Input.GetKey(KeyCode.W) &&
            !Input.GetKey(KeyCode.S) &&
            !Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.D))
        {
            // Solo cambia a Idle si no está ya en Idle
            if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                playerAnim.ResetTrigger("Walking");
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("Idle");
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cubo"))
        {
            Debug.Log("Haz colectado algo");
        }
    }

}