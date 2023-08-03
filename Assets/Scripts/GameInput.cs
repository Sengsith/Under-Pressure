using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {
   private PlayerInputActions playerInputActions;

   private void Awake () {
      playerInputActions = new PlayerInputActions();

      playerInputActions.Player.Pause.Enable();

      playerInputActions.Player.Pause.performed += Pause_performed;
   }

   private void Pause_performed (UnityEngine.InputSystem.InputAction.CallbackContext obj) {
      Debug.Log("Pause: No functionality yet.");
   }
}
