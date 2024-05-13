using UnityEditor;
using UnityEngine;

public class BasicObjectSpawner : EditorWindow
{
    GameObject objectToSpawn;
    string objectBaseName = "";
    int objetID = 1;
    float objectScale;
    float spawnRadius = 5f;

    [MenuItem("Tools/Basic Object Spawner")]
    public static void ShowWindow() {
        GetWindow(typeof(BasicObjectSpawner));
    }

    private void OnGUI() {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);

        objectBaseName = EditorGUILayout.TextField("Base Name", objectBaseName);
        objetID = EditorGUILayout.IntField("Object ID", objetID);
        objectScale = EditorGUILayout.Slider("Object Scale", objectScale, 0.5f,3f);
        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn ",objectToSpawn,typeof(GameObject), false)as GameObject;

        if (GUILayout.Button("Spawn Object")) {
            SpawnObject();
        }
    }

    private void SpawnObject() {
        if (objectToSpawn == null) {
            Debug.LogError("ERROR: Please assing an object to be spawned.");
            return;
        }
        if(objectBaseName == string.Empty) {
            Debug.LogError("ERROR: Please enter a base name for the object.");
            return;
        }

        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject newObject = Instantiate(objectToSpawn,spawnPos, Quaternion.identity);
        newObject.name = objectBaseName + objectScale;
        newObject.transform.localScale =  Vector3.one * objectScale;

        objetID++;
    }
}
