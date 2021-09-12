using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System;
using TMPro;

namespace Tests
{
    public class TestRunner_PlayMode
    {
        GameManager gameManager;
        InputController inputController;
        GameObject CountDonwGo = new GameObject();
        [SetUp]
        public void SetUp()
        {
            // Manager Instance
            inputController = new GameObject().AddComponent<InputController>();
            gameManager = new GameObject().AddComponent<GameManager>();
            CountDonwGo.AddComponent<TextMeshPro>();
            CountDonwGo.AddComponent<CountDownUI>();
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SceneLoadTest()
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

        [UnityTest]
        public IEnumerator PlayTimeTest()
        {
            // Arrange
            var obj = new GameObject();
            TimeSpan ts = new TimeSpan(0, 9, 50);

            yield return null;

            // act 
            float waitTime = 0.0f;
            do
            {
                yield return null;
                waitTime += Time.deltaTime;
            } while (waitTime < 9.0f);

            // assert
            Assert.AreEqual(ts, gameManager.remainingTime);
        }

        [UnityTest]
        public IEnumerator PlayerMovementTest()
        {
            // arrange
            var obj = new GameObject();
            Player player = new Player();
            KeyCode inputInfo;
            Vector2Int desPos = player.CurrentPos;

            yield return null;   

            // act
            // 10번 동안 랜덤으로 Player의 위치를 이동
            int count = 0;

            while(count < 10)
            {
                int randomInt = UnityEngine.Random.Range(273, 277);
                inputInfo = (KeyCode)randomInt;
                Debug.Log($"Key Code : {inputInfo}");
                player.UpdateDestination(inputInfo);
                switch(inputInfo)
                {
                    case KeyCode.UpArrow:
                    desPos += Vector2Int.up;
                    break;
                    
                    case KeyCode.DownArrow:
                    desPos += Vector2Int.down;
                    break;

                    case KeyCode.RightArrow:
                    desPos += Vector2Int.right;
                    break;

                    case KeyCode.LeftArrow:
                    desPos += Vector2Int.left;
                    break;
                }
                count++;
            }

            // 10번 동안 랜덤으로 이동한 현재 위치가 저장된 목적지와 같은지 증명
            Assert.AreEqual(desPos, player.CurrentPos);
        }

    }
}
