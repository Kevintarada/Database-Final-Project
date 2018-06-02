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

        Try
            con.Open()
            query = "select * from laptop"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("unit_id"))
                    ListBox2.Items.Add(reader.Item("unit_name"))
                    ListBox3.Items.Add(reader.Item("price"))
                    ListBox4.Items.Add(reader.Item("stock"))

                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        newLaptop.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delLaptop.Show()
        Me.Hide()
    End Sub

    Private Sub Laptop_load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)


        Try
            con.Open()
            query = "select * from laptop"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox1.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("unit_id"))
                    ListBox2.Items.Add(reader.Item("unit_name"))
                    ListBox3.Items.Add(reader.Item("price"))
                    ListBox4.Items.Add(reader.Item("stock"))

                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try


    End Sub
End Class