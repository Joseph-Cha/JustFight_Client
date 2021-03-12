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
            var obj = new GameObject();
            obj.AddComponent<SceneLoader>();            
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
            Assert.IsNotNull(obj);
        }
    }
}
