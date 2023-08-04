using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DraggableItem : MonoBehaviour {
   private static int orderInLayer = 10;
   private static float zPosition = 0f;

   private Vector3 mousePositionOffset;
   private Vector3 previousScale;
   private SpriteRenderer spriteRenderer;

   private void Awake () {
      spriteRenderer = GetComponent<SpriteRenderer>();

      // Only using colors right now to test game
      // Will switch to sprites when completed
      spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, .5f, 1f);

      // Increments and sets the order/z position in layer so they maintain their stacked effect
      // Trigger will still work!
      orderInLayer += 10;
      spriteRenderer.sortingOrder = orderInLayer;
      zPosition -= 10f;
      transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
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
      return Camera.main.ScreenToWorldPoint(Input.mousePosition);
   }

   public Color GetColor () {
      return spriteRenderer.color;
   }
}
