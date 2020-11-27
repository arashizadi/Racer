using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MenuScript : MonoBehaviour
{
    bool newGame = true, hardMenu, coolDown;
    public static bool hardMode;
    public TextMeshPro newGameText, exitText, normalText, hardText;
    public GameObject difficultyGUI;
    public Transform mainMenuGUI;

    void Start()
    {
    if(!hardMode)
        normalText.fontStyle = FontStyles.Bold;
        normalText.fontSize = 15;
        hardText.fontStyle = FontStyles.Normal;
        hardText.fontSize = 12;
        hardMode = false;
    }
    void Update()
    {
        StartCoroutine(Navigate());
    }

    IEnumerator Navigate()
    {
        if (Input.GetAxisRaw("Submit") > 0 && !newGame || Input.GetAxisRaw("Cancel") > 0 && !hardMenu)
            Application.Quit();
        else if (Input.GetAxisRaw("Cancel") > 0 && hardMenu)
        {
            coolDown = true;
            mainMenuGUI.position = new Vector2(0, 0);
            difficultyGUI.SetActive(false);
            hardMenu = false;
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && newGame && !hardMenu && !coolDown || Input.GetAxisRaw("Vertical") < 0 && newGame && !hardMenu && !coolDown)
        {
            coolDown = true;
            newGameText.fontStyle = FontStyles.Normal;
            newGameText.fontSize = 12;
            exitText.fontStyle = FontStyles.Bold;
            exitText.fontSize = 15;
            newGame = false;
            if (Input.GetAxisRaw("Vertical") == 0 && coolDown)
            {
                yield return new WaitForSeconds(0.2f);
                coolDown = false;
            }
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && !newGame && !hardMenu && !coolDown || Input.GetAxisRaw("Vertical") < 0 && !newGame && !hardMenu && !coolDown)
        {
            coolDown = true;
            newGameText.fontStyle = FontStyles.Bold;
            newGameText.fontSize = 15;
            exitText.fontStyle = FontStyles.Normal;
            exitText.fontSize = 12;
            newGame = true;

            if (Input.GetAxisRaw("Vertical") == 0 && coolDown)
            {
                yield return new WaitForSeconds(0.2f);
                coolDown = false;
            }
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
        else if (Input.GetAxisRaw("Submit") > 0 && newGame && !hardMenu && !coolDown)
        {
            coolDown = true;
            hardMenu = true;
            mainMenuGUI.position = new Vector2 (-1000, 0);
            difficultyGUI.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            coolDown = false;
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && newGame && hardMenu && !hardMode && !coolDown || Input.GetAxisRaw("Vertical") < 0 && newGame && hardMenu && !hardMode && !coolDown)
        {
            coolDown = true;
            normalText.fontStyle = FontStyles.Normal;
            normalText.fontSize = 12;
            hardText.fontStyle = FontStyles.Bold;
            hardText.fontSize = 15;
            hardMode = true;
            if (Input.GetAxisRaw("Vertical") == 0 && coolDown)
            {
                yield return new WaitForSeconds(0.2f);
                coolDown = false;
            }
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && newGame && hardMenu && hardMode && !coolDown || Input.GetAxisRaw("Vertical") < 0 && newGame && hardMenu && hardMode && !coolDown)
        {
            coolDown = true;
            normalText.fontStyle = FontStyles.Bold;
            normalText.fontSize = 15;
            hardText.fontStyle = FontStyles.Normal;
            hardText.fontSize = 12;
            hardMode = false;

            if (Input.GetAxisRaw("Vertical") == 0 && coolDown)
            {
                yield return new WaitForSeconds(0.2f);
                coolDown = false;
            }
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
        else if (Input.GetAxisRaw("Submit") > 0 && newGame && hardMenu && !coolDown)
        {
            coolDown = true;
/*            mainMenuGUI.position = new Vector2(0, 0);
            difficultyGUI.SetActive(false);*/
            hardMenu = false;
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
    }
}
