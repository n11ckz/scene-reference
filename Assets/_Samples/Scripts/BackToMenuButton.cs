using UnityEngine;
using UnityEngine.SceneManagement;

namespace n11ckz.SceneReference.Samples
{
    public class BackToMenuButton : MonoBehaviour
    {
        [SerializeField] private SceneReference _menuSceneReference;

        public void BackToMenu() =>
            SceneManager.LoadScene(_menuSceneReference.BuildIndex);
    }
}
