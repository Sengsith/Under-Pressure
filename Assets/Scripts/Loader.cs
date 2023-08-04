using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Not attached to any specific object, no instances of the class
// static so it lasts throught the application
public static class Loader {
   public enum Scene {
      MainMenuScene,
      GameScene,
      LoadingScene
   }

   private static Scene targetScene;

   public static void Load (Scene targetScene) {
      Loader.targetScene = targetScene;

      SceneManager.LoadScene(Scene.LoadingScene.ToString());
   }

   public static void LoaderCallback () {
      SceneManager.LoadScene(targetScene.ToString());
   }
}