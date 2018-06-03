Imports MySql.Data.MySqlClient
Public Class Customer
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = final_project; sslmode = none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "SELECT * from customer where name = '" + ListBox2.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox1.Text = reader.Item("id")
                    TextBox2.Text = reader.Item("name")
                    TextBox3.Text = reader.Item("address")
                    TextBox4.Text = reader.Item("phone")
                    TextBox5.Text = reader.Item("email")
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("an error has occured while selecting: " + ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = final_project; sslmode = none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "select * from customer"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader()

            ListBox2.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox2.Items.Add("name")
                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured: " + ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = final_project; sslmode = none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "select * from customer"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader()

            ListBox2.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox2.Items.Add(reader.Item("name"))
                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured: " + ex.Message)
        End Try
    End Sub
End Class