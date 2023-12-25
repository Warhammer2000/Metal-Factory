using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadmeEditor : MonoBehaviour
{
    // ���������� ��� ������ �����
    public int ZenjectPercent;
    public int AssetBundlePercent;
    public int OdinPercent;
    public int UniRxPercent;
    void Start()
    {
        // ������ � ������� ���������� ����� README.md
        ReadAndLogReadmeFile();

        // ����������� ���� README.md
        //EditReadmeFile();
    }

    // ����� ��� ������ � ������ ����������� ����� README.md
    void ReadAndLogReadmeFile()
    {
        string projectRootPath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        string readmePath = Path.Combine(projectRootPath, "README.md");

        if (File.Exists(readmePath))
        {
            string content = File.ReadAllText(readmePath);
            Debug.Log("���������� README.md:\n" + content);
        }
        else
        {
            Debug.Log("���� README.md �� ������.");
        }
    }

    void EditReadmeFile()
    {
        string projectRootPath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        string readmePath = Path.Combine(projectRootPath, "README.md");

        if (File.Exists(readmePath))
        {
            string content = File.ReadAllText(readmePath);

            // ����� �� ��������� �������� ��� ������ ����������
            content = Regex.Replace(content, @"Zenject: \d+%", $"Zenject: {ZenjectPercent}% ");
            content = Regex.Replace(content, @"Odin Inspector: \d+%", $"Odin Inspector: {OdinPercent}% ");
            content = Regex.Replace(content, @"Asset Bundle: \d+%", $"Asset Bundle: {AssetBundlePercent}% ");
            content = Regex.Replace(content, @"UniRx: \d+%", $"UniRx: {UniRxPercent}% ");

            File.WriteAllText(readmePath, content);
            Debug.Log("README.md ������� ��������.");
        }
        else
        {
            Debug.Log("���� README.md �� ������.");
        }
    }
}
