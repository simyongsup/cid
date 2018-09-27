// tcpClient.java by fpont 3/2000

// usage : java tcpClient <server> <port>
// default port is 1500
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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




    [STAThread]
    public static void Main(System.String[] args)
    {

        int port = 1500;
        //		System.String server = "localhost";
        System.String server = "110.10.189.101";
        System.Net.Sockets.Socket socket = null;
        System.String lineToBeSent;
        System.IO.StreamReader input;
        System.IO.StreamWriter output;
        int ERROR = 1;

        try
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse("110.10.189.101");
            System.Net.IPEndPoint remoteEP = new System.Net.IPEndPoint(ipAdd, 1500);

            socket.Connect(remoteEP);
            Receive(socket);
            //new System.Net.Sockets.TcpClient(server, port);
            socket.Send(encoding.GetBytes("callcenter_idx=3"));
            while (true)
            {
                lineToBeSent = System.Console.ReadLine();

                if (lineToBeSent.Equals("."))
                {
                    socket.Close();
                    break;
                }
                socket.Send(encoding.GetBytes(lineToBeSent));
            }


            byte[] Serbyte = new byte[30];
            //			socket.Receive(Serbyte,0,20,System.Net.Sockets.SocketFlags.None);
            //			System.Console.WriteLine("Message from server \n" + encoding.GetString(Serbyte));

            //socket.Close();


        }
        catch (System.IO.IOException e)
        {
            System.Console.Out.WriteLine(e);
        }

    }

    private static void Receive(Socket client)
    {
        try
        {
            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = client;

            // Begin receiving the data from the remote device.
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    static string response = "";
    private static void ReceiveCallback(IAsyncResult ar)
    {
        try
        {


            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;
            // Read data from the remote device.
            int bytesRead = client.EndReceive(ar);
            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                //  Get the rest of the data.
                if (state.sb.Length > 1)
                {
                    response = Encoding.ASCII.GetString(state.buffer, 0, bytesRead).ToString();
                    Console.WriteLine(response);
                }
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                // All the data has arrived; put it in response.
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                    Console.WriteLine(response);
                }
                // Signal that all bytes have been received.

                //receiveDone.Set();

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }


}