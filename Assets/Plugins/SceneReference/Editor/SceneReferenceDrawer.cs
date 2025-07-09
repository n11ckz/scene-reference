using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace n11ckz.SceneReference.Editor
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    public class SceneReferenceDrawer : PropertyDrawer
    {
        [SerializeField] private VisualTreeAsset _visualTreeAsset;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = _visualTreeAsset.CloneTree();

            return root;
        }
    }
}
