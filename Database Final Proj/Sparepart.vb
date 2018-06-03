Imports MySql.Data.MySqlClient

Public Class Sparepart

    Dim con As MySqlConnection
    Dim str, query, query2, query3 As String
    Dim comm, comm2, comm3 As MySqlCommand
    Dim reader, reader2, reader3 As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Sparepart_load(sender, e)
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SparepartAdd.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SPstockAdd.Show()
        Me.Hide()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        delSP.Show()
        Me.Hide()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        Dim unitid As Integer
        Dim typeid As Integer


        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()

        Try
            con.Open()
            query = "select * from sparepart where sp_name = '" + ListBox2.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    unitid = reader.Item("unit_id")
                    typeid = reader.Item("spt_id")

                    TextBox1.Text = reader.Item("sp_id")
                    TextBox2.Text = reader.Item("sp_name")
                    TextBox5.Text = reader.Item("price")
                    TextBox6.Text = reader.Item("stock")
                End While
            End If
            con.Close()

            con.Open()
            query3 = "SELECT unit_name FROM laptop WHERE unit_id = " + CStr(unitid)
            comm3 = New MySqlCommand(query3, con)
            TextBox3.Text = Convert.ToString(comm3.ExecuteScalar())
            con.Close()

            con.Open()
            query2 = "SELECT spt_name FROM sparepart_type WHERE spt_id = " + CStr(typeid)
            comm2 = New MySqlCommand(query2, con)
            TextBox4.Text = Convert.ToString(comm2.ExecuteScalar())
            con.Close()

        Catch ex As Exception
            MessageBox.Show("Error while selecting from database" + ex.Message)
        End Try
    End Sub

    Private Sub Sparepart_load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True

        Try
            con.Open()
            query = "select * from sparepart"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox2.Items.Clear()

            If reader.HasRows Then
                Do While reader.Read()
                    ListBox2.Items.Add(reader.Item("sp_name"))
                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)
        End Try
    End Sub
End Class