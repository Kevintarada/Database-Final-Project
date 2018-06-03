Imports MySql.Data.MySqlClient
Public Class UPDTemp
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Employee.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim id As Integer = Val(TextBox1.Text)
        Dim name As String = TextBox2.Text
        Dim branch As String = TextBox3.Text

        Try
            If TextBox1.Text.Length <= 0 Or TextBox2.Text.Length <= 0 Or TextBox3.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "UPDATE employee SET emp_name = '" + CStr(name) + "', branch_name = '" + CStr(branch) + " 'where emp_id =" + CStr(id)
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("employee has been succesfully updated")
                con.Close()

                Employee.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while updating employee")
        End Try

    End Sub
End Class