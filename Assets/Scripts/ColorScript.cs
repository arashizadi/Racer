using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ColorScript : MonoBehaviour
{
    bool coolDown;
    int playerColor = 0;
    public static float r, g, b;
    public Transform colorChooser;

    void Update()
    {
        StartCoroutine(NavigateColor());
        SelectColor();
    }

    public IEnumerator NavigateColor()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && !coolDown || Input.GetAxisRaw("Vertical") < 0 && !coolDown)
        {
            coolDown = true;
            if (playerColor > 4)
            {
                playerColor -= 5;
                colorChooser.position += Vector3.up * 3;
            }
            else
            {
                playerColor += 5;
                colorChooser.position += Vector3.down * 3;
            }
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0 && !coolDown)
        {
            coolDown = true;
            if (playerColor == 9)
            {
                playerColor = 0;
                colorChooser.position = new Vector3(-4, 1);
            }
            else if (playerColor == 4)
            {
                colorChooser.position = new Vector3(-4, -2);
                playerColor = 5;
            }
            else
            {
                playerColor++;
                colorChooser.position += Vector3.right * 2;
            }
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && !coolDown)
        {
            coolDown = true;
            if (playerColor == 0)
            {
                playerColor = 9;
                colorChooser.position = new Vector3(4, -2);
            }
            else if (playerColor == 5)
            {
                playerColor = 4;
                colorChooser.position = new Vector3(4, 1);
            }
            else
            {
                playerColor--;
                colorChooser.position += Vector3.left * 2;
            }
            yield return new WaitForSeconds(0.2f);
            coolDown = false;
        }
    }
    void SelectColor()
    {
        if (Input.GetAxisRaw("Submit") > 0)
        {
            switch (playerColor)
            {
                case 0:
                    {
                        r = 35; g = 116; b = 132;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 1:
                    {
                        r = 58; g = 58; b = 58;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 2:
                    {
                        r = 0; g = 152; b = 10;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 3:
                    {
                        r = 255; g = 128; b = 0;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }

                    }
                case 4:
                    {
                        r = 166; g = 0; b = 255;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 5:
                    {
                        r = 255; g = 243; b = 52;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 6:
                    {
                        r = 255; g = 0; b = 162;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 7:
                    {
                        r = 0; g = 128; b = 255;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 8:
                    {
                        r = 255; g = 85; b = 85;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
                case 9:
                    {
                        r = 219; g = 219; b = 219;
                        if (!MenuScript.hardMode)
                        {
                            SceneManager.LoadScene(2);
                            break;
                        }
                        else
                        {
                            SceneManager.LoadScene(3);
                            break;
                        }
                    }
            }
        }
        else if (Input.GetAxisRaw("Cancel") > 0)
            SceneManager.LoadScene(0);
    }
}
