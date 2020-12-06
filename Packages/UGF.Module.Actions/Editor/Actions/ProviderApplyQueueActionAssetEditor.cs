using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime.Provider;
using UnityEditor;

namespace UGF.Module.Actions.Editor.Actions
{
    [CustomEditor(typeof(ProviderApplyQueueActionAsset), true)]
    internal class ProviderApplyQueueActionAssetEditor : UnityEditor.Editor
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

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("Applies command queue in 'IActionProvider'.", MessageType.Info);
            EditorGUILayout.HelpBox("Requires 'IApplication' in context.", MessageType.Info);
        }
    }
}
