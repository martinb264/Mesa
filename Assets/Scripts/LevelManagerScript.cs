using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public static LevelManagerScript instance;
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Transform player;
    public bool isAlive = true;
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private Camera bossCam;
    [SerializeField]
    private GameObject currentPlayer;
    public Camera activeCam;
    [SerializeField]
    private BossDoorScript bossDoorScript;
    [SerializeField]
    private AudioSource mainMusic,BossMusic,deathMusic;


    public void Awake()
    {
        
        instance = this;
        mainCam.enabled = true;
        activeCam = mainCam;
        bossCam.enabled = false;
        
    }
  
    public void loadLevel(PlayerData data)
    {
 
        if (data != null)
        {
            Vector3 playerPosition = new Vector3();
            playerPosition.x = data.playerPosition[0];
            playerPosition.y = data.playerPosition[1];
    
            currentPlayer.transform.position = playerPosition;
    
            Vector3 respawnPosition = new Vector3();
            respawnPosition.x = data.respawnPosition[0];
            respawnPosition.y = data.respawnPosition[1];
            respawnPoint.position = respawnPosition;

        }
        if (data == null)
        {
            Debug.Log("No Save Data");
        }
    }
    public Transform getRespawnPosition()
    {
        return respawnPoint;
    }

    public void Respawn()
    {
        if (isAlive == false)
        {
            GameObject Player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
            currentPlayer = Player;
            player = Player.transform;
            CameraController.instance.player = Player;
            activeCam = mainCam;
            bossCam.enabled=false;
            isAlive = true;
            resetBoss();
            deathMusic.Stop();
            mainMusic.Play();
        }
    }
    public void activeBossCam()
    {
        bossCam.enabled = true;
        activeCam = bossCam;
        mainMusic.Stop();
        BossMusic.Play();
        //mainCam.enabled = false;
    }

    public void resetBoss()
    {
        bossDoorScript.restartBoss();
        BossMusic.Stop();

    }

    public void startDeathMusic()
    {
        BossMusic.Stop();
        mainMusic.Stop();
        deathMusic.Play();
    }
    public void setRespawnPoint()
    {
        Debug.Log("RespawnHit");
        respawnPoint.position = player.position;

        SaveSystem.savePlayer(player);

        PlayerData data = SaveSystem.loadPlayer();
        Vector3 playerPosition = new Vector3();
        playerPosition.x = data.playerPosition[0];
        playerPosition.y = data.playerPosition[1];
        Debug.Log("X position: " + playerPosition.x + " Y Position: " + playerPosition.y);
    }

}
