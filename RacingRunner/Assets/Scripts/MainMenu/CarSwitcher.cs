using UnityEngine;


public class CarSwitcher : MonoBehaviour
{
    [SerializeField]
    private float distanceBetweenCars;

    private int currentCar;

    [SerializeField]
    private int maxCars;

    private Vector3 targetPosition = new Vector3(0, 0, -3);

    private void Start()
    {
        currentCar = 0;
    }

    

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
    }

    public void Move(int distance)
    {
        if (currentCar + distance >= 0 && currentCar + distance < maxCars)
        {
            currentCar += distance;


            targetPosition = new Vector3(distanceBetweenCars * -currentCar, 0, -3);
        }
    }

    

    

}
