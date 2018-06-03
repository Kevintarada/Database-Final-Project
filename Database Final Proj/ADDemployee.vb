Imports MySql.Data.MySqlClient
Public Class ADDemployee
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim Name As String = TextBox1.Text
        Dim branch As String = TextBox2.Text


        Try
            If TextBox1.Text.Length <= 0 Or TextBox2.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "INSERT INTO employee VALUES(NULL,'" + CStr(Name) + "',' " + CStr(branch) + "')"
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("employee has been succesfully added")
                con.Close()

                Employee.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while adding employee")
        End Try
    End Sub
End Class