using UnityEngine;
using System.Collections;

public class SetupScene : MonoBehaviour
{
    public int Players = 1;
    public GameObject PlayerPrefab;
    public GameObject[] GameObjectsToSpawn;

    void Start()
    {
        for (int i = 0; i < Players; i++)
        {
            GameObject player = Instantiate(PlayerPrefab, new Vector3(Random.Range(-150, 150), 10, Random.Range(-150, 150)), Quaternion.identity) as GameObject;
            player.name = "Player" + i;

            if (i == 0)
            {
                player.name = "Player";
                player.GetComponent<PlayerControl>().LocallyControlled = true;
            }
        }

        foreach (GameObject obj in GameObjectsToSpawn)
        {
            GameObject gameObj = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
            gameObj.name = obj.name;
        }

        Destroy(gameObject);
    }
}
