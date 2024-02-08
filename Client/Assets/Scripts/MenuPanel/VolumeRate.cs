using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VolumeRate : MonoBehaviour
{
    [FormerlySerializedAs("Slider")]
    public Slider _slider;
    [FormerlySerializedAs("ActiveImage")]
    public Sprite _activeImage;
    [FormerlySerializedAs("InactiveImage")]
    public Sprite _inactiveImage;
    [FormerlySerializedAs("Text")]
    public TextMeshProUGUI _label;


    private int _rate;
    [SerializeField] private Image _currentImage;
    private const int MaxRate = 100;
    private const int MinRate = 0;
    private const int DefaultRate = 35;
    private bool isActive;
    private int oldRate;


    public void Start()
    {
        _slider.maxValue = MaxRate;
        _slider.minValue = MinRate;
        _rate = DefaultRate;
        
        ChangeSliderValue();
    }

    public void OnIncrease()
    {
        _slider.value += 1;
    }

    public void OnDecrease()
    {
        _slider.value -= 1;
    }

    public void OnActive()
    {
        if (!isActive)
        {
            _rate = oldRate;
            
            SetActive();
            ChangeSliderValue();

            return;
        }

        oldRate = _rate;
        _rate = MinRate;
        
        SetInactive();
        ChangeSliderValue();
    }

    public void OnSliderValueChanged()
    {
        _rate = (int)_slider.value;
        ChangeLabelText();

        if (_rate == 0)
        {
            SetInactive();
            
            return;
        }
        
        SetActive();
    }

    public void Hide()
    {
        ToggleVisible(false);
    }

    public void Show()
    {
        ToggleVisible(true);
    }

    private void ToggleVisible(bool isShow)
    {
        var alpha = isShow ? 255f : 0f;

        _currentImage.DOFade(alpha, 0.2f);
    }

    private void ChangeSliderValue()
    {
        _slider.value = _rate;
    }
    
    private void ChangeLabelText()
    {
        _label.text = _rate.ToString();
    }

    private void SetActive()
    {
        isActive = true;
        _currentImage.sprite = _activeImage;
    }
    
    private void SetInactive()
    {
        isActive = false;
        _currentImage.sprite = _inactiveImage;
    }
}