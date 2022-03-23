using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction_system : MonoBehaviour
{
    /// <summary>
    /// Detect points 
    /// Detect radius
    /// detect layer 
    /// </summary>
    [Header("Detection parameter")]
    public Transform detectpoint;
    private const float detectRaius = 0.2f;
    public LayerMask detectionlayer;
    public GameObject gameObject;
    [Header("Other")]
    public List<GameObject> pickedItems = new List<GameObject>();


    // Update is called once per frame
    void Update()
    {
        if (ObjectDetect())
        {
            if (InteractInput())
            {
                gameObject.GetComponent<Item>().Interact();
            }
        }
    }

    bool InteractInput()
    {
       
        return Input.GetKeyDown(KeyCode.E);
    }

    bool ObjectDetect()
    {
        Collider2D collider2D1 = Physics2D.OverlapCircle(detectpoint.position,detectRaius,detectionlayer);

        if (collider2D1 == null)
        {
            gameObject = null;
            return false;
        }
        else
        {
            gameObject = collider2D1.gameObject;
            return true;
        }
    }

    public void PickedUpItems(GameObject item)
    {
        pickedItems.Add(item);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectpoint.position,detectRaius);
    }
}
