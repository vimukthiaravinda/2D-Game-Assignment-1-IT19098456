using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public Healthbar healthbar;
    public enum InteractionType
    {
        NONE, Pickup, Examine
    }

    public InteractionType interaction;
    // techincal componet of each item

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact()
    {
        switch (interaction)
        {
            case InteractionType.Pickup:
                FindObjectOfType<interaction_system>().PickedUpItems(gameObject);
                gameObject.SetActive(false);
                healthbar.fillLife(25);
                break;

            case InteractionType.Examine:
                FindObjectOfType<interaction_system>().PickedUpItems(gameObject);
                gameObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                break;

            default:
                Debug.Log("NULL ITEM");
                break;

        }
    }
}

