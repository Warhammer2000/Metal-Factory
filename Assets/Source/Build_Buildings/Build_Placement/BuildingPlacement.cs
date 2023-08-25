using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
   

    public GameObject buildingPrefab; 
    public GameObject projectionPrefab; 

    private GameObject currentBuilding; 
    private GameObject currentProjection;

    private BuildingBrain _brain;

    [SerializeField] private bool isBuildButtonPushed = false;
    [SerializeField] private bool isPlacing = false;
    private bool isCanseled = false;

    private Camera mainCamera;
   
    private void Start()
    {
        
        mainCamera = Camera.main;
        _brain = GetComponent<BuildingBrain>();
    }

    private void Update()
    {
        if (isBuildButtonPushed)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.transform.position.y - transform.position.y;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            if (currentBuilding)
                currentBuilding.transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);

            ProjectionDisplay();
            if (isPlacing)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.collider.gameObject.tag);
                        if(hit.collider.CompareTag("Wall"))
                        {
                            Debug.Log("NS XJHN");
                            return;
                        }
                        else
                        {
                            if (_brain.CanBuildBuilding(_brain.buildingPrices))
                            {
                                Instantiate(buildingPrefab, hit.point, Quaternion.identity);
                                Debug.LogWarning("�� �������� �����");
                            }
                            else
                            {
                                Debug.LogWarning("�� �� ������ ������ ������ ");
                            }
                        }
                       
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isBuildButtonPushed = false;
                isPlacing = false;
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
                currentProjection.transform.position = projectionPosition;
            }
            Material projectionMaterial = currentProjection.GetComponent<Renderer>().material;
            Color projectionColor = projectionMaterial.color;
            projectionColor.a = 0.5f; // ��������� �������� ��� ����������������
            projectionMaterial.color = projectionColor;
        }
    }
    public void StartPlacing()
    {
        isBuildButtonPushed = true;
        currentProjection = Instantiate(projectionPrefab);
        isPlacing = true;
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
