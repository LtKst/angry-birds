using UnityEditor;
using UnityEngine;

public class TrailEditor : EditorWindow {

    public GameObject trail;
    public bool drawing;

    Vector2 pos = Vector2.zero;

    [MenuItem("Window/Draw trail")]
    private static void Init() {
        // Get existing open window or if none, make a new one:
        TrailEditor window = (TrailEditor)GetWindow(typeof(TrailEditor));
        window.titleContent = new GUIContent("Trail Drawer");
        window.Show();
    }

    private void OnGUI() {
        if (SceneView.onSceneGUIDelegate != this.OnSceneGUI) {
            SceneView.onSceneGUIDelegate += this.OnSceneGUI;
        }

        GUILayout.Label("Trail editor tool", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        trail = (GameObject)EditorGUILayout.ObjectField(trail, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();

        drawing = EditorGUILayout.Toggle("Draw", drawing);
    }

    public void OnSceneGUI(SceneView scnView) {
        Event e = Event.current;

        if (e.type == EventType.dragPerform || e.type == EventType.dragUpdated && e.button == 0 && drawing) {
            Vector3 mousePosition = e.mousePosition;
            Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
            mousePosition = ray.origin;

            if (Vector2.Distance(pos, mousePosition) > 10) {
                GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(trail);
                obj.transform.position = mousePosition;
                Undo.RegisterCreatedObjectUndo(obj, "Created obj");

                pos = mousePosition;

                Debug.Log("test");
            }

            Debug.Log("dd");
        }
    }
}
