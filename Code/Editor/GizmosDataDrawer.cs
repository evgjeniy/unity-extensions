using UnityEditor;

namespace UnityEngine.Extensions.Editor
{
    [CustomPropertyDrawer(typeof(GizmosData))]
    public class GizmosDataDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PrefixLabel(position, label);

            var kWidth = new[] { 0.11f, 0.01f, 0.28f, 0.01f, 0.11f, 0.01f, 0.47f }; // sum = 1.0f
            var inputWidth = EditorGUIUtility.currentViewWidth - EditorGUIUtility.labelWidth - 2.0f;

            var fieldPosition = position.x + EditorGUIUtility.labelWidth;
            var drawTypeLabel = new Rect(fieldPosition, position.y, inputWidth * kWidth[0], position.height);

            fieldPosition += drawTypeLabel.width + inputWidth * kWidth[1];
            var drawTypeRect = new Rect(fieldPosition, position.y, inputWidth * kWidth[2], position.height);

            fieldPosition += drawTypeRect.width + inputWidth * kWidth[3];
            var colorLabel = new Rect(fieldPosition, position.y, inputWidth * kWidth[4], position.height);

            fieldPosition += colorLabel.width + inputWidth * kWidth[5];
            var colorRect = new Rect(fieldPosition, position.y, inputWidth * kWidth[6], position.height);

            var oldIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            EditorGUI.LabelField(drawTypeLabel, "Type");
            EditorGUI.PropertyField(drawTypeRect, property.FindPropertyRelative($"{nameof(GizmosData.drawType)}"), GUIContent.none);
            EditorGUI.LabelField(colorLabel, "Color");
            EditorGUI.PropertyField(colorRect, property.FindPropertyRelative($"{nameof(GizmosData.gizmosColor)}"), GUIContent.none);

            EditorGUI.indentLevel = oldIndentLevel;
            
            EditorGUI.EndProperty();
        }
    }
}