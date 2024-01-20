using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageSaver : MonoBehaviour
{

    public static ImageSaver instance;
    private void Awake()
    {
        instance = this;
    }
    public void SaveImageAsPNG(Image image, string folderName, string fileName)
    {
        // Путь к папке Assets
        string assetsFolderPath = Application.dataPath;

        // Создаём путь к новой папке
        string folderPath = Path.Combine(assetsFolderPath, folderName);

        // Если папка не существует, создаём её
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Полный путь к файлу
        string fullPath = Path.Combine(folderPath, fileName + ".png");

        // Вызываем метод для сохранения текстуры
        SaveTextureAsPNG(ConvertImageToTexture(image), fullPath);
    }

    private Texture2D ConvertImageToTexture(Image image)
    {
        Sprite sprite = image.sprite;

        // Создаем Texture2D с размерами исходной текстуры спрайта
        Texture2D texture = new Texture2D((int)sprite.texture.width, (int)sprite.texture.height);

        // Копируем все пиксели из исходной текстуры в новую
        Color[] pixels = sprite.texture.GetPixels();
        texture.SetPixels(pixels);
        texture.Apply();

        return texture;
    }

    private void SaveTextureAsPNG(Texture2D texture, string fullPath)
    {
        byte[] pngData = texture.EncodeToPNG();
        if (pngData != null)
        {
            File.WriteAllBytes(fullPath, pngData);
            Debug.Log("Saved Image to: " + fullPath);
        }
    }
}
