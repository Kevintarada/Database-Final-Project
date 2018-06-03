Imports MySql.Data.MySqlClient
Public Class delSP
    Dim con As MySqlConnection
    Dim str, query, query2 As String
    Dim comm, comm2 As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
        Sparepart.Show()
    End Sub

    Private Sub delSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        Try
            con.Open()
            query = "select * from sparepart"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox1.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("sp_name"))
                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        Dim typeid As Integer

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()

        Try
            con.Open()
            query = "select * from sparepart where sp_name = '" + ListBox1.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    typeid = reader.Item("spt_id")
                    TextBox2.Text = reader.Item("sp_id")
                    TextBox1.Text = reader.Item("sp_name")
                End While
            End If
            con.Close()

            con.Open()
            query2 = "SELECT spt_name FROM sparepart_type WHERE spt_id = " + CStr(typeid)
            comm2 = New MySqlCommand(query2, con)
            TextBox3.Text = Convert.ToString(comm2.ExecuteScalar())
            con.Close()

        Catch ex As Exception
            MessageBox.Show("Error while selecting from Database" + ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim name As String = TextBox1.Text

        Try
            If TextBox1.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "delete from sparepart where sp_name = '" + CStr(name) + "'"
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("product has been succesfully removed")
                con.Close()

                Sparepart.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while deleting product")
        End Try
    End Sub
End Class