using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieChart : MonoBehaviour
{

    public ReadmeEditor editor;
    public Image[] segments; // ������ �� UI �������� Image
    public Text[] textset;
    public float[] percentages; // �������� ��� ������� ��������

    void Start()
    {
        UpdatePieChart();
    }

    public void UpdatePieChart()
    {
        percentages = new float[] { editor.ZenjectPercent, editor.OdinPercent, editor.AssetBundlePercent, editor.UniRxPercent };
        float total = 0;
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].fillAmount = percentages[i] / 100f;
            total += segments[i].fillAmount;
            textset[i].text = "total : " + percentages[i];
            ImageSaver.instance.SaveImageAsPNG(segments[i], "NewImageBar", "Bar " +  i);
        }

        // �������� �� ������������ ����� ���������
        if (total > 1)
        {
            Debug.LogError("����� ����� ��������� ��������� 100%");
        }
    }
}
