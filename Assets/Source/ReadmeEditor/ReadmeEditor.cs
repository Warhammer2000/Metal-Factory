using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadmeEditor : MonoBehaviour
{
    // Вызывается при старте сцены
    public int ZenjectPercent;
    public int AssetBundlePercent;
    public int OdinPercent;
    public int UniRxPercent;
    void Awake()
    {
        EditReadmeFile();
    }

    // Метод для чтения и вывода содержимого файла README.md
    public void ReadAndLogReadmeFile()
    {
        string projectRootPath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        string readmePath = Path.Combine(projectRootPath, "README.md");

        if (File.Exists(readmePath))
        {
            string content = File.ReadAllText(readmePath);
            Debug.Log("Содержимое README.md:\n" + content);
        }
        else
        {
            Debug.Log("Файл README.md не найден.");
        }
    }

    void EditReadmeFile()
    {
        string projectRootPath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        string readmePath = Path.Combine(projectRootPath, "README.md");

        if (File.Exists(readmePath))
        {
            string content = File.ReadAllText(readmePath);

            // Здесь мы обновляем проценты для каждой технологии
            //content = Regex.Replace(content, @"Zenject \d+%", $"Zenject: {ZenjectPercent}%");
            //content = Regex.Replace(content, @"Odin Inspector \d+%", $"Odin Inspector: {OdinPercent}%");
            //content = Regex.Replace(content, @"Asset Bundle \d+%", $"Asset Bundle: {AssetBundlePercent}%");
            //content = Regex.Replace(content, @"UniRx \d+%", $"UniRx: {UniRxPercent}%");
            content = Regex.Replace(content, @"\|\s*Zenject\s*\|\s*\d+%\s*\|", $"| Zenject            |     {ZenjectPercent}% |");
            content = Regex.Replace(content, @"\|\s*\*\*Odin Inspector\*\*\s*\|\s*\*\*\d+%\*\*\s*\|", $"| **Odin Inspector** | **{OdinPercent}%** |");
            content = Regex.Replace(content, @"\|\s*\*\*Asset Bundle\*\*\s*\|\s*\*\*\d+%\*\*\s*\|", $"| **Asset Bundle**   | **{AssetBundlePercent}%** |");
            content = Regex.Replace(content, @"\|\s*\*\*UniRx\*\*\s*\|\s*\*\*\d+%\*\*\s*\|", $"| **UniRx**          | **{UniRxPercent}%** |");
            File.WriteAllText(readmePath, content);
            Debug.Log("README.md успешно обновлен.");
        }
        else
        {
            Debug.Log("Файл README.md не найден.");
        }
    }
}
