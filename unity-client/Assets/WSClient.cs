using System.Text;
using NativeWebSocket;
using UnityEngine;
using UnityEngine.Events;

public class Message 
{
    public string type;
    public string msg;
}

public class WSClient : MonoBehaviour
{
    private WebSocket websocket;

    public UnityEvent<string> OnMessageReceived;

    async void Start()
    {
        websocket = new WebSocket("ws://localhost:8080");
        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        websocket.OnMessage += (bytes) =>
        {
            string message = Encoding.UTF8.GetString(bytes);
            var parsedMessage = JsonUtility.FromJson<Message>(message);
            if(OnMessageReceived != null)
            {
                OnMessageReceived.Invoke(parsedMessage.msg);
            }
        };

        await websocket.Connect();
    }

    void Update()
    {
        if (websocket != null)
        {
            websocket.DispatchMessageQueue();
        }
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }
}