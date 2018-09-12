Imports System.Data.SqlClient
Public Class Form1
    Public conn As New SqlConnection("Data Source=ALLMANKIND\MSSQLSERVER8; Database=db_vbloginreg; Integrated Security=True")
    Public adapter As New SqlDataAdapter
    Dim ds As DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("insert into tbl_accounts (username, password) VALUES " &
                                     "('" & TextBox3.Text & "','" & TextBox4.Text & "')", conn)
        adapter.Fill(ds, "tbl_accounts")
        TextBox3.Clear()
        TextBox4.Clear()
        MsgBox("User Registered!")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New SqlDataAdapter("select * from tbl_accounts where username like '" & TextBox1.Text &
                                     "' and password like '" & TextBox2.Text & "'", conn)
        adapter.Fill(ds, "tbl_accounts")

        If ds.Tables("tbl_accounts").Rows.Count > 0 Then
            TextBox1.Clear()
            TextBox2.Clear()
            MsgBox("Login successful!")
        Else
            MsgBox("Invalid combination of username and password")
        End If
    End Sub
End Class
