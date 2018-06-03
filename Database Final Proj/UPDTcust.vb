Imports MySql.Data.MySqlClient
Public Class UPDTcust
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Customer.Show()
        Me.Hide()
    End Sub

    Private Sub UPDTcust_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        TextBox5.ReadOnly = True

        Try
            con.Open()
            query = "Select * from customer"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox1.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("name"))
                Loop
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("connection Error occured" + ex.Message)

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

        Try
            con.Open()
            query = "Select * from customer where name = '" + ListBox1.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()

                    TextBox5.Text = reader.Item("id")
                    TextBox1.Text = reader.Item("name")
                    TextBox2.Text = reader.Item("address")
                    TextBox3.Text = CStr(reader.Item("tel_no"))
                    TextBox4.Text = reader.Item("email")

                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error while selecting from Database" + ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim Name As String = TextBox1.Text
        Dim address As String = TextBox2.Text
        Dim phone As Integer = Val(TextBox3.Text)
        Dim email As String = TextBox4.Text
        Dim id As Integer = Val(TextBox5.Text)

        Try
            If TextBox1.Text.Length <= 0 Or TextBox2.Text.Length <= 0 Or TextBox3.Text.Length <= 0 Or TextBox4.Text.Length <= 0 Or TextBox5.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "UPDATE customer SET name = '" + CStr(Name) + "', address = '" + CStr(address) + "',tel_no =" + CStr(phone) + ", email ='" + CStr(email) + "' where id =" + CStr(id)
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("customer has been succesfully updated")
                con.Close()

                Customer.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while updating customer")
        End Try



    End Sub
End Class