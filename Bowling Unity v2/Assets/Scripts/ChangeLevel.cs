/*  File Name:          ChangeLevel.cs     
 *  Purpose:            Manages the changing of levels depending on the button pressed by the user.
 *  Contributors:       Ashley Mojica
 *  Last Modified:      4/21/2022 - Ashley Mojica
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void Leave()
    {
        Application.Quit();
    }
}
