using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour {
   private Vector3 mousePositionOffset;
   private Vector3 previousScale;
   private SpriteRenderer spriteRenderer;

   private void Awake () {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void Start () {
      // Only using colors right now to test game
      // Will switch to sprites when completed
      spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, .5f, 1f);
   }

   // Capture mouse offset so center of item doesn't snap to mouse
   private void OnMouseDown () {
      mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
      previousScale = transform.localScale;
      transform.localScale *= 1.1f;
   }

   private void OnMouseDrag () {
      // Follow mouse with offset
      transform.position = GetMouseWorldPosition() + mousePositionOffset;
   }

   private void OnMouseUp () {
      // Reset scale to previous scale after left mouse is up
      transform.localScale = previousScale;
   }

   // Converts mouse position to world space
   private Vector3 GetMouseWorldPosition () {
      return new Vector3 (
         Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
         Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
         0f);
   }
}
