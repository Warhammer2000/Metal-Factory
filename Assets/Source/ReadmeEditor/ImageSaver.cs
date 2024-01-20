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
        // ���� � ����� Assets
        string assetsFolderPath = Application.dataPath;

        // ������ ���� � ����� �����
        string folderPath = Path.Combine(assetsFolderPath, folderName);

        // ���� ����� �� ����������, ������ �
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // ������ ���� � �����
        string fullPath = Path.Combine(folderPath, fileName + ".png");

        // �������� ����� ��� ���������� ��������
        SaveTextureAsPNG(ConvertImageToTexture(image), fullPath);
    }

    private Texture2D ConvertImageToTexture(Image image)
    {
        Sprite sprite = image.sprite;

        // ������� Texture2D � ��������� �������� �������� �������
        Texture2D texture = new Texture2D((int)sprite.texture.width, (int)sprite.texture.height);

        // �������� ��� ������� �� �������� �������� � �����
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
