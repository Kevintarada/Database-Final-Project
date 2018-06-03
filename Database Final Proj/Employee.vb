Imports MySql.Data.MySqlClient
Public Class Employee

    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = final_project; sslmode = none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "SELECT * from employee where emp_name = '" + ListBox1.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox1.Text = reader.Item("emp_id")
                    TextBox2.Text = reader.Item("emp_name")
                    TextBox3.Text = reader.Item("branch_name")

                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("an error has occured while selecting: " + ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        str = "server = localhost; user id = root; password=; database = final_project; sslmode = none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "select * from employee"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader()

            ListBox1.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("emp_name"))
                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured: " + ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ADDemployee.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        UPDTemp.Show()
        Me.Hide()
    End Sub

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = final_project; sslmode = none"
        con = New MySqlConnection(str)

        TextBox1.ReadOnly = True

        Try
            con.Open()
            query = "select * from employee"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader()

            ListBox1.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("emp_name"))
                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured: " + ex.Message)
        End Try
    End Sub
End Class