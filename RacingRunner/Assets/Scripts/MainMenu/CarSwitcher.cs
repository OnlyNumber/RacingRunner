using UnityEngine;


public class CarSwitcher : MonoBehaviour
{
    [SerializeField]
    private float distanceBetweenCars;

    private int currentCar;

    [SerializeField]
    private int maxCars;

    private Vector3 targetPosition = new Vector3(0, 0, -3);

    [SerializeField]
    private FirebaseDatabaseController _firebase;

    private void Start()
    {
        _firebase.onDataLoadedPlayer += InitializeCar;
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

        ChangeCar();
    }

    public void ChangeCar()
    {
        _firebase.ChangeCurrentUser(_firebase.userDataTransfer.id, _firebase.userDataTransfer.nickName, _firebase.userDataTransfer.goldCoins, _firebase.userDataTransfer.avatarIcon, _firebase.userDataTransfer.bestTime, currentCar);

        DataHolder.car = currentCar;
    }

    private void InitializeCar()
    {
        Move(_firebase.userDataTransfer.car);
    }




}
