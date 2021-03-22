using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System;

namespace Tests
{
    public class TestRunner
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestRunWithEnumeratorPasses()
        {
            // Arrange
            var obj = new GameObject();
            Button startButton = obj.AddComponent<Button>();
            SceneLoader sceneLoader = obj.AddComponent<SceneLoader>();
            startButton.onClick.AddListener(sceneLoader.OnPlayGame);
            
            yield return null;
            
            // act
            startButton.onClick.Invoke();
            DateTime startTime = DateTime.UtcNow;
            do
            {
                yield return null;
            } while ((DateTime.UtcNow - startTime).TotalSeconds < 10.0);            
            Scene scene = SceneManager.GetActiveScene();

            // asssrt
            Assert.AreEqual(scene.name, "");
        }
    }
}
