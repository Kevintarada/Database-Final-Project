Imports MySql.Data.MySqlClient

Public Class Sparepart

    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            con.Open()
            query = "select * from sparepart"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()
            ListBox5.Items.Clear()
            ListBox6.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("sp_id"))
                    ListBox2.Items.Add(reader.Item("sp_name"))
                    ListBox3.Items.Add(reader.Item("price"))
                    ListBox4.Items.Add(reader.Item("spt_id"))
                    ListBox5.Items.Add(reader.Item("unit_id"))
                    ListBox6.Items.Add(reader.Item("stock"))

                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SparepartAdd.Show()
        Me.Hide()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "select * from sparepart where sp_id = " + ListBox1.SelectedItem.ToString
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox1.Text = reader.Item("sp_id")
                    TextBox2.Text = reader.Item("sp_name")


                End While
            End If

            con.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Sparepart_load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "select * from sparepart"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()
            ListBox5.Items.Clear()
            ListBox6.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("sp_id"))
                    ListBox2.Items.Add(reader.Item("sp_name"))
                    ListBox3.Items.Add(reader.Item("price"))
                    ListBox4.Items.Add(reader.Item("spt_id"))
                    ListBox5.Items.Add(reader.Item("unit_id"))
                    ListBox6.Items.Add(reader.Item("stock"))

                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try
    End Sub
End Class