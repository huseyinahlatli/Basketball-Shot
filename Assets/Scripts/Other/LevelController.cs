using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;
public class LevelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText; 
    private int _levelDif = 0;
    [SerializeField] private GameObject basketballPot;
    [SerializeField] private GameObject trajectory;
    public void ChooseLevel()
    {
        _levelDif += 1;
        
        if (_levelDif == 1)
        {
            basketballPot.GetComponent<PotMovementX>().enabled = true;
            levelText.text = "Easy";
            levelText.color = Color.yellow;
        }
        
        else if (_levelDif == 2)
        {
            basketballPot.GetComponent<PotMovementY>().enabled = true;
            levelText.text = "Medium";
            levelText.color = new Color(1f, 0.5f, 0f);
        }
        
        else if (_levelDif == 3)
        {
            trajectory.SetActive(false);
            levelText.text = "Hard";
            levelText.color = Color.red;
        }

        else
        {
            basketballPot.GetComponent<PotMovementY>().enabled = false;
            basketballPot.GetComponent<PotMovementX>().enabled = false;
            trajectory.SetActive(true);
            
            levelText.text = "None";
            levelText.color = Color.white;
            _levelDif = 0;
        }
    }
}
