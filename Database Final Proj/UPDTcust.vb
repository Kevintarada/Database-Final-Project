Imports MySql.Data.MySqlClient
Public Class UPDTcust
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Customer.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim Name As String = TextBox1.Text
        Dim address As String = TextBox2.Text
        Dim phone As Integer = Val(TextBox3.Text)
        Dim email As String = TextBox4.Text
        Dim id As Integer = Val(TextBox5.Text)

        Try
            If TextBox1.Text.Length <= 0 Or TextBox2.Text.Length <= 0 Or TextBox3.Text.Length <= 0 Or TextBox4.Text.Length <= 0 Or TextBox5.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "UPDATE customer SET name = '" + CStr(Name) + "', address = '" + CStr(address) + "',tel_no =" + CStr(phone) + ", email ='" + CStr(email) + "' where id =" + CStr(id)
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("customer has been succesfully updated")
                con.Close()

                Customer.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while updating customer")
        End Try



    End Sub
End Class