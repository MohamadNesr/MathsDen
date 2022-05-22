using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppleSpawn : MonoBehaviour
{
    public int applesToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    public bool gameOn;
    public bool game1Active;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects(){
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;
        if(gameOn && !game1Active){
            game1Active = true;
            for(int i=0; i<applesToSpawn; i++){
                randomItem = Random.Range(0, spawnPool.Count);
                toSpawn = spawnPool[randomItem];
                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                pos = new Vector2(screenX, screenY);

                Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            } 
        }
    }

    void Update(){
        gameOn = GameObject.Find("Player").GetComponent<PlayerMovement>().game1Trigger;
        spawnObjects();
     } 
    private void destroyObjects(){
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable")){
            Destroy(o);
        }
    }

}
