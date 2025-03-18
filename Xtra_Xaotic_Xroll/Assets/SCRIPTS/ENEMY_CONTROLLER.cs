using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_CONTROLLER : MonoBehaviour
{
    public float enemyHealth;
<<<<<<< Updated upstream
    public string targetTag = "YourBase"; // Tag del objetivo (la base)
    public float moveSpeed = 3f; // Velocidad de movimiento
    public float attackRange = 1.5f; // Rango de ataque
    public float attackCooldown = 1f; // Tiempo entre ataques
    private float lastAttackTime = 0f; // Tiempo del �ltimo ataque
    private Transform targetPosition; // Posici�n a la que se mover� el enemigo
=======
    public GameObject drop;  // Prefab del drop
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto desde el cual se disparan los proyectiles
    public float shootingCooldown = 2f; // Tiempo de espera entre disparos
    private float lastShotTime = 0f; // �ltima vez que se dispar� un proyectil

    private bool hasDropped = false; // Variable para verificar si el drop ya fue generado
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 10;

        // Buscar el GameObject con el tag "YourBase" y obtener su Transform
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        if (targetObject != null)
        {
            targetPosition = targetObject.transform; // Asignar la posici�n de la base
        }
        else
        {
            Debug.LogWarning("No se encontr� un objeto con el tag 'YourBase'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        // Verificar la salud del enemigo
        if (enemyHealth <= 0)
        {
            Destroy(gameObject); // Eliminar el enemigo si su salud es 0 o menos
        }

        // Asegurarse de que el objetivo haya sido encontrado
        if (targetPosition != null)
        {
            // Mover al enemigo hacia la posici�n de destino
            MoveTowardsTarget();

            // Comprobar si est� en rango de ataque y puede atacar
            if (Vector3.Distance(transform.position, targetPosition.position) <= attackRange)
            {
                Attack();
            }
        }
    }

    // M�todo para mover al enemigo hacia la posici�n del objetivo
    private void MoveTowardsTarget()
    {
        // Mover al enemigo hacia la posici�n de destino
        Vector3 direction = (targetPosition.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
    }

    // M�todo de ataque
    private void Attack()
    {
        // Comprobar si el enemigo puede atacar (si ha pasado el tiempo de cooldown)
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Realizar el ataque
            Debug.Log("�El enemigo ataca!");

            // Actualizar el tiempo del �ltimo ataque
            lastAttackTime = Time.time;

            // Aqu� podr�as agregar m�s l�gica para aplicar da�o, como un sistema de salud al objetivo
=======
        // Verificar si el enemigo puede disparar
        if (Time.time - lastShotTime >= shootingCooldown)
        {
            Shoot();
            lastShotTime = Time.time; // Actualiza el tiempo del �ltimo disparo
        }

        // Verificar la salud del enemigo
        if (enemyHealth <= 0 && !hasDropped) // Verifica si el enemigo debe morir
        {
            // Antes de destruir al enemigo, generamos los drops
            GenerateDrop();
            hasDropped = true; // Marca que el drop ha sido generado
            Destroy(gameObject); // Eliminar al enemigo
        }
    }

    // M�todo para disparar el proyectil
    void Shoot()
    {
        if (projectilePrefab != null && shootingPoint != null)
        {
            // Crear el proyectil en el punto de disparo
            Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
>>>>>>> Stashed changes
        }
    }

    // M�todo para recibir da�o
    public void GetDamage()
    {
        enemyHealth -= 2;
<<<<<<< Updated upstream
        Debug.Log("El enemigo ha recibido da�o. Salud restante: " + enemyHealth);
    }
=======
        // Solo generar drop si la salud llega a 0 y no se ha generado un drop a�n
        if (enemyHealth <= 0 && !hasDropped)
        {
            GenerateDrop();
            hasDropped = true; // Marca que el drop ha sido generado
            Destroy(gameObject); // Eliminar al enemigo
        }
    }

    // M�todo para generar el drop cuando el enemigo es destruido
    public void GenerateDrop()
    {
        if (drop != null)
        {
            // Generar el drop en la posici�n del enemigo
            Instantiate(drop, transform.position, Quaternion.identity);
        }
    }
>>>>>>> Stashed changes
}


