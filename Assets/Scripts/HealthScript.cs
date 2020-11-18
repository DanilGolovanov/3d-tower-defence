using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TowerDefence.Managers;
using TowerDefence.Enemies;

public class HealthScript : MonoBehaviour {

    public bool is_Player, is_Enemy;
    private bool is_Dead;

    private PlayerStats player_Stats;
    private Enemy enemy;

    void Awake () {
	    
        if(is_Enemy) 
        {
            enemy = GetComponent<Enemy>();
        }

        if(is_Player) 
        {
            player_Stats = GetComponent<PlayerStats>();
        }

	}
	//damage script based on if player or if enemy
    public void ApplyDamage(float damage) {

        // if dead don't execute the rest of the code
        if (is_Dead)
        {
            return;
        }

        if (is_Player)
        {
            GameManager.instance.currentHealth -= damage;

            if (GameManager.instance.currentHealth <= 0f)
            {
                PlayerDied();
                is_Dead = true;
            }

        }
        if (is_Enemy)
        {
            enemy.health -= damage;
        }
        

    }

    public void PlayerDied() 
    {
        if(tag == Tags.PLAYER_TAG) {

            Invoke("RestartGame", 3f);

        } 
        else 
        {
            Invoke("TurnOffGameObject", 3f);
        }

    } // player died

    void RestartGame() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    void TurnOffGameObject() 
    {
        gameObject.SetActive(false);
    }

} // class









































