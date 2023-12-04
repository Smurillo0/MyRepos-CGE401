using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            //wait 1 second
            yield return new WaitForSeconds(spawnRate);

            //pick a random index between 0 and the # of prefabs
            int index = Random.Range(0, targets.Count);

            //spawn prefab at rabdom selected index
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
