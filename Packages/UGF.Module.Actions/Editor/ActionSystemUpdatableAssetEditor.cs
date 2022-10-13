using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionSystemUpdatableAsset), true)]
    internal class ActionSystemUpdatableAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listActions;
        private ReorderableListSelectionDrawer m_listActionsSelection;

        private void OnEnable()
        {
            m_listActions = new ReorderableListDrawer(serializedObject.FindProperty("m_actions"));

            m_listActionsSelection = new ReorderableListSelectionDrawerByElement(m_listActions)
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listActions.Enable();
            m_listActionsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listActions.Disable();
            m_listActionsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listActions.DrawGUILayout();
                m_listActionsSelection.DrawGUILayout();
            }
        }
    }
}
