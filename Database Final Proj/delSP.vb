Imports MySql.Data.MySqlClient
Public Class delSP
    Dim con As MySqlConnection
    Dim str, query, query2 As String
    Dim comm, comm2 As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adapter As New MySqlDataAdapter()
    Dim dspt, dunit As New DataSet()

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
        Sparepart.Show()
    End Sub

    Private Sub delSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        TextBox2.ReadOnly = True
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
            reader.Close()
            con.Close()

            con.Open()
            query = "select * from sparepart_type"
            comm = New MySqlCommand(query, con)
            adapter.SelectCommand = comm
            adapter.Fill(dspt)
            adapter.Dispose()
            comm.Dispose()
            con.Close()

            ComboBox1.DataSource = dspt.Tables(0)
            ComboBox1.ValueMember = "spt_id"
            ComboBox1.DisplayMember = "spt_name"

            con.Open()
            query = "select * from laptop"
            comm = New MySqlCommand(query, con)
            adapter.SelectCommand = comm
            adapter.Fill(dunit)
            adapter.Dispose()
            comm.Dispose()
            con.Close()

            ComboBox2.DataSource = dunit.Tables(0)
            ComboBox2.ValueMember = "unit_id"
            ComboBox2.DisplayMember = "unit_name"
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        Dim typeid As Integer
        Dim unitid As Integer

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox6.Clear()

        Try
            con.Open()
            query = "select * from sparepart where sp_name = '" + ListBox1.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    typeid = reader.Item("spt_id")
                    unitid = reader.Item("unit_id")

                    TextBox2.Text = reader.Item("sp_id")
                    TextBox1.Text = reader.Item("sp_name")
                    TextBox4.Text = reader.Item("price")
                    TextBox6.Text = reader.Item("stock")
                End While
            End If
            reader.Close()


            query = "SELECT spt_name FROM sparepart_type WHERE spt_id = " + CStr(typeid)
            comm = New MySqlCommand(query, con)
            ComboBox1.SelectedIndex = ComboBox1.FindStringExact(Convert.ToString(comm.ExecuteScalar()))

            query = "SELECT unit_name FROM laptop WHERE unit_id = " + CStr(unitid)
            comm = New MySqlCommand(query, con)
            ComboBox2.SelectedIndex = ComboBox2.FindStringExact(Convert.ToString(comm.ExecuteScalar()))

            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error while selecting from Database" + ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim id As String = TextBox2.Text
        Dim price As String = TextBox4.Text
        Dim name As String = TextBox1.Text
        Dim stock As String = TextBox6.Text

        Try
            If TextBox1.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "UPDATE sparepart SET price =" + price + ", unit_id = " + CStr(ComboBox2.SelectedValue) + ", sp_name = '" + CStr(name) + "', spt_id = " + CStr(ComboBox1.SelectedValue) + ", stock = " + CStr(stock) + "WHERE sp_id = " + CStr(id)
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