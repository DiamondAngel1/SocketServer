// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

client.Connect("127.0.0.1",2009);

string message = Console.ReadLine();

client.Send(Encoding.UTF8.GetBytes(message));

byte[] buffer = new byte[1024];
int bytes = client.Receive(buffer);
Console.WriteLine($"Відповідь від сервера " + Encoding.UTF8.GetString(buffer));

client.Shutdown(SocketShutdown.Both);
client.Close();
