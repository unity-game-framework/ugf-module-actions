using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionModuleAsset), true)]
    internal class ActionModuleAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScript;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");
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
        }
    }
}
