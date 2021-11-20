using UnityEngine;
using UnityEngine.SceneManagement;
using Vadim;

public class GameManager : Singleton<GameManager>
{

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
