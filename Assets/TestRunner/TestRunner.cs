using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestRunner
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestRunSimplePasses()
        {
            
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestRunWithEnumeratorPasses()
        {
            // Arrange
            var obj = new GameObject();
            Button startButton = obj.AddComponent<Button>();
            SceneLoader sceneLoader = obj.AddComponent<SceneLoader>();
            startButton.onClick.AddListener(sceneLoader.PlayGame);
            
            yield return null;
            
            // act
            startButton.onClick.Invoke();
            
            yield return new WaitForSeconds(3.5f);
            
            Scene scene = SceneManager.GetActiveScene();
            
            // asssrt
            Assert.AreEqual(scene.name, "Main");
        }
    }
}
