using UnityEditor;
using UnityEngine;

namespace n11ckz.SceneReference.Editor
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    public class SceneReferenceDrawer : PropertyDrawer
    {
        private readonly float _heightOffset = EditorGUIUtility.singleLineHeight + Constants.GapBetweenProperties;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            DrawFoldoutProperty(position, property, label);

            if (property.isExpanded == true)
                DrawNestedProperties(position, property);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUIUtility.singleLineHeight;

            if (property.isExpanded == true)
                height += _heightOffset * 2;
            
            return height;
        }

        private void DrawFoldoutProperty(Rect position, SerializedProperty property, GUIContent content)
        {
            Rect foldoutRect = new Rect(position.x, position.y,
                position.width, EditorGUIUtility.singleLineHeight);
            GUIStyle foldoutStyle = EditorElementsUtility.GetFoldoutStyle();
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded,content, true, foldoutStyle);
        }

        private void DrawNestedProperties(Rect position, SerializedProperty property)
        {
            EditorGUI.indentLevel++;

            Rect sceneAssetRect = new Rect(position.x, position.y + _heightOffset,
                position.width, EditorGUIUtility.singleLineHeight);
            SerializedProperty sceneAssetProperty = property.FindPropertyRelative("_sceneAsset");
            EditorGUI.PropertyField(sceneAssetRect, sceneAssetProperty);

            GUI.enabled = false;

            Rect nameRect = new Rect(sceneAssetRect.x, sceneAssetRect.y + _heightOffset,
                (sceneAssetRect.width + Constants.EditorIndentOffset) * 0.5f, EditorGUIUtility.singleLineHeight);
            SerializedProperty nameProperty = property.FindPropertyRelative("<Name>k__BackingField");
            EditorGUI.PropertyField(nameRect, nameProperty, GUIContent.none);

            Rect buildIndexRect = new Rect(nameRect.x + nameRect.width - Constants.EditorIndentOffset, nameRect.y,
                nameRect.width, EditorGUIUtility.singleLineHeight);
            SerializedProperty buildIndexProperty = property.FindPropertyRelative("<BuildIndex>k__BackingField");
            EditorGUI.PropertyField(buildIndexRect, buildIndexProperty, GUIContent.none);

            GUI.enabled = true;

            EditorGUI.indentLevel--;
        }
    }
}
