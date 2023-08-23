using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    public GameObject buildingPrefab; 
    public GameObject projectionPrefab; 

    private GameObject currentBuilding; 
    private GameObject currentProjection;

    private BuildingBrain _brain;

    private bool isPlacing = false;
    private bool isCanseled = false;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        _brain = GetComponent<BuildingBrain>();
    }

    private void Update()
    {
        if (isPlacing)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.transform.position.y - transform.position.y;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            if (currentBuilding)
                currentBuilding.transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);

            ProjectionDisplay();

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (_brain.CanBuildBuilding(_brain.buildingPrices))
                    {
                        Instantiate(buildingPrefab, hit.point, Quaternion.identity);
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPlacing = false;
                isCanseled = true;
                StopPlacing();
            }
        }
    }
    private void ProjectionDisplay()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!isCanseled)
        {
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 projectionPosition = hit.point;
                //projectionPosition.y = 0.01f; 
                currentProjection.transform.position = projectionPosition;
            }
            Material projectionMaterial = currentProjection.GetComponent<Renderer>().material;
            Color projectionColor = projectionMaterial.color;
            projectionColor.a = 0.5f; // ѕримерное значение дл€ полупрозрачности
            projectionMaterial.color = projectionColor;
        }
    }
    public void StartPlacing()
    {
        isPlacing = true;
        currentProjection = Instantiate(projectionPrefab);
        
    }

    public void StopPlacing()
    {
        isPlacing = false;

        if (currentBuilding)
            Destroy(currentBuilding);

        if (currentProjection)
            Destroy(currentProjection);
    }
}
