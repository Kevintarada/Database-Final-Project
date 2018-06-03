Imports MySql.Data.MySqlClient
Public Class SPstockAdd
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
        Sparepart.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim id As Integer = Val(TextBox1.Text)
        Dim stock As Integer = Val(TextBox2.Text)

        Try
            If TextBox1.Text.Length <= 0 Or TextBox2.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "update sparepart set stock = stock + " + CStr(stock) + " where sp_id = " + CStr(id)
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("stock has been succesfully added")
                con.Close()

                Sparepart.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while adding stock")
        End Try
    End Sub
End Class