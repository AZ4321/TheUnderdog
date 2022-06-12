using UnityEngine;

public class ItemPickUp : Interactable
{

    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();

    }

    void PickUp()
    {
        

        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item); //Setting the boolean to check whether an item was added
        
        if (wasPickedUp)
            Destroy(gameObject);


    }

    
}
