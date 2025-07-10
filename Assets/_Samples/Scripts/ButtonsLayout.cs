using UnityEngine;
using UnityEngine.SceneManagement;

namespace n11ckz.SceneReference.Samples
{
    public class ButtonsLayout : MonoBehaviour
    {
        [SerializeField] private LevelSequence _levelSequence;
        [SerializeField] private LevelButtonView _viewPrefab;
        [SerializeField] private RectTransform _container;

        private void Start()
        {
            for (int i = 0; i < _levelSequence.Levels.Count; i++)
            {
                SceneReference scene = _levelSequence.Levels[i];
                LevelButtonView view = Instantiate(_viewPrefab, _container);
                view.Initialize(() => SceneManager.LoadScene(scene.BuildIndex), i + 1);
            }
        }
    }
}
