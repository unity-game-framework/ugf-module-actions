using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionSystemListAsset), true)]
    internal class ActionSystemListAssetEditor : UnityEditor.Editor
    {
        private AssetIdReferenceListDrawer m_listActions;
        private ReorderableListSelectionDrawer m_listActionsSelection;
        private ReorderableListDrawer m_listCollections;
        private ReorderableListSelectionDrawerByElement m_listCollectionsSelection;

        private void OnEnable()
        {
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

            m_listCollections = new ReorderableListDrawer(serializedObject.FindProperty("m_collections"));

            m_listCollectionsSelection = new ReorderableListSelectionDrawerByElement(m_listCollections)
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listActions.Enable();
            m_listActionsSelection.Enable();
            m_listCollections.Enable();
            m_listCollectionsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listActions.Disable();
            m_listActionsSelection.Disable();
            m_listCollections.Disable();
            m_listCollectionsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listActions.DrawGUILayout();
                m_listCollections.DrawGUILayout();

                m_listActionsSelection.DrawGUILayout();
                m_listCollectionsSelection.DrawGUILayout();
            }
        }
    }
}
