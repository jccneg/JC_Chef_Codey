using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;
    
    public string triggerName = "";

    public GameObject breadPrefab;
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;

    public GameObject heldItem;
    public string heldItemName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                PickUpItem(breadPrefab, "breadSlice");
            }

            if (triggerName == "Egg")
            {
                PickUpItem(eggPrefab, "egg");
            }    

            if (triggerName == "Stove")
            {
                if (heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    PlaceHeldItem();
                }
                else if (heldItemName == "egg")
                {
                    stove.FryEgg();
                    PlaceHeldItem();
                }
                else
                {
                    if (stove.cookedFood == "toast" && stove.isCooking == false)
                    {
                        PickUpItem(breadPrefab, "toastSlice");
                        stove.CleanStove();
                    }

                    if (stove.cookedFood == "friedEgg" && stove.isCooking == false)
                    {
                        PickUpItem(friedEggPrefab, "friedEgg");
                        stove.CleanStove();
                    }
                }
            }

            if (triggerName == "Receivers")
            {
                if (heldItemName == "toastSlice")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/bread1").SetActive(true);
                }

                if (heldItemName == "friedEgg")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/egg").SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown("x"))
        {
            DropHeldItem();
        }
    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void DropHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 2, 2);
        heldItemName = itemName;
    }
}
