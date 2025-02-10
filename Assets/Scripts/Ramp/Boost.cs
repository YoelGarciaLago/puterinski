using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    // Fuerza a aplicar a la pelota cuando entra en el trigger
    // Sugerencia: Usa [SerializeField] para hacerlo configurable desde el editor de Unity.
    private Vector3 impulseForce = new Vector3(0, 5, 12);

    // Indica si la fuerza debe aplicarse en relación al sistema de coordenadas de la rampa
    // Sugerencia: Usa [SerializeField] para mayor flexibilidad.
    private bool aplicarFuerzaRelativaRampa = true;

    // Método que se ejecuta al detectar que un objeto entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto tiene el tag "Pelota"
        if (other.CompareTag("Player"))
        {
            // Intentamos obtener el componente Rigidbody del objeto
            Rigidbody pelotaRigidBody = other.GetComponent<Rigidbody>();

            // Verificamos si el Rigidbody no es nulo
            if (pelotaRigidBody != null)
            {
                // Inicializamos la fuerza que se aplicará
                Vector3 fuerzaAplicar = impulseForce;

                // Si aplicarFuerzaRelativaRampa es true, convertimos la fuerza al sistema de coordenadas de la rampa
                if (aplicarFuerzaRelativaRampa)
                {
                    fuerzaAplicar = transform.TransformDirection(impulseForce);
                }

                // Aplicamos la fuerza al Rigidbody con el modo de impulso
                pelotaRigidBody.AddForce(fuerzaAplicar, ForceMode.Impulse);
            }
            else
            {
                // Sugerencia: Podrías agregar un mensaje de error para depuración si el Rigidbody es nulo
                Debug.LogWarning("El objeto con tag 'Pelota' no tiene un Rigidbody asignado.");
            }
        }
        else
        {
            // Sugerencia: Si se espera manejar otros casos, podrías agregar lógica adicional aquí
            Debug.Log("Un objeto sin el tag 'Pelota' ha activado el trigger.");
        }
    }
}