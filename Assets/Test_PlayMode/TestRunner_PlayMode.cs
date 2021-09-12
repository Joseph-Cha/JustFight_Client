using System.Collections;
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

        public IEnumerator PlayTimeTest()
        {
            // Arrange
            var obj = new GameObject();
            GameManager gm = obj.AddComponent<GameManager>();
            TimeSpan ts = new TimeSpan(0, 9, 50);

            yield return null;

            // act 

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

        public IEnumerator PlayerMovementTest()
        {
            // arrange
            var obj = new GameObject();
            Player player = obj.AddComponent<Player>();
            InputInfo inputInfo;
            Vector2Int desPos = player.CurPosition;

            yield return null;   

            // act
            // 10번 동안 랜덤으로 Player의 위치를 이동
            int count = 0;

            while(count < 10)
            {
                int randomInt = UnityEngine.Random.Range(0, 4);
                inputInfo = (InputInfo)randomInt;

                player.UpdateDestination(inputInfo);

                switch(inputInfo)
                {
                    case InputInfo.Up:
                    desPos += Vector2Int.up;
                    break;
                    
                    case InputInfo.Down:
                    desPos += Vector2Int.down;
                    break;

                    case InputInfo.Right:
                    desPos += Vector2Int.right;
                    break;

                    case InputInfo.Left:
                    desPos += Vector2Int.left;
                    break;
                }

                count++;
            }

            // 10번 동안 랜덤으로 이동한 현재 위치가 저장된 목적지와 같은지 증명
            Assert.AreEqual(desPos, player.CurPosition);
        }

    }
}
