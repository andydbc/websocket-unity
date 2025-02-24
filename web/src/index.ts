

var toggle = document.createElement("button");
toggle.innerHTML = "Toggle Effect";
toggle.style.cursor = "pointer";

var intervalID: NodeJS.Timeout;

var ws: WebSocket | null = null;
var connected = false;

const connectWebSocket = () => {
    if(connected) return;

    ws = new WebSocket("ws://localhost:8080");
    ws.onopen = () => {
        toggle.disabled = false;
        connected = true;
        console.log("Connected to Unity");
    };
    ws.onmessage = (event) => {
        console.log("Received:", event.data);
    };
    ws.onclose = () => {
        if(!connected) return;
        console.log("Disconnected from server");
        toggle.disabled = true;
        connected = false;
        intervalID = setInterval(reconnectWebSocket, 5000);
    };
    ws.onerror = (error) => {
        console.error(error);
    };

    toggle.onclick = () => {
        if(ws && ws.OPEN)
            ws.send(JSON.stringify({ type: "command", msg: "toggle" }));
    };
}

connectWebSocket();

const reconnectWebSocket = () => {
    if(connected) {
        clearInterval(intervalID);
    }
    console.log("reconnecting...");
    connectWebSocket();
}

document.body.appendChild(toggle);
