﻿Imports MySql.Data.MySqlClient

Public Class SparepartAdd
    Dim con As MySqlConnection
    Dim str, query As String
    Dim comm As MySqlCommand
    Dim reader As MySqlDataReader
    Public selected As Integer
    Dim i As Integer = 0
    Dim adapter As New MySqlDataAdapter()
    Dim ds As New DataSet()


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        str = "server = localhost; user id = root; password=; database = Final_project;"
        query = "select * from sparepart_type"
        con = New MySqlConnection(str)

        Try
            con.Open()
            comm = New MySqlCommand(query, con)
            adapter.SelectCommand = comm
            adapter.Fill(ds)
            adapter.Dispose()
            comm.Dispose()
            con.Close()

            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.ValueMember = "spt_id"
            ComboBox1.DisplayMember = "spt_name"
        Catch ex As Exception
            MessageBox.Show("connection error occured" + ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = Val(TextBox1.Text)
        Dim stock As Integer = Val(TextBox2.Text)
        str = "server = localhost; user id = root; password=; database = Final_project; SslMode=none"
        con = New MySqlConnection(str)

        Try
            If TextBox1.Text.Length <= 0 Or TextBox2.Text.Length <= 0 Then
                MessageBox.Show("you need to fill all boxes")

            Else
                con.Open()
                query = "INSERT INTO sparepart VALUES(NULL, " + CStr(TextBox3.Text) + ", NULL, " + CStr(TextBox1.Text) + "," + CStr(ComboBox1.SelectedValue) + ", " + CStr(stock) + ")"
                comm = New MySqlCommand(query, con)
                reader = comm.ExecuteReader
                MessageBox.Show("stock has been succesfully added")
                con.Close()

                TextBox1.Enabled = False
                TextBox2.Enabled = False
                Laptop.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("error while adding stock")
        End Try
    End Sub
End Class