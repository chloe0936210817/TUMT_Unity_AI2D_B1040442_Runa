using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runa
{
    public class GameManager : MonoBehaviour
    {
        public void Replay()
        {
            
            SceneManager.LoadScene("遊戲");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }

}
