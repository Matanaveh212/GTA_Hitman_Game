using UnityEngine;

public class CarEnterExit : MonoBehaviour
{
    public bool isInCar;
    public float enterDistance = 1f;
    public GameObject carCanvas;
    public GameObject ECanvas;
    Collider playerCollider;
    GameObject playerCanvas;
    Minimap minimapCamera;
    VehicleControl vehicleControl;

    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
        playerCanvas = GameObject.FindGameObjectWithTag("PlayerCanvas");
        minimapCamera = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Minimap>();
        vehicleControl = GetComponent<VehicleControl>();
        vehicleControl.activeControl = false;
        carCanvas.SetActive(false);
        playerCanvas.SetActive(true);

    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerCollider.transform.position);
        
        if (distance <= enterDistance) 
        {
            if (ECanvas)
            {
                ECanvas.SetActive(true);
                ECanvas.transform.LookAt(playerCollider.gameObject.transform);
            }
        }

        if (distance > enterDistance)
        {
            if (ECanvas)
            {
                ECanvas.SetActive(false);
            }
        }

        if (distance <= enterDistance && !isInCar && Input.GetKeyDown(KeyCode.E))
        {
            isInCar = true;
            minimapCamera.target = this.gameObject;
            carCanvas.SetActive(true);
            playerCanvas.SetActive(false);
            vehicleControl.activeControl = true;
            playerCollider.gameObject.SetActive(false);
            if (ECanvas)
            {
                ECanvas.SetActive(false);
            }
        }

        else if (isInCar && Input.GetKeyDown(KeyCode.E) && vehicleControl.speed < 5)
        {
            isInCar = false;
            minimapCamera.target = playerCollider.gameObject;
            carCanvas.SetActive(false);
            playerCanvas.SetActive(true);
            vehicleControl.activeControl = false;
            playerCollider.gameObject.transform.position = GameObject.FindGameObjectWithTag("PlayerPoint").transform.position;
            playerCollider.gameObject.transform.rotation = GameObject.FindGameObjectWithTag("PlayerPoint").transform.rotation;
            playerCollider.gameObject.SetActive(true);
        }
    }
}
