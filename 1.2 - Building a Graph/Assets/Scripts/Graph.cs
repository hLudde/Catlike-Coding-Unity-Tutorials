using UnityEngine;
public class Graph : MonoBehaviour{
    public Transform pointPrefab;
    [Range (10,100)] public int Resolution = 10;

    Transform[] points;

    void Awake(){
        float step = 2f / Resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;

        position.y = 0f;
        position.z = 0f;
        points = new Transform[Resolution];

        for(int i = 0; i<points.Length; i++){
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            points[i] = point;
            point.SetParent(transform, false);
        }
    }

    void Update(){
        for(int i=0; i<points.Length; i++){
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI*(position.x+Time.time));
            point.localPosition = position;
        }
    }

}