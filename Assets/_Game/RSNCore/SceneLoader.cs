using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.RSNCore
{
    public class SceneLoader : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}