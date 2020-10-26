using System;
using UnityEngine;
using UnityEngine.UI;
using CustomMath;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField _firstFactor;
    [SerializeField] private InputField _secondFactor;
    [SerializeField] private Dropdown _operation;
    [SerializeField] private Button _computeButton;
    [SerializeField] private Text _result;


    private void OnEnable()
    {
        _computeButton?.onClick.AddListener(OnCompute);
    }

    private void OnDisable()
    {
        _computeButton?.onClick.RemoveListener(OnCompute);
    }

    public void OnCompute()
    {
        float.TryParse(_firstFactor.text, out float firstValue);
        float.TryParse(_secondFactor.text, out float secondValue);
        float result = GetCustomOperation(_operation.value)(firstValue, secondValue);
        SetResultValue(result);
    }

    private Func<float, float, float> GetCustomOperation(int operation)
    {
        switch(_operation.value)
        {
            case 0:
                return CustomMath.CustomMath.Sum;
            case 1:
                return CustomMath.CustomMath.Substract;
            case 2:
                return CustomMath.CustomMath.Multiply;
            case 3:
                return CustomMath.CustomMath.Divide;
            default:
                return null;
        }
    }

    private void SetResultValue(float value)
    {
        _result.text = value.ToString();
    }
}
