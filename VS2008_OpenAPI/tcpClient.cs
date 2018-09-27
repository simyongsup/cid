using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace VS2008_OpenAPI
{

    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }




public class tcpClient
{
        ManualResetEvent receiveDone = new ManualResetEvent(false);
        String callcenter_idx;
        FormBegin begin;
        System.Net.Sockets.Socket socket = null;
        System.String lineToBeSent;
        System.IO.StreamReader input;
        System.IO.StreamWriter output;
        int ERROR = 1;
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

        public void cidClient(String callcenter_idx, FormBegin begin){

        this.callcenter_idx = callcenter_idx;
        this.begin = begin;

        int port = 54321;
        
        try
        {
            // get user input and transmit it to server
            
                
            socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse("110.10.189.101");
                //System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse("127.0.0.1");
                System.Net.IPEndPoint remoteEP = new System.Net.IPEndPoint(ipAdd, 54321);

            socket.Connect(remoteEP);
            //Async Read form the server side
            Receive(socket);
            socket.Send(encoding.GetBytes("start_begin_callcenter:"+ callcenter_idx));
           
            byte[] Serbyte = new byte[30];           

        }
        catch (System.IO.IOException e)
        {
            System.Console.Out.WriteLine(e);
        }
    }

    public void send(String cid)
    {
            socket.Send(encoding.GetBytes("calling_message_number:" + callcenter_idx + ":" +cid));
    }

    private void Receive(Socket client)
    {
        try
        {
            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = client;

            // Begin receiving the data from the remote device.
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    static string response = "";
    private void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket 
            // from the asynchronous state object.

            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;
            // Read data from the remote device.
            int bytesRead = client.EndReceive(ar);
            if (bytesRead > 0)
            {
                    //MessageBox.show("수신 메세지 = " + Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
                    string msg = Encoding.ASCII.GetString(state.buffer, 0, bytesRead).ToString();
                    sendForm(msg);
                    
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
   }

        public void sendForm(string msg)
        {
            begin.setString(msg);
        }
  }
}
