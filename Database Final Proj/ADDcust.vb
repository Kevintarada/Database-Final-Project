Imports MySql.Data.MySqlClient
Public Class ADDcust
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


        Try
            If TextBox1.Text.Length <= 0 Or TextBox2.Text.Length <= 0 Or TextBox3.Text.Length <= 0 Or TextBox4.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "INSERT INTO customer VALUES(NULL,'" + CStr(Name) + "',' " + CStr(address) + "'," + CStr(phone) + ",'" + CStr(email) + "')"
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("customer has been succesfully added")
                con.Close()

                Customer.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while adding customer")
        End Try
    End Sub





End Class