using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseInput : MonoBehaviour {

   private PlayerInputActions playerInputActions;
   private Vector2 mouseInput;
   private Vector3 mouseWorldPosition;

   private void Awake () {
      playerInputActions = new PlayerInputActions();
      playerInputActions.Player.Grab.Enable();

      playerInputActions.Player.Grab.performed += Grab_performed;
   }

   private void Grab_performed (UnityEngine.InputSystem.InputAction.CallbackContext obj) {
      // Check to see what we clicked on, but how do we do that?
   }

   private void Update () {
      HandleMousePosition();
   }

   // Reads mouse position on the screen then converts it to world point.
   private void HandleMousePosition () {

      // Convert x and y to local space, but make the z = 0 so it is on same plane as game objects
      mouseWorldPosition = new Vector3(
         Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
         Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
         0f);

      Debug.Log("Mouse position: " + mouseWorldPosition);
   }

}
