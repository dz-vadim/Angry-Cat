using UnityEngine;
using UnityEngine.UI; //add
public class UIHealthController : MonoBehaviour
{
    private Slider healtBar;
    private void Awake()
    {
        healtBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    public void SetUpHealthBar(int startValue)
    {
        healtBar.maxValue = startValue;
        healtBar.value = startValue;
    }

    public void UpdateHealthBar(int value)
    {
        healtBar.value = value;
    }
}