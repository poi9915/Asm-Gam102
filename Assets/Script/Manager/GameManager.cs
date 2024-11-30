using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Manager
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public static GameManager Instance { get; set; }
        private int _currentScore = 0;
        private int _highScore = 0;

        [SerializeField] private GameObject scoreUi;
        [SerializeField] private TextMeshProUGUI scoreText;

        [SerializeField] private GameObject highScoreUi;
        [SerializeField] private TextMeshProUGUI highScoreTextBoard;
        [SerializeField] private TextMeshProUGUI scoreTextBoard;

        void Awake()
        {
            Time.timeScale = 1f;
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _highScore = PlayerPrefs.GetInt("HighScore");
            // DontDestroyOnLoad(this);
            DontDestroyOnLoad(scoreUi);
            // DontDestroyOnLoad(highScoreUi);
        }

        private void SaveHighScore()
        {
            if (_currentScore > _highScore)
            {
                PlayerPrefs.SetInt("HighScore", _currentScore);
                PlayerPrefs.Save();
            }
        }

        public void AddScore()
        {
            _currentScore++;
            scoreText.text = _currentScore.ToString();
        }

        public void ShowHighScoreBoard()
        {
            SaveHighScore();
            scoreUi.SetActive(false);
            highScoreUi.SetActive(true);
            highScoreTextBoard.text = _highScore.ToString();
            scoreTextBoard.text = _currentScore.ToString();
        }

        public void ButtonHome()
        {
            SceneManager.LoadScene("Home");
        }

        public void ButtonReplay()
        {
            scoreUi.SetActive(true);
            highScoreUi.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}