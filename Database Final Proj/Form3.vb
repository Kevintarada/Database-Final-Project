Imports MySql.Data.MySqlClient

Public Class Transaction
    Dim con As MySqlConnection
    Dim str As String
    Dim query, query2, query3, query4 As String
    Dim comm, comm2, comm3, comm4 As MySqlCommand

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Dispose()
        MainMenu.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Transaction_Load(sender, e)
    End Sub

    Dim reader, reader2, reader3, reader4 As MySqlDataReader
    Dim adpt, adpt2 As MySqlDataAdapter

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        AddTransaction.Show()
    End Sub

    Private Sub Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "Server=localhost; user id=root; password=; database=final_project;sslmode = none"
        con = New MySqlConnection(str)

        Dim item As New DataSet

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()

        Try
            con.Open()
            query = "select IFNULL(unit_id,'NULL'), IFNULL(sp_id, 'NULL'), cust_id, emp_id FROM transaction"
            adpt = New MySqlDataAdapter(query, con)
            adpt.Fill(item)

            For i = 0 To item.Tables(0).Rows.Count - 1
                If CStr(item.Tables(0).Rows(i).Item(0)) = "NULL" Then
                    query = "SELECT sp_name FROM sparepart WHERE sp_id=" + CStr(item.Tables(0).Rows(i).Item(1))
                    comm = New MySqlCommand(query, con)
                    ListBox1.Items.Add(Convert.ToString(comm.ExecuteScalar()))
                Else
                    query = "SELECT unit_name FROM laptop WHERE unit_id=" + CStr(item.Tables(0).Rows(i).Item(0))
                    comm = New MySqlCommand(query, con)
                    ListBox1.Items.Add(Convert.ToString(comm.ExecuteScalar()))
                End If

                query2 = "SELECT name FROM customer WHERE id=" + CStr(item.Tables(0).Rows(i).Item(2))
                comm2 = New MySqlCommand(query2, con)
                ListBox4.Items.Add(Convert.ToString(comm2.ExecuteScalar()))

                query3 = "SELECT emp_name FROM employee WHERE emp_id=" + CStr(item.Tables(0).Rows(i).Item(3))
                comm3 = New MySqlCommand(query3, con)
                ListBox3.Items.Add(Convert.ToString(comm3.ExecuteScalar()))
            Next

            query2 = "SELECT * FROM transaction"
            comm = New MySqlCommand(query2, con)

            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()
                    ListBox2.Items.Add(reader.Item("price"))
                    ListBox5.Items.Add(reader.Item("trans_date"))
                End While
            End If
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class