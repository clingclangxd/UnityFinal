using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public List<Sprite> chipImages;
    public int chipValue;
    public TMPro.TextMeshProUGUI chipText;

    private void Start()
    {
        switch (chipValue)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = chipImages[0];
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = chipImages[1];
                break;
            case 10:
                GetComponent<SpriteRenderer>().sprite = chipImages[2];
                break;
            case 50:
                GetComponent<SpriteRenderer>().sprite = chipImages[3];
                break;
            case 100:
                GetComponent<SpriteRenderer>().sprite = chipImages[4];
                break;
            case 500:
                GetComponent<SpriteRenderer>().sprite = chipImages[5];
                break;

        }
        chipText.text = chipValue.ToString();
    }
    public IEnumerator moveChip(Vector3 target)
    {
        float current = 0;
        float ETime = 1;

        while (current < ETime)
        {
            current += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, current / ETime);
            yield return null;
        }
        print("Moved");
    }
}
