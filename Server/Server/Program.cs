using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 8800;
IPAddress local = IPAddress.Parse("127.0.0.1");
TcpListener server = null!;

try
{
    server = new(local, port);
    server.Start();

    while (true)
    {
        Console.WriteLine("Ожидание подключений...");

        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Клиент подключен.");

        NetworkStream stream = client.GetStream();

        string response = "Hello World!";
        byte[] data = Encoding.UTF8.GetBytes(response);

        stream.Write(data, 0, data.Length);
        Console.WriteLine("Отправлено сообщение: {0}", response);

        stream.Close();
        client.Close();
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    if (server != null)
    {
        server.Stop();
    }
}