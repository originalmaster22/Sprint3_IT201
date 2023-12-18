using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor;

public class CreatePrefab : MonoBehaviour
{
    [Range(1f, 30f)] [SerializeField] private float distance = 10f;
    [Range(-3f, 3f)] [SerializeField] private float distanceChange = 1f;
    public float rotation = 0f;
    public float rotationChange = 5f;
    public GameObject fancy;
    float posX = -1f, posY= -1f, posZ = -1f;
    public TextMeshProUGUI xPos, yPos;
    [SerializeField] public TMP_Dropdown newObject;
    public Slider red;
    public Slider green;
    public Slider blue;
    public Color newColor;
    public Material dynamicColor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        printObjects();
        printMousePos();
        changeColor();
    }

    public void printObjects() {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = new Vector3(posX,posY,posZ);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(newObject.value == 0)
            {
                if(Physics.Raycast(ray, out hit)) {
                    clickPosition = hit.point;
                    fancy.transform.position = clickPosition;
                    fancy.transform.Rotate(new Vector3(0f, rotation, 0f));
                    Instantiate(fancy);
                }
            }
            if(newObject.value == 1)
            {
                if(Physics.Raycast(ray, out hit)) {
                clickPosition = hit.point;
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                primitive.transform.position = clickPosition;
            }
            }
            if(newObject.value == 2)
            {
                if(Physics.Raycast(ray, out hit)) {
                    clickPosition = hit.point;
                    GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    primitive.transform.position = clickPosition;
                }
            }
            if(newObject.value == 3)
            {
                if(Physics.Raycast(ray, out hit)) {
                    clickPosition = hit.point;
                    GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    primitive.transform.position = clickPosition;
                }
            }
            
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distance));
            Debug.Log(clickPosition);
            distance += distanceChange;
            rotation += rotationChange;
        }
    }

    public void printMousePos() {
        xPos.text = "X: " + Input.mousePosition.x;
        yPos.text = "Y: " + Input.mousePosition.y;
    }

    public void changeColor(){
        newColor = new Color (red.value, green.value, blue.value);
        dynamicColor.color = newColor;
    }
}