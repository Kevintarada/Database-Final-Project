Imports MySql.Data.MySqlClient
Public Class delLaptop
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim id As Integer = Val(TextBox1.Text)

        Try
            If TextBox1.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "delete from laptop where unit_id = " + CStr(id)
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("stock has been succesfully removed")
                con.Close()

                Laptop.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while deleteing stock")
        End Try
    End Sub
End Class