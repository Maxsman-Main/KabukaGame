using UnityEngine;
using UnityEditor;
using Codice.Client.Common.GameUI;
using UnityEngine.Rendering;
using UnityEditor.PackageManager;
using UnityEditor.SceneManagement;

public class Randomizer : EditorWindow
{
    bool mirrorX, mirrorY, mirrorZ, randomX, randomY, randomZ;
    [MenuItem("Utils/Randomiser")]
    // Start is called before the first frame update
    static void Init()
    {
        Randomizer window = (Randomizer)GetWindow(typeof(Randomizer));
        window.Show();
    }
    private void OnGUI()
    {
        GUILayout.Label("Add rotation to selected", EditorStyles.boldLabel);
        randomX = EditorGUILayout.Toggle("Rotate on X", randomX);
        randomY = EditorGUILayout.Toggle("Rotate on Y", randomY);
        randomZ = EditorGUILayout.Toggle("Rotate on Z", randomZ);

        if (GUILayout.Button("Randomise 90"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                Undo.RecordObject(go.transform, "RandomRotation");
                go.transform.rotation = Quaternion.Euler(GetRandomRotations90(go.transform.rotation.eulerAngles));
            }
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        if (GUILayout.Button("Randomise 180"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                Undo.RecordObject(go.transform, "RandomRotation");
                go.transform.rotation = Quaternion.Euler(GetRandomRotations180(go.transform.rotation.eulerAngles));
            }
        }
    }
    private Vector3 GetRandomRotations90(Vector3 currentRotation)
    {
        float x = randomX ? currentRotation.x + Random.Range(0, 4) * 90f : currentRotation.x;
        float y = randomY ? currentRotation.y + Random.Range(0, 4) * 90f : currentRotation.y;
        float z = randomZ ? currentRotation.z + Random.Range(0, 4) * 90f : currentRotation.z;

        return new Vector3(x, y, z);
    }
    private Vector3 GetRandomRotations180(Vector3 currentRotation)
    {
        float x = randomX ? currentRotation.x + Random.Range(0, 2) * 180f : currentRotation.x;
        float y = randomY ? currentRotation.y + Random.Range(0, 2) * 180f : currentRotation.y;
        float z = randomZ ? currentRotation.z + Random.Range(0, 2) * 180f : currentRotation.z;

        return new Vector3(x, y, z);
    }
}
