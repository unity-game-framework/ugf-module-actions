using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionSystemUpdateAsset), true)]
    internal class ActionSystemUpdateAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyUpdateGroup;
        private AssetIdReferenceListDrawer m_listActions;
        private ReorderableListSelectionDrawer m_listActionsSelection;

        private void OnEnable()
        {
            m_propertyUpdateGroup = serializedObject.FindProperty("m_updateGroup");

            m_listActions = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_actions"))
            {
                DisplayAsSingleLine = true
            };

            m_listActionsSelection = new ReorderableListSelectionDrawerByPath(m_listActions, "m_asset")
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

                EditorGUILayout.PropertyField(m_propertyUpdateGroup);

                m_listActions.DrawGUILayout();
                m_listActionsSelection.DrawGUILayout();
            }
        }
    }
}
