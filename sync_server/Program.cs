using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sync_server
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			SynchronousSocketListener.Listen();
		}
	}


	public class SynchronousSocketListener
	{

		// Incoming data from the client.
		public static string data = null;

		public static void Listen()
		{
			// Establish the local endpoint for the socket.
			IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 9000);

			// Create a TCP/IP socket.
			Socket listener = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);

			// Bind the socket to the local endpoint and 
			// listen for incoming connections.
			try
			{
				listener.Bind(localEndPoint);
				listener.Listen(10);

				// Start listening for connections.
				while (true)
				{
					Console.WriteLine("Waiting for a connection...");
					// Program is suspended while waiting for an incoming connection.
					Socket handler = listener.Accept();

					// Send message to the client.
					byte[] msg = Encoding.ASCII.GetBytes("Hello, world");

					handler.Send(msg);

					handler.Shutdown(SocketShutdown.Both);
					handler.Close();
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			Console.Read();

		}
	}
}
