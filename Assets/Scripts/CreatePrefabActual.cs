using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEditor.Animations;

public class CreatePrefabActual : MonoBehaviour
{
    [Range(1f, 30f)] [SerializeField] private float distance = 10f;
    [Range(-3f, 3f)] [SerializeField] private float distanceChange = 1f;
    public float rotation = 0f;
    public float rotationChange = 5f;
    public GameObject fancy;
    float posX = -1f, posY= -1f, posZ = -1f;
    int pickupCount = 0;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        printObjects();
        destroyObjects();
    }

    public void printObjects() {
        if(Input.GetMouseButtonDown(0) && pickupCount!=0)
        {
            Vector3 clickPosition = new Vector3(posX,posY,posZ);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit)) {
                clickPosition = hit.point;
                fancy.transform.position = clickPosition;
                fancy.transform.Rotate(new Vector3(0f, rotation, 0f));
                fancy.transform.parent = this.transform;
                Instantiate(fancy);
            }
            
            
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distance));
            Debug.Log(clickPosition);
            distance += distanceChange;
            rotation += rotationChange;
            pickupCount-=1;
        }
    }

    public void destroyObjects() {
        if(Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == fancy) {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}