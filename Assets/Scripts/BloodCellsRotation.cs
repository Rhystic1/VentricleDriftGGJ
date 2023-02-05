using Unity.VisualScripting;
using UnityEngine;

public class BloodCellsRotation : MonoBehaviour
{
    [SerializeField]
    public float RotationSpeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.IsDestroyed())
            {
                RotateEnemy(enemy, RotationSpeed, RotationSpeed, RotationSpeed);
            }
        }
    }
    void RotateEnemy(GameObject enemy, float rotationX, float rotationY, float rotationZ)
    {
        Quaternion rotation = enemy.transform.rotation;
        rotation *= Quaternion.Euler(rotationX * RotationSpeed, rotationY * RotationSpeed, rotationZ * RotationSpeed);
        enemy.transform.rotation = rotation;
    }
}
