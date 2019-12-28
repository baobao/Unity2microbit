using UnityEngine;

/// <summary>
/// Unityからmicroへ文字列をシリアル通信するサンプル
/// </summary>
public class Unity2microbit : MonoBehaviour
{
    /// <summary>
    /// ls /dev/cu.*などしてポート名を調べて入力する
    /// </summary>
    public string PortName = "/dev/cu.usbmodem1412";
    private const int BaudRate = 115200;
    private SerialPortWrapper _serialPortWrapper;

    void OnEnable()
    {
        _serialPortWrapper?.KillThread();
        _serialPortWrapper = new SerialPortWrapper(PortName, BaudRate);
    }

    void OnDisable()
    {
        if (_serialPortWrapper != null)
        {
            _serialPortWrapper.KillThread();
            _serialPortWrapper = null;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("send!!!!");
            Send();
        }
    }
    
    void Send()
    {
        // micro:bitに送信する任意の文字列
        _serialPortWrapper.Write("hoge:");
    }
}