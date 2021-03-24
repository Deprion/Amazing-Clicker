using UnityEngine;

public class BottomPanelManager : MonoBehaviour
{
    private float moveSpeed = 3000f;
    private RectTransform transformOfObj;
    private Vector2 target;
    private void Start()
    {
        transformOfObj = GetComponent<RectTransform>();
        target = transformOfObj.anchoredPosition;
    }
    private void Update()
    {
        RevealMenu();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target = new Vector2(transformOfObj.anchoredPosition.x,
                    -transformOfObj.sizeDelta.y / 2);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target = new Vector2(transformOfObj.anchoredPosition.x,
                    transformOfObj.sizeDelta.y / 2);
        }
#endif
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.deltaPosition.y > 75)
                target = new Vector2(transformOfObj.anchoredPosition.x,
                    transformOfObj.sizeDelta.y / 2);
            if (touch.deltaPosition.y < -75)
                target = new Vector2(transformOfObj.anchoredPosition.x,
                    - transformOfObj.sizeDelta.y / 2);
        }
    }
    public void RevealMenu()
    {
        transformOfObj.anchoredPosition = Vector2.MoveTowards(transformOfObj.anchoredPosition,
                    target, moveSpeed * Time.deltaTime);
    }
    public void HideMenu()
    {
        target = new Vector2(transformOfObj.anchoredPosition.x, - transformOfObj.sizeDelta.y / 2);
        transformOfObj.anchoredPosition = Vector2.MoveTowards(transformOfObj.anchoredPosition,
                    target, moveSpeed * Time.deltaTime);
    }
}
