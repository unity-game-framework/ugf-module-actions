using System;
using System.Reflection;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionDescriptionAsset<>), true)]
    internal class ActionDescriptionAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScript;
        private Type m_type;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");

            Type targetType = target.GetType();

            PropertyInfo property = targetType.GetProperty("ActionType")
                                    ?? throw new ArgumentException("Property not found by the specified name: 'ActionType'.");

            m_type = (Type)property.GetValue(target);
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(m_propertyScript);
                }
            }

            DrawActionTypeInfo();
        }

        private void DrawActionTypeInfo()
        {
            EditorGUILayout.Space();
            EditorGUILayout.HelpBox($"Action Type: '{m_type}'.", MessageType.Info);
        }
    }
}
