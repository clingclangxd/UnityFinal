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
    public string[] provinces = { "Adana (01)", "Adýyaman (02)", "Afyonkarahisar (03)", "Aðrý (04)", "Amasya (05)", "Ankara (06)", "Antalya (07)", "Artvin (08)", "Aydýn (09)", "Balýkesir (10)", "Bilecik (11)", "Bingöl (12)", "Bitlis (13)", "Bolu (14)", "Burdur (15)", "Bursa (16)", "Çanakkale (17)", "Çankýrý (18)", "Çorum (19)", "Denizli (20)", "Diyarbakýr (21)", "Edirne (22)", "Elazýð (23)", "Erzincan (24)", "Erzurum (25)", "Eskiþehir (26)", "Gaziantep (27)", "Giresun (28)", "Gümüþhane (29)", "Hakkari (30)", "Hatay (31)", "Isparta (32)", "Mersin (33)", "Ýstanbul (34)", "Ýzmir (35)", "Kars (36)", "Kastamonu (37)", "Kayseri (38)", "Kýrklareli (39)", "Kýrþehir (40)", "Kocaeli (41)", "Konya (42)", "Kütahya (43)", "Malatya (44)", "Manisa (45)", "Kahramanmaraþ (46)", "Mardin (47)", "Muðla (48)", "Muþ (49)", "Nevþehir (50)", "Niðde (51)", "Ordu (52)", "Rize (53)", "Sakarya (54)", "Samsun (55)", "Siirt (56)", "Sinop (57)", "Sivas (58)", "Tekirdað (59)", "Tokat (60)", "Trabzon (61)", "Tunceli (62)", "Þanlýurfa (63)", "Uþak (64)", "Van (65)", "Yozgat (66)", "Zonguldak (67)", "Aksaray (68)", "Bayburt (69)", "Karaman (70)", "Kýrýkkale (71)", "Batman (72)", "Þýrnak (73)", "Bartýn (74)", "Ardahan (75)", "Iðdýr (76)", "Yalova (77)", "Karabük (78)", "Kilis (79)", "Osmaniye (80)", "Düzce (81)" };

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
