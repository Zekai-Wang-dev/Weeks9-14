using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyRandom : MonoBehaviour
{
    public UnityEvent startCollapse;

    public CinemachineVirtualCamera virtualCamera; 

    public List<GameObject> buildings; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseRandom()
    {

        int randomIndex = Random.Range(0, buildings.Count-1);

        GameObject selectedBuilding = buildings[randomIndex];
        BuildingController buildController = selectedBuilding.GetComponent<BuildingController>();

        startCollapse.AddListener(buildController.beginCollapse);

        virtualCamera.Follow = selectedBuilding.GetComponent<Transform>(); 

        startCollapse.Invoke();

        buildings.Remove(buildings[randomIndex]);

    }

}
