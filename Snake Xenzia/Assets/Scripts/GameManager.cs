using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float xDirect = 52.5f;
    private float yDirect = 29.25f;
    private float spawnInterval = 2.0f;
    private float timeLastSpawn;
    public GameObject power;
    private GameObject powerRef;
 //   private ParticleSystem currentParticle;
    private bool isParticleActive;
    // Start is called before the first frame update
    void Start()
    {
        timeLastSpawn = 0f;
        isParticleActive = false;
        powerRef = power.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isParticleActive)
        {

        
        timeLastSpawn += Time.deltaTime;
        if (timeLastSpawn >= spawnInterval )
        {
            float positionX = Random.Range(-xDirect, xDirect);
            float postionY = Random.Range(-yDirect, yDirect);
            powerRef = Instantiate(power, new Vector3(positionX, postionY,60.25f), Quaternion.identity);
               
                timeLastSpawn = 0f;
                isParticleActive = true;
        }
        }
    }

    public void CollectParticle()
    {
        if(powerRef != null)
        {
            Destroy(powerRef.gameObject);
            isParticleActive = false;
        }
    }

}
