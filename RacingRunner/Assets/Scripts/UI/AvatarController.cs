using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarController : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _avatarImages;

    [SerializeField]
    private GameObject _avatarGrid;

    [SerializeField]
    private Button avatarIconButton;

    [SerializeField]
    private Image avatarIcon;

    [SerializeField]
    private MenuController menuController;

    [SerializeField]
    private FirebaseDatabaseControllerMenu firebase;

    private void Start()
    {
        Button transferButton;

        int i = 0;

        foreach (var item in _avatarImages)
        {
            transferButton = Instantiate(avatarIconButton);
            transferButton.gameObject.AddComponent<ButtonAvatarChanger>().Initialize(item, avatarIcon, firebase, i);
            transferButton.onClick.AddListener(transferButton.gameObject.GetComponent<ButtonAvatarChanger>().ChangeIcon);
            transferButton.transform.SetParent(_avatarGrid.transform);
            transferButton.image.sprite = item;
            i++;
        }

        menuController.GoToMainUI();
    }

    public void SetAvatarStart(int imageNumber)
    {
        avatarIcon.sprite = _avatarImages[imageNumber];
    }
 
    



}
