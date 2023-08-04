using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItemPool : MonoBehaviour {
   [SerializeField] private GameManagerSO gameManagerSO;
   [SerializeField] private DraggableItem draggleItemPrefab;
   [SerializeField] private int amountToSpawn = 10;
   
   private List<DraggableItem> draggableItemList;

   private void Awake () {
      draggableItemList = new List<DraggableItem>();
   }

   private void Start () {
      while (draggableItemList.Count < amountToSpawn) {
         DraggableItem newDraggableItem = Instantiate(draggleItemPrefab);
         draggableItemList.Add(newDraggableItem);
      }
      // Sends a random DraggableItem to the GameManagerSO so it can fire off an event
      gameManagerSO.SendRandomDraggableItem(GetRandomDraggableItem());
   }

   // Return random item from list
   private DraggableItem GetRandomDraggableItem () {
      int randomValue = Random.Range(0, amountToSpawn);
      return draggableItemList[randomValue];
   }
}
