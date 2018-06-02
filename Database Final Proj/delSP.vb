Imports MySql.Data.MySqlClient
Public Class delSP
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
                query = "delete from sparepart where sp_id = " + CStr(id)
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("product has been succesfully removed")
                con.Close()

                Sparepart.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while deleting product")
        End Try
    End Sub
End Class