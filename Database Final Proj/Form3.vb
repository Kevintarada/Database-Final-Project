Imports MySql.Data.MySqlClient

Public Class Transaction
    Dim con As MySqlConnection
    Dim str As String
    Dim query, query2, query3, query4 As String
    Dim comm, comm2, comm3, comm4 As MySqlCommand
    Dim reader, reader2, reader3, reader4 As MySqlDataReader
    Dim adpt, adpt2 As MySqlDataAdapter

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        AddTransaction.Show()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "Server=localhost; user id=root; password=; database=final_project;"
        con = New MySqlConnection(str)

        Dim item As New DataSet
        Dim emp As New DataSet
        Dim cust As New DataSet

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()

        Try
            query = "SELECT emp_id FROM transaction"
            con.Open()
            adpt = New MySqlDataAdapter(query, con)
            adpt.Fill(emp)

            For i = 0 To emp.Tables(0).Rows.Count - 1
                query2 = "SELECT emp_name FROM employee WHERE emp_id=" + CStr(emp.Tables(0).Rows(i).Item(0))
                comm2 = New MySqlCommand(query2, con)
                ListBox3.Items.Add(Convert.ToString(comm2.ExecuteScalar()))
            Next

            query3 = "SELECT cust_id FROM transaction"
            adpt2 = New MySqlDataAdapter(query3, con)
            adpt2.Fill(cust)

            For i = 0 To cust.Tables(0).Rows.Count - 1
                query4 = "SELECT name FROM customer WHERE id=" + CStr(cust.Tables(0).Rows(i).Item(0))
                comm4 = New MySqlCommand(query4, con)
                ListBox4.Items.Add(Convert.ToString(comm4.ExecuteScalar()))
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