Imports MySql.Data.MySqlClient

Public Class AddTransaction
    Dim localDate = DateString
    Dim con As MySqlConnection
    Dim str, query, query2, query3, query4, query5 As String
    Dim comm, comm2, comm3, comm4, comm5 As MySqlCommand
    Dim reader, reader2, reader3, reader4, reader5 As MySqlDataReader

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        TextBox1.Clear()
        TextBox2.Clear()

        Try
            query = "SELECT * FROM laptop WHERE unit_name = '" + ListBox1.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)

            con.Open()
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox1.Text = reader.Item("unit_name")
                    TextBox2.Text = reader.Item("price")
                End While
            End If

            con.Close()
        Catch ex As Exception
            MessageBox.Show("an error occured while selecting: " + ex.Message)
        End Try
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

        TextBox1.Clear()
        TextBox2.Clear()

        Try
            query = "SELECT * FROM sparepart WHERE sp_name = '" + ListBox2.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)

            con.Open()
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox1.Text = reader.Item("sp_name")
                    TextBox2.Text = reader.Item("price")
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("an error occured while selecting: " + ex.Message)
        End Try
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        Try
            query = "SELECT * FROM employee WHERE emp_name = '" + ListBox3.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)

            con.Open()
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox5.Text = reader.Item("emp_name")
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("an error occured while selecting: " + ex.Message)
        End Try
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        Try
            query = "SELECT * FROM customer WHERE name = '" + ListBox4.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)

            con.Open()
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    TextBox3.Text = reader.Item("name")
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("an error occured while selecting: " + ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "Server=localhost; user id=root; password=; database=final_project"
        con = New MySqlConnection(str)

        Dim item As Integer
        Dim price As Integer
        price = TextBox2.Text
        Dim customer As Integer
        Dim employee As Integer
        Dim transdate As String
        transdate = TextBox4.Text

        Try
            con.Open()
            query = "SELECT id FROM customer WHERE name = '" + CStr(TextBox3.Text) + "'"
            comm = New MySqlCommand(query, con)
            customer = Convert.ToInt32(comm.ExecuteScalar())

            query2 = "SELECT emp_id FROM employee WHERE emp_name = '" + CStr(TextBox5.Text) + "'"
            comm2 = New MySqlCommand(query2, con)
            employee = Convert.ToInt32(comm2.ExecuteScalar())

            For i As Integer = 0 To ListBox1.Items.Count - 1
                If ListBox1.Items(i).ToString Is TextBox1.Text Then
                    query3 = "SELECT unit_id FROM laptop WHERE unit_name = '" + CStr(TextBox1.Text) + "'"
                    comm3 = New MySqlCommand(query3, con)
                    item = Convert.ToInt32(comm3.ExecuteScalar())

                    query4 = "INSERT INTO transaction VALUES(NULL, " + CStr(item) + ", NULL, " + CStr(price) + ", " + CStr(customer) + ", " + CStr(employee) + ", '" + CStr(transdate) + "')"
                    comm4 = New MySqlCommand(query4, con)
                    reader = comm4.ExecuteReader
                End If
            Next

            For j As Integer = 0 To ListBox2.Items.Count - 1
                If ListBox2.Items(j).ToString Is TextBox1.Text Then
                    query3 = "SELECT sp_id FROM sparepart WHERE sp_name = '" + CStr(TextBox1.Text) + "'"
                    comm3 = New MySqlCommand(query3, con)
                    item = Convert.ToInt32(comm3.ExecuteScalar())

                    query4 = "INSERT INTO transaction VALUES(NULL, NULL, " + CStr(item) + ", " + CStr(price) + ", " + CStr(customer) + ", " + CStr(employee) + ", '" + CStr(transdate) + "')"
                    comm4 = New MySqlCommand(query4, con)
                    reader = comm4.ExecuteReader
                End If
            Next

            MessageBox.Show("Transaction has been successfully added!", "Add Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()

            Transaction.Show()
            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "Server=localhost; user id=root; password=; database=final_project"
        con = New MySqlConnection(str)
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True

        Try
            TextBox4.Text = localDate.ToString

            con.Open()
            query = "SELECT * FROM laptop"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    ListBox1.Items.Add(reader.Item("unit_name"))
                End While
            End If
            con.Close()

            con.Open()
            query = "SELECT * FROM sparepart"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    ListBox2.Items.Add(reader.Item("sp_name"))
                End While
            End If
            con.Close()

            con.Open()
            query = "SELECT * FROM employee"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    ListBox3.Items.Add(reader.Item("emp_name"))
                End While
            End If
            con.Close()

            con.Open()
            query = "SELECT * FROM customer"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    ListBox4.Items.Add(reader.Item("name"))
                End While
            End If
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class