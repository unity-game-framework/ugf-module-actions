using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Actions.Runtime;
using UnityEditor;

namespace UGF.Module.Actions.Editor
{
    [CustomEditor(typeof(ActionModuleAsset), true)]
    internal class ActionModuleAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listSystems;
        private ReorderableListSelectionDrawer m_listSystemsSelection;

        private void OnEnable()
        {
            m_listSystems = new ReorderableListDrawer(serializedObject.FindProperty("m_systems"))
            {
                DisplayAsSingleLine = true
            };

            m_listSystemsSelection = new ReorderableListSelectionDrawerByPath(m_listSystems, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listSystems.Enable();
            m_listSystemsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listSystems.Disable();
            m_listSystemsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listSystems.DrawGUILayout();
                m_listSystemsSelection.DrawGUILayout();
            }
        }
    }
}
