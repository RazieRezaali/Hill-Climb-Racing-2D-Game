using UnityEngine;
using System.ComponentModel;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController instance;
    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;
    [SerializeField] private AudioSource _bellSound;

    private float _currentFuelAmount;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    private void Start(){
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    private void UpdateUI(){
        if(_currentFuelAmount>_maxFuelAmount){
            _currentFuelAmount=_maxFuelAmount;
        }
        _fuelImage.fillAmount = (_currentFuelAmount/_maxFuelAmount);
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);        
    }

    private void Update(){
        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        UpdateUI();
        if(_currentFuelAmount <= 0f){
            GameManager.instance.GameOver();
        }
    }

    public void FillRedFuel(){
        _currentFuelAmount += 30f;
        UpdateUI();
        BellSound();
    }

    public void FillGreenFuel(){
        _currentFuelAmount += 60f;
        UpdateUI();
        BellSound();
    }
    
    public void FillGoldFuel(){
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
        BellSound();
    }

    public void BellSound(){
        _bellSound.Play();
    }
}
