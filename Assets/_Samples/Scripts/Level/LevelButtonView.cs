using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace n11ckz.SceneReference.Samples
{
    public class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        private UnityAction _callback;

        private void OnDestroy() =>
            _button.onClick.RemoveListener(_callback);

        public void Initialize(SceneReference scene, int index)
        {
            _callback = () => SceneLoader.Instance.LoadScene(scene);
            _button.onClick.AddListener(_callback);
            _text.text = index.ToString();
        }
    }
}
