using UnityEditor;
using UnityEngine;

namespace n11ckz.SceneReference.Editor
{
    public static class EditorElementsUtility
    {
        private static readonly Vector2Int _foldoutStyleOffset = new Vector2Int(2, 0);

        internal static GUIStyle GetFoldoutStyle()
        {
            GUIStyle foldoutStyle = new GUIStyle(EditorStyles.foldout);
            foldoutStyle.margin.left -= _foldoutStyleOffset.x;

            Vector2Int offset = EditorGUIUtility.pixelsPerPoint * 100 % 2 == 0 ? 
                _foldoutStyleOffset : _foldoutStyleOffset + Vector2Int.right;
            foldoutStyle.contentOffset += offset;

            return foldoutStyle;
        }

        public static GUIContent GetSettingsButtonContent()
        {
            GUIContent content = EditorGUIUtility.IconContent(Constants.SettingsIconName);
            content.tooltip = "Open Build Settings";

            return content;
        }
    }
}
