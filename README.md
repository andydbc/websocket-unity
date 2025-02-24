# websocket-unity  
A communication layer between a web page and Unity using WebSockets.

![preview](https://github.com/user-attachments/assets/94ad62b9-59f5-4ab0-918c-7584990f37f8)

## Install

### Launch the Server
Open a terminal in the `web/` directory and run:
```sh
yarn install
```

### Launch the Webpage App
Open a second terminal in the `web/` directory and start the development server:
```sh
yarn dev
```
If successful, you should see a message like this:
```
VITE v5.4.14  ready in 337 ms

  ➜  Local:   http://localhost:5173/
  ➜  Network: use --host to expose
  ➜  press h + enter to show help
```
Now, open your browser and go to:  
[http://localhost:5173](http://localhost:5173)  

You should see a webpage with a **"Toggle Effect"** button.  
If the button is grayed out, the server is not running—see the **"Launch the Server"** section.

## Unity

### Open the Unity Project
1. Open **Unity Hub**.  
2. Click **Add** → **Add project from Disk**.  
3. Locate and select the `unity-client` folder in your project.  
4. Once added, it should appear in your projects list—open it.

### Running the Unity Client
- Open the **SampleScene** (if not already open).  
- The scene contains two objects:  
  - One for handling the server connection.  
  - One for the visual effect.  
- Press **Play**. If the server is running, you should see this message in the Unity Console:
  ```
  Connection open!
  ```
- If you don't see the message, make sure the server is running.  
- Once connected, you can use the webpage to control the effect in Unity.
