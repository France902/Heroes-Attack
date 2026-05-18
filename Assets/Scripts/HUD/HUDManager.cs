
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{

    public TextMeshProUGUI textHUD;

    private int money = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        refreshHUD();
    }

    private void refreshHUD()
    {
        textHUD.text = money + " money";
    }
}
