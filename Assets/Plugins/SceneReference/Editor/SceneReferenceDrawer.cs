using UnityEditor;
using UnityEngine;

namespace n11ckz.SceneReference.Editor
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    internal class SceneReferenceDrawer : PropertyDrawer
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
                height += _heightOffset * Constants.NestedPropertiesCount;

            return height;
        }

        private void DrawFoldoutProperty(Rect position, SerializedProperty property, GUIContent content)
        {
            Rect foldoutRect = new Rect(position.x, position.y,
                position.width, EditorGUIUtility.singleLineHeight);
            GUIStyle foldoutStyle = EditorElementsUtility.GetFoldoutStyle();
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, content, true, foldoutStyle);
        }

        private void DrawNestedProperties(Rect position, SerializedProperty property)
        {
            EditorGUI.indentLevel++;

            Rect sceneAssetRect = new Rect(position.x, position.y + _heightOffset,
                position.width - _heightOffset, EditorGUIUtility.singleLineHeight);
            SerializedProperty sceneAssetProperty = property.FindPropertyRelative("_sceneAsset");
            EditorGUI.PropertyField(sceneAssetRect, sceneAssetProperty);

            DrawSettingsButton(sceneAssetRect);

            GUI.enabled = false;

            Rect nameRect = new Rect(sceneAssetRect.x, sceneAssetRect.y + _heightOffset,
                (position.width + Constants.EditorIndentOffset) * 0.5f, EditorGUIUtility.singleLineHeight);
            string namePropertyName = $"<{nameof(SceneReference.Name)}>k__BackingField";
            SerializedProperty nameProperty = property.FindPropertyRelative(namePropertyName);
            EditorGUI.PropertyField(nameRect, nameProperty, GUIContent.none);

            Rect buildIndexRect = new Rect(nameRect.x + nameRect.width - Constants.EditorIndentOffset, nameRect.y,
                nameRect.width, EditorGUIUtility.singleLineHeight);
            string buildIndexPropertyName = $"<{nameof(SceneReference.BuildIndex)}>k__BackingField";
            SerializedProperty buildIndexProperty = property.FindPropertyRelative(buildIndexPropertyName);
            EditorGUI.PropertyField(buildIndexRect, buildIndexProperty, GUIContent.none);

            GUI.enabled = true;

            EditorGUI.indentLevel--;
        }

        private void DrawSettingsButton(Rect position)
        {
            Rect settingsButtonRect = new Rect(position.x + position.width + Constants.GapBetweenProperties, position.y + 1,
                EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);
            GUIContent settingsButtonContent = EditorElementsUtility.GetSettingsButtonContent();

            if (GUI.Button(settingsButtonRect, settingsButtonContent, EditorStyles.iconButton) == false)
                return;

            EditorWindow.GetWindow<BuildPlayerWindow>();
        }
    }
}
