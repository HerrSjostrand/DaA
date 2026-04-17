using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    // Ссылка на Animator компонент FadePanel
    private Animator fadeAnimator;

    // Имя сцены, в которую будем переходить
    public string gameSceneName = "SampleScene"; // Замените на название вашей игровой сцены

    void Awake()
    {
        fadeAnimator = GetComponent<Animator>();
        if (fadeAnimator == null)
        {
            Debug.LogError("SceneLoader: Animator компонент не найден на FadePanel!");
        }
    }

    // Этот метод вызывается кнопкой "Начать игру"
    public void StartGameTransition()
    {
        // Убеждаемся, что Animator найден, прежде чем запускать корутину
        if (fadeAnimator != null)
        {
            StartCoroutine(FadeAndLoadScene());
        }
        else
        {
            Debug.LogError("SceneLoader: FadeAnimator не инициализирован!");
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        // 1. Запускаем анимацию затемнения (FadeIn)
        // Устанавливаем триггер, который инициирует переход в Animator'е
        fadeAnimator.SetTrigger("FadeInTrigger");

        // 2. Ждем, пока анимация затемнения отыграет
        // Длительность этой задержки должна соответствовать длительности анимации FadeIn
        // Если FadeIn длится 1 секунду, то ждем 1 секунду.
        yield return new WaitForSeconds(1f); // Примерная длительность анимации FadeIn

        // 3. Загружаем игровую сцену
        SceneManager.LoadScene(gameSceneName);
    }

    // Опционально: Метод для запуска FadeOut при старте игровой сцены
    // Вы можете вызвать его из скрипта, который будет на объекте,
    // который загружается первым в вашей игровой сцене.
    public void FadeOutOnLoad()
    {
        // Убеждаемся, что FadePanel существует и имеет Animator
        if (fadeAnimator != null)
        {
            // Устанавливаем состояние по умолчанию в FadeOutState, если оно не установлено
            // или запускаем анимациюFadeOut, если необходимо
            // Этот метод может быть более сложным в зависимости от того, как вы хотите
            // управлятьFadeOut. Простой вариант - он уже будет в FadeOutState по умолчанию.
            // Если же нужно явный запуск FadeOut:
            // fadeAnimator.Play("FadeOutState"); // Или используйте другое имя состояния
        }
    }
}