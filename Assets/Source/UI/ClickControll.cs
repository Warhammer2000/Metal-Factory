using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControll : MonoBehaviour
{
    public Animator Anim;
    private bool isTriggered = false;
    private void OnMouseDown()
    {

        isTriggered = !isTriggered;
        Anim.SetBool("IsClicked", isTriggered); // Устанавливаем триггер
    
    }
}
