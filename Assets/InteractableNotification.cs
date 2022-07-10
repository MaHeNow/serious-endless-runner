using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableNotification : MonoBehaviour
{

    private Text _text;
    private Slider _progressBar;
    private Interactable _interactable;
    private bool _hasInteractible => _interactable != null;


    void Update()
    {
        if (_hasInteractible)
        {
            if (_interactable.CurrentLoadingTime > 0)
            {
                _progressBar.gameObject.SetActive(true);
                TurnInvisible();
                _progressBar.value = _interactable.CurrentLoadingTime;
            }
            else
            {
                TurnVisible();
                _progressBar.gameObject.SetActive(false);
            }
        }
    }

    void Start()
    {
        _text = GetComponent<Text>();
        _progressBar = transform.Find("ProgressBar").GetComponent<Slider>();
        Interactable.OnPlayerInside += SetCurrent;
        Interactable.OnPlayerExited += ClearCurrent;
        TurnInvisible();
    }

    void SetCurrent(Interactable interactable)
    {
        TurnVisible();
        _interactable = interactable;
        _progressBar.maxValue = _interactable.LoadingTime;
    }

    void ClearCurrent(Interactable _)
    {
        TurnInvisible();
        _interactable = null;
        _progressBar.gameObject.SetActive(false);
    }

    void TurnInvisible()
    {
        _text.enabled = false;
    }

    void TurnVisible()
    {
        if (_hasInteractible)
        {
            if (!_interactable.Used)
            {
                _text.enabled = true;
            }
        }
    }

}
