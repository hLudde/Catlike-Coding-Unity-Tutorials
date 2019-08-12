﻿using System.Collections;
using UnityEngine;

public class Fractal : MonoBehaviour
{

    [Range (0,10)] public int maxDepth;
    private int depth;

    public float maxRotationSpeed;
    private float rotationSpeed;

    public float maxTwist;

    [Range (0f, 1f)] public float spawnProbability;

    public float childScale;
    public Material material;
    public Mesh[] meshes;
    private Material[,] materials;

    private static Vector3[] childDirections = {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] childOrientations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

    void Start(){
        if(materials==null){
            InitializeMaterials();
        }
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
        gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
        gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0,2)];
        if(depth < maxDepth){
            StartCoroutine(CreateChildren());
        }
    }

    private void Update(){
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private IEnumerator CreateChildren(){
        for(int i = 0; i<childDirections.Length; i++){
            if(Random.value < spawnProbability){
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
            }
        }
    }

    void Initialize(Fractal parent, int childIndex){
        meshes = parent.meshes;
        materials = parent.materials;
        material = parent.material;
        maxDepth = parent.maxDepth;
        spawnProbability = parent.spawnProbability;
        maxRotationSpeed = parent.maxRotationSpeed;
        maxTwist = parent.maxTwist;
        depth = parent.depth+1;
        childScale = parent.childScale;
        transform.SetParent(parent.transform);
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }

    private void InitializeMaterials(){
        materials = new Material[maxDepth+1, 2];
        for(int i = 0; i <= maxDepth; i++){
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i, 0] = new Material(material);
            materials[i, 0].color = Color.Lerp(Color.white, Color.red, t);
            materials[i, 1] = new Material(material);
            materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
        }
        materials[maxDepth, 0].color = Color.blue;
        materials[maxDepth, 1].color = Color.yellow;
    }
}
