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
    public class TestRunner_PlayMode
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
            Assert.AreEqual(scene.name, "Main");
        }

        public IEnumerator TestRunner_PlayModeWithEnumeratorPasses()
        {
            // Arrange
            var obj = new GameObject();
            GameManager gm = obj.AddComponent<GameManager>();
            TimeSpan ts = new TimeSpan(0, 9, 50);

            yield return null;

            // act 
            // 
            float waitTime = 0.0f;
            do
            {
                yield return null;
                waitTime += Time.deltaTime;
            } while (waitTime < 10.0f);

            Debug.Log(gm.remainingTime);
            // assert
            Assert.AreEqual(gm.remainingTime, ts);
        }

    }
}
