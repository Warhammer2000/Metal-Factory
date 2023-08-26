using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public float zoomSpeed = 2.0f;
    public float minZoomDistance = 3.0f;
    public float maxZoomDistance = 10.0f;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private CinemachineFramingTransposer framingTransposer;

    private bool isZoomingIn = false;
    private bool isZoomingOut = false;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.AddCinemachineComponent<CinemachineFramingTransposer>();
        if (Check())
        {
            Debug.Log("ADded");
        }
        else Debug.Log("Huinya");
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    private bool Check()
    {
        if (virtualCamera.AddCinemachineComponent<CinemachineFramingTransposer>())
        {
            return true;
        }
        else return false;
    }
    private void Start()
    {
       // virtualCamera = GetComponent<CinemachineVirtualCamera>();
      //  
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            HandleMobileInput();
            Debug.Log("Mobile");
        }
        else
        {
            Debug.Log("PC");
            HandleMouseInput();
        }
    }

    private void HandleMobileInput()
    {
        if (isZoomingIn)
        {
            framingTransposer.m_CameraDistance -= zoomSpeed * Time.deltaTime;
        }

       
        if (isZoomingOut)
        {
            framingTransposer.m_CameraDistance += zoomSpeed * Time.deltaTime;
        }

        framingTransposer.m_CameraDistance = Mathf.Clamp(framingTransposer.m_CameraDistance, minZoomDistance, maxZoomDistance);
    }

    private void HandleMouseInput()
    {
        // Управление приближением и удалением с помощью колесика мыши или другого ввода
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        framingTransposer.m_CameraDistance -= zoomInput * zoomSpeed;

        // Ограничение диапазона приближения/удаления
        framingTransposer.m_CameraDistance = Mathf.Clamp(framingTransposer.m_CameraDistance, minZoomDistance, maxZoomDistance);
    }
    public void StartZoomIn()
    {
        isZoomingIn = true;
    }

    public void StopZoomIn()
    {
        isZoomingIn = false;
    }

    public void StartZoomOut()
    {
        isZoomingOut = true;
    }

    public void StopZoomOut()
    {
        isZoomingOut = false;
    }
}
