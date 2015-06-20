using UnityEngine;
using System.Collections;

public class DroppedItem : MonoBehaviour
{
    private GameObject player;
    private Inventory inventory;

    public float PickupDistance = 1.0f;

    private Item currentItem;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= PickupDistance)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + Vector3.up, 0.09f);
            GetComponent<Rigidbody>().useGravity = false;

            if (Vector3.Distance(transform.position, player.transform.position + Vector3.up) <= 0.5f)
            {
                inventory.AddItem(currentItem.ItemID);
                Destroy(gameObject);
            }
        }
        else
            GetComponent<Rigidbody>().useGravity = true;
    }

    public void UpdateItem(Item item)
    {
        currentItem = item;

        gameObject.name = "Dropped " + currentItem.ItemName;
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", currentItem.ItemIcon);
    }
}
