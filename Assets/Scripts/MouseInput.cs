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

      playerInputActions.Player.Mouse.Enable();
      playerInputActions.Player.Grab.Enable();
   }

   private void Update () {
      HandleMouseInput();
   }

   // Reads mouse position on the screen then converts it to world point.
   private void HandleMouseInput () {
      mouseInput = playerInputActions.Player.Mouse.ReadValue<Vector2>();

      // Convert x and y to local space, but make the z = 0 so it is on same plane as game objects
      mouseWorldPosition = new Vector3(
         Camera.main.ScreenToWorldPoint(mouseInput).x,
         Camera.main.ScreenToWorldPoint(mouseInput).y,
         0f);

      Debug.Log("Mouse position: " + mouseWorldPosition);
   }

}
