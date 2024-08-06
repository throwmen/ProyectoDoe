using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public float maxStamina = 100f;
    public float decreaseRate = 10f;
    public float refillDelay = 3f;

    private float currentStamina;

    private void Start()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        if (currentStamina > 0f)
        {
            currentStamina -= decreaseRate * Time.deltaTime;
            slider.value = currentStamina / maxStamina;
        }
        else
        {
            // Aquí puedes realizar alguna acción cuando la estamina se agote,
            // como desactivar el sprint del jugador.

            // Si quieres que la barra de estamina desaparezca después de un tiempo,
            // puedes desactivar el objeto que contiene la barra aquí mismo.
        }
    }

    public void RefillStamina()
    {
        currentStamina = maxStamina;
        slider.value = 1f;
    }

    public void StartRefillDelay()
    {
        Invoke("RefillStamina", refillDelay);
    }
}