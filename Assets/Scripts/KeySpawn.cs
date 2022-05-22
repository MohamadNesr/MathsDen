using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    public int keysToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    //public PlayerMovement pm;
    public bool gameOn;
    public bool game3Active;

    // Start is called before the first frame update
      
    public void spawnObjects(){
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;
        if(gameOn && !game3Active){
            game3Active = true;
            for(int i=0; i<keysToSpawn; i++){
                toSpawn = spawnPool[i];
                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                pos = new Vector2(screenX, screenY);

                Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            }
        }
    }
    void Update(){
        gameOn = GameObject.Find("Player").GetComponent<PlayerMovement>().game3Trigger;
        spawnObjects();
     } 
    private void destroyObjects(){
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable")){
            Destroy(o);
        }
    }
}
