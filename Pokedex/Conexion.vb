Imports MySql.Data.MySqlClient


Public Class conexion
    'Conexion a base de datos
    Public conexion As MySqlConnection = New MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=JorgeGiron; database=desarrollo")
    Private cmb As MySqlCommandBuilder
    Public ds As DataSet = New DataSet
    Public da As MySqlDataAdapter
    Public comando As MySqlCommand
    Public comand As MySqlCommand
    Public dv As DataView = New DataView

    'Llenar Combobox'
    Public adap As MySqlDataAdapter
    Public datos2 As DataSet

    'Funcion Conexion'
    Public Sub conectar()
        Try
            conexion.Open()
            MessageBox.Show("Conexion Exitosa")
        Catch ex As Exception
            MessageBox.Show("No se ha podido conectar")
        Finally
            conexion.Close()
        End Try
    End Sub


    Public Sub llenar(ByVal sql As String, ByVal tabla As String)
        ds.Tables.Clear()
        da = New MySqlDataAdapter(sql, conexion)
        cmb = New MySqlCommandBuilder(da)
        da.fill(ds, tabla)
        dv.Table = ds.Tables(0)
        conexion.Close()
    End Sub

    'Funcion Agregar datos'
    Function insert(ByRef sql, ByVal ID)
        Dim READER As MySqlDataReader
        Dim Cont As Int32 = 0
        conexion.Open()
        comand = New MySqlCommand("Select * From pokedex where Id = '" + ID + "'", conexion)
        READER = comand.ExecuteReader()

        While READER.Read
            Cont = Cont + 1
        End While
        READER.Close()

        If Cont = 0 Then
            comando = New MySqlCommand(sql, conexion)
            Dim i As Integer = comando.ExecuteNonQuery()
            conexion.Close()

            If (i > 0) Then
                Return True
            End If
        Else
            conexion.Close()
            Return False
        End If


    End Function

    'Funcion Actualizar un dato'

    Function actualizar(ByVal tabla, ByVal campos, ByVal condicion)
        conexion.Open()
        Dim mcdd As String = "Update " + tabla + " set " + campos + " where " + condicion
        comando = New MySqlCommand(mcdd, conexion)
        Dim i As Integer = comando.ExecuteNonQuery()
        conexion.Close()
        If (i > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    'Funcion eliminar una linear' 
    Function Eliminar(ByVal tabla, ByVal condicion)
        conexion.Open()
        Dim elimina As String = "delete from " + tabla + " where " + condicion
        comando = New MySqlCommand(elimina, conexion)
        Dim i As String = comando.ExecuteNonQuery()
        conexion.Close()
        If (i > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    'LLenar un ComboBox desde una DB'
    Public Sub llenarcb()
        conexion.Open()
        adap = New MySqlDataAdapter("select * from region", conexion)
        datos2 = New DataSet
        datos2.Tables.Add("region")
        adap.Fill(datos2.Tables("region"))
        conexion.Close()
    End Sub
End Class


