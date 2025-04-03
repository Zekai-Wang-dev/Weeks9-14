using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Tilemaps;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BuildingController : MonoBehaviour
{

    public GameObject building; 
    public Coroutine buildingCollapse;

    public CinemachineImpulseSource impulse; 

    public Transform transform;

    public float rotateSpeed;

    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    private void Awake()
    {

        transform = GetComponent<Transform>();
        impulse = GetComponent<CinemachineImpulseSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.eulerAngles.z >= 90)
        {
            Destroy(building);
        }

    }

    public IEnumerator collapsing()
    {
        float t = 0;

        float rotationZ;

        float originalZ = transform.eulerAngles.z;

        while (transform.eulerAngles.z < 90)
        {
            t += Time.deltaTime;
            rotationZ = Mathf.Lerp(originalZ, 90f, curve.Evaluate(t*rotateSpeed));

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationZ);
            yield return 0;

        }
    }

    public void beginCollapse()
    {
        impulse.GenerateImpulse();
        buildingCollapse = StartCoroutine(collapsing());

    }

}
