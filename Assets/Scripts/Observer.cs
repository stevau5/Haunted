using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player; 
    public GameEnding gameEnding; 
    bool m_IsPlayerInRange; 

    /**
    Player in Range of Gargoyle
     */
    void OnTriggerEnter(Collider other){
        if(other.transform == player){
            m_IsPlayerInRange = true; 
        }
    }

    /**
    Player out of range of Gargoyle.!-- 
    */
    void OnTriggerExit(Collider other){
        if(other.transform == player) {
            m_IsPlayerInRange = false; 
        }
    }

    void Update() {
        if(m_IsPlayerInRange){
            // shoot a raycast from the gargoyle to the direction of where it is looking. 
            Vector3 direction = player.position - transform.position + Vector3.up; 
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            // if raycast makes contact with player, then End game.. 
            if(Physics.Raycast(ray, out raycastHit)){
                if(raycastHit.collider.transform == player){
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

}
