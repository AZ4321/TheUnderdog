using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFocus : MonoBehaviour
{

    public Camera cam;

    public Interactable focus;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {

                RemoveFocus();

            }
        }

        //This system needs re-doing to one that is independent of the mouse and works in an area.
        //TODO: Delete mouse button checks and instead do is the player within the radius of the item?
        //If YES: focus
        //If NO: Defocus
        
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100))
            {

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {

                    SetFocus(interactable);

                }
            }
        }

        
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDeFocused();
                focus = newFocus;

        }

        newFocus.OnFocused(transform);

    }
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocused();

        focus = null;
    }
}
