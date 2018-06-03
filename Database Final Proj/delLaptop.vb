﻿Imports MySql.Data.MySqlClient

Public Class delLaptop
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim id As Integer = Val(TextBox1.Text)

        Try
            If TextBox1.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "UPDATE laptop SET unit_name='" + CStr(TextBox2.Text) + "', price=" + CStr(TextBox3.Text) + ",stock=" + CStr(TextBox4.Text) + " WHERE unit_id = " + CStr(id)
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("stock has been succesfully updated")
                con.Close()

                Laptop.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("Error While updating stock")
        End Try
    End Sub

    Private Sub delLaptop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        TextBox1.ReadOnly = True

        Try
            con.Open()
            query = "Select * from laptop"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            ListBox1.Items.Clear()
            If reader.HasRows Then
                Do While reader.Read()
                    ListBox1.Items.Add(reader.Item("unit_name"))
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
        Try
            con.Open()
            query = "Select * from laptop where unit_name = '" + ListBox1.SelectedItem.ToString + "'"
            comm = New MySqlCommand(query, con)
            reader = comm.ExecuteReader

            If reader.HasRows Then
                While reader.Read()

                    TextBox1.Text = reader.Item("unit_id")
                    TextBox2.Text = reader.Item("unit_name")
                    TextBox3.Text = reader.Item("price")
                    TextBox4.Text = reader.Item("stock")
                End While
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error while selecting from Database" + ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Laptop.Show()
    End Sub
End Class