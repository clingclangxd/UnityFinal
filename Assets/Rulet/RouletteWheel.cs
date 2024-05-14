using UnityEngine;
using System;
using UnityEngine.UI;

public class RouletteWheel : MonoBehaviour
{

    public Text winningNumberText;
    public float rotationSpeed = 100f;
    private Transform wheelTransform;
    private bool isSpinning = false;
    public event Action<int> OnWheelStop;
    public string[] provinces = { "Adana (01)", "Ad�yaman (02)", "Afyonkarahisar (03)", "A�r� (04)", "Amasya (05)", "Ankara (06)", "Antalya (07)", "Artvin (08)", "Ayd�n (09)", "Bal�kesir (10)", "Bilecik (11)", "Bing�l (12)", "Bitlis (13)", "Bolu (14)", "Burdur (15)", "Bursa (16)", "�anakkale (17)", "�ank�r� (18)", "�orum (19)", "Denizli (20)", "Diyarbak�r (21)", "Edirne (22)", "Elaz�� (23)", "Erzincan (24)", "Erzurum (25)", "Eski�ehir (26)", "Gaziantep (27)", "Giresun (28)", "G�m��hane (29)", "Hakkari (30)", "Hatay (31)", "Isparta (32)", "Mersin (33)", "�stanbul (34)", "�zmir (35)", "Kars (36)", "Kastamonu (37)", "Kayseri (38)", "K�rklareli (39)", "K�r�ehir (40)", "Kocaeli (41)", "Konya (42)", "K�tahya (43)", "Malatya (44)", "Manisa (45)", "Kahramanmara� (46)", "Mardin (47)", "Mu�la (48)", "Mu� (49)", "Nev�ehir (50)", "Ni�de (51)", "Ordu (52)", "Rize (53)", "Sakarya (54)", "Samsun (55)", "Siirt (56)", "Sinop (57)", "Sivas (58)", "Tekirda� (59)", "Tokat (60)", "Trabzon (61)", "Tunceli (62)", "�anl�urfa (63)", "U�ak (64)", "Van (65)", "Yozgat (66)", "Zonguldak (67)", "Aksaray (68)", "Bayburt (69)", "Karaman (70)", "K�r�kkale (71)", "Batman (72)", "��rnak (73)", "Bart�n (74)", "Ardahan (75)", "I�d�r (76)", "Yalova (77)", "Karab�k (78)", "Kilis (79)", "Osmaniye (80)", "D�zce (81)" };

    private void Start()
    {
       
        wheelTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        
        if (isSpinning)
        {
            wheelTransform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }

    
    public void SpinWheel()
    {
        isSpinning = true;
    }

    
    public void StopWheel()
    {
        
        isSpinning = false;
        int winningNumber = CalculateWinningNumber();
        OnWheelStop?.Invoke(winningNumber);
        winningNumberText.text = "Winning Number: " + winningNumber;
    }

    private int CalculateWinningNumber()
    {
        
        float wheelRotation = wheelTransform.rotation.eulerAngles.y;
        int winningNumber = Mathf.RoundToInt(wheelRotation / 4.4f) % 81; 
        return winningNumber;
    }
}
