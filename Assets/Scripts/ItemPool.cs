using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour {
   [SerializeField] private DraggableItem draggleItemPrefab;
   [SerializeField] private int amountToSpawn = 10;
   
   private List<DraggableItem> draggableItemList;

   private void Awake () {
      draggableItemList = new List<DraggableItem>();
   }

   private void Start () {
      while (draggableItemList.Count < amountToSpawn) {
         Debug.Log(draggableItemList.Count + ": Instantiate");
         DraggableItem newDraggableItem = Instantiate(draggleItemPrefab);
         draggableItemList.Add(newDraggableItem);
      }
   }

   // Pick a random DraggableItem from the list and send to SubmitZone so it can reference the correct item
}
