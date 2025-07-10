using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace n11ckz.SceneReference.Samples
{
    public class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _text;

        private void OnDestroy() =>
            _button.onClick.RemoveAllListeners();

        public void Initialize(UnityAction onClicked, int index)
        {
            _button.onClick.AddListener(onClicked);
            _text.text = index.ToString();
        }
    }
}
