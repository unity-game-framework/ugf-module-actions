using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionSystemDefaultAsset), true)]
    internal class ActionSystemAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScript;
        private SerializedProperty m_propertyGroup;
        private ReorderableListDrawer m_listActions;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");
            m_propertyGroup = serializedObject.FindProperty("m_group");
            m_listActions = new ReorderableListDrawer(serializedObject.FindProperty("m_actions"));

            m_listActions.Enable();
        }

        private void OnDisable()
        {
            m_listActions.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(m_propertyScript);
                }

                EditorGUILayout.PropertyField(m_propertyGroup);

                m_listActions.DrawGUILayout();
            }
        }
    }
}
