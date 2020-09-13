Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form1
    Public cs As String = "server = localhost" &
                         ";username=" & "root" &
                         ";password=" & "" &
                         ";database=" & "dbmes"

    Public mysqlcon As MySqlConnection = Nothing
    Public command As MySqlCommand


    Private Sub loaddatagrid()

        DataGridView1.Columns.Clear()

        Dim mysqlcon As New MySqlConnection(cs)
        Dim dt As New DataTable
        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource
        Dim command As New MySqlCommand
        Try

            mysqlcon.Open()
            command = New MySqlCommand("SELECT * from tbmessage", mysqlcon)

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.AutoGenerateColumns = False

            Dim index As Integer
            index = DataGridView1.Columns.Add("id", "id")
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(index).DataPropertyName = "id"


            index = DataGridView1.Columns.Add("date_", "date_")
            DataGridView1.Columns(1).Visible = True
            DataGridView1.Columns(index).DataPropertyName = "date_"

            index = DataGridView1.Columns.Add("message_", "message_")
            DataGridView1.Columns(2).Visible = True
            DataGridView1.Columns(index).DataPropertyName = "message_"

            index = DataGridView1.Columns.Add("from_", "from_")
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(index).DataPropertyName = "from_"

            index = DataGridView1.Columns.Add("status_", "status_")
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(index).DataPropertyName = "status_"

            sda.SelectCommand = command
            sda.Fill(dt)
            bsource.DataSource = dt
            DataGridView1.DataSource = bsource
            sda.Update(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddatagrid()
        colorunread()
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = "Message From: " & Me.DataGridView1.Item(3, Me.DataGridView1.CurrentRow.Index).Value.ToString & vbCrLf & "Date: " & Me.DataGridView1.Item(1, Me.DataGridView1.CurrentRow.Index).Value.ToString & vbCrLf & "Content: " & vbCrLf & vbCrLf & Me.DataGridView1.Item(2, Me.DataGridView1.CurrentRow.Index).Value.ToString
        Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value = "Read"
        'updatestat()

        colorunread()
    End Sub

    Private Sub updatestat()

        mysqlcon = New MySqlConnection
        mysqlcon.ConnectionString = cs
        mysqlcon.Open()

        Dim command As New MySqlCommand
        command.Connection = mysqlcon

        command.CommandText = "UPDATE dbmes.tbmessage set status_ = 'Read' where Id = '" & Me.DataGridView1.Item(0, Me.DataGridView1.CurrentRow.Index).Value.ToString & "'"

        command.ExecuteReader()
        mysqlcon.Close()
    End Sub
    Private Sub colorunread()
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(4).Value.ToString = "Unread" Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click
        loaddatagrid()
        colorunread()
    End Sub
End Class
