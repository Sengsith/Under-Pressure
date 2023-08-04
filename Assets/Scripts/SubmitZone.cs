using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitZone : MonoBehaviour {
   [SerializeField] private GameManagerSO gameManagerSO;
   [SerializeField] private GameObject correctItem;

   private SpriteRenderer correctItemSR;
   private DraggableItem correctDraggableItem;

   private void Awake () {
      correctItemSR = correctItem.GetComponent<SpriteRenderer>();
   }

   private void Start () {
      gameManagerSO.OnRandomDraggleItemGenerated += GameManagerSO_OnRandomDraggleItemGenerated;
   }

   private void GameManagerSO_OnRandomDraggleItemGenerated (object sender, GameManagerSO.OnRandomDraggableItemGeneratedEventArgs e) {
      correctDraggableItem = e.randomDraggableItem;

      correctItemSR.color = correctDraggableItem.GetColor();
   }

   private void OnTriggerEnter2D (Collider2D collision) {
      DraggableItem collidedItem = collision.gameObject.GetComponent<DraggableItem>();
      // Implemented using same color for now, but later we will simply check for the name of the object
      if (collidedItem.GetColor() == correctDraggableItem.GetColor()) {
         Debug.Log("Correct!");
      } else {
         Debug.Log("Incorrect!");
      }
   }
}
