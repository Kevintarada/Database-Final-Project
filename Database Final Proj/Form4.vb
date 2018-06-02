﻿Imports MySql.Data.MySqlClient

Public Class LaptopAdd
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)
        Dim name As String = Val(TextBox1.Text)
        Dim price As Integer = Val(TextBox2.Text)
        Dim stock As Integer = Val(TextBox3.Text)

        Try
            If TextBox1.Text.Length <= 0 Or TextBox3.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "INSERT INTO laptop VALUES(NULL," + CStr(name) + ", " + CStr(price) + ", " + CStr(stock) + ")"
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("stock has been succesfully added")
                con.Close()

                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                Laptop.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while adding stock")
        End Try
    End Sub
End Class