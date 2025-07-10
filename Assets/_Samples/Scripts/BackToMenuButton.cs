using UnityEngine;

namespace n11ckz.SceneReference.Samples
{
    public class BackToMenuButton : MonoBehaviour
    {
        [SerializeField] private SceneReference _menuScene;

        public void Back() =>
            SceneLoader.Instance.LoadScene(_menuScene);
    }
}
