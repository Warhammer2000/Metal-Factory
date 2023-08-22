using UnityEngine;
using Zenject;

public class UpgradeFactory : MonoBehaviour
{
    [Inject]
    private GameObject Factory—himney;

    private int ChimneyIndex = 0;
    private Vector3 spawnPositionFirst;
    private Vector3 spawnPositionSecond;
    private Vector3 spawnPositionThird;

    [SerializeField] private ResourceFactory _factory;
    private void OnValidate()
    {
        if(ChimneyIndex >= 3)
        {
            ChimneyIndex = 0;
        }
    }
    private void Awake()
    {
        if(Factory—himney != null)
        {
            Debug.Log("Injection are successfully done");
            Positioncalculation();
        }
    }
    private void Positioncalculation()
    {
        spawnPositionFirst = transform.position + Vector3.up + Vector3.up * Factory—himney.transform.localScale.y;
        spawnPositionSecond = transform.position + Vector3.up + Vector3.right * Factory—himney.transform.localScale.y;
        spawnPositionThird = transform.position + Vector3.up + Vector3.left * Factory—himney.transform.localScale.y;
    }
    public void UpgradeButton()
    {
        if(ChimneyIndex == 0)
        {
            Instantiate(Factory—himney, spawnPositionFirst, Quaternion.identity);
            ChimneyIndex++;
            _factory.generationInterval -= 1;
        }
        else if(ChimneyIndex == 1)
        {
            Instantiate(Factory—himney, spawnPositionSecond, Quaternion.identity);
            ChimneyIndex++;
            _factory.generationInterval -= 1;
        }
        else if (ChimneyIndex == 2)
        {
            Instantiate(Factory—himney, spawnPositionThird, Quaternion.identity);
            ChimneyIndex++;
            _factory.generationInterval -= 1;
        }
    }
}
