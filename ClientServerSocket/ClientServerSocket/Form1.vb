Imports System.Net.Sockets
Imports System.Text

Public Class Form1
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim serverSteam As NetworkStream = clientSocket.GetStream()
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes("Message from client$")
        serverSteam.Write(outStream, 0, outStream.Length)
        serverSteam.Flush()
        Dim inStream(10024) As Byte
        serverSteam.Read(inStream, 0, CInt(clientSocket.ReceiveBufferSize))
        Dim returndata As String = System.Text.Encoding.ASCII.GetString(inStream)
        MsgBox("Data from Server : " + returndata)
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msg("Client Started")
        clientSocket.Connect("127.0.0.1", 8888)
        Label1.Text = "Client Socket Program - Server Connected........."
    End Sub
    Sub msg(ByVal mesg As String)
        TextBox1.Text = TextBox1.Text + Environment.NewLine + " >> " + mesg
    End Sub
End Class
