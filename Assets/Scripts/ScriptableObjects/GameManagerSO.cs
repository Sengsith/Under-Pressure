using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerSO", menuName = "ScriptableObject/GameManagerSO")]
public class GameManagerSO : ScriptableObject {
   public event EventHandler<OnRandomDraggableItemGeneratedEventArgs> OnRandomDraggleItemGenerated;
   public class OnRandomDraggableItemGeneratedEventArgs : EventArgs {
      public DraggableItem randomDraggableItem;   
   }

   public void SendRandomDraggableItem (DraggableItem randomDraggableItem) {
      OnRandomDraggleItemGenerated?.Invoke(this, new OnRandomDraggableItemGeneratedEventArgs {
         randomDraggableItem = randomDraggableItem
      });
   }
}
