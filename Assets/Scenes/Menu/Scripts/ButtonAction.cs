using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum ButtonType {LoadScene, Quit, None}

    [SerializeField] Animator titleAnimator;
    [SerializeField] ButtonType buttonType;
    [SerializeField] int buttonIndex;
    [SerializeField] string sceneToLoad;

    public void OnPointerEnter(PointerEventData eventData)
    {
        titleAnimator.SetInteger("Hovered", buttonIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        titleAnimator.SetInteger("Hovered", 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        titleAnimator.SetTrigger("Press");
        StartCoroutine(LoadAfterAnimation());
    }

    private IEnumerator LoadAfterAnimation()
{
    // Ждём пока анимация начнётся
    yield return null;

    // Получаем длину текущей анимации и ждём её
    float animLength = titleAnimator.GetCurrentAnimatorStateInfo(0).length;
    yield return new WaitForSeconds(animLength);

    if (buttonType == ButtonType.LoadScene && sceneToLoad != "")
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    else if (buttonType == ButtonType.Quit)
    {
        Application.Quit();
    }
}
}
