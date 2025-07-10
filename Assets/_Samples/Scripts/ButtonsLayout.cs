using UnityEngine;

namespace n11ckz.SceneReference.Samples
{
    public class ButtonsLayout : MonoBehaviour
    {
        [SerializeField] private LevelSequence _levelSequence;
        [SerializeField] private LevelButtonView _viewPrefab;
        [SerializeField] private Transform _container;

        private void Start()
        {
            for (int i = 0; i < _levelSequence.Levels.Count; i++)
            {
                LevelButtonView view = Instantiate(_viewPrefab, _container);
                SceneReference scene = _levelSequence.Levels[i];
                view.Initialize(scene, i + 1);
                Debug.Log(scene.BuildIndex);
            }
        }
    }
}
