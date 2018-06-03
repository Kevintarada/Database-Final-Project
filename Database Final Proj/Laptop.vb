Imports MySql.Data.MySqlClient

Public Class Laptop
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LaptopAdd.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Laptop_load(sender, e)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LaptopAdd.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delLaptop.Show()
        Me.Hide()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox5.Clear()
        TextBox6.Clear()

        Try
            con.Open()
            query = "select * from laptop where unit_name = '" + ListBox2.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox1.Text = reader.Item("unit_id")
                    TextBox2.Text = reader.Item("unit_name")
                    TextBox5.Text = reader.Item("price")
                    TextBox6.Text = reader.Item("stock")
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error while selecting from Database" + ex.Message)

        End Try
    End Sub

    Private Sub Laptop_load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True

        Try
            con.Open()
            query = "select * from laptop"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox2.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox2.Items.Add(reader.Item("unit_name"))

                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try


    End Sub
End Class