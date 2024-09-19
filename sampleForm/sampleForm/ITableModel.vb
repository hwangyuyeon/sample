Imports System.Data.SqlClient

Public Interface ITableModel

    Function GetSqlParameter(columnName As String) As SqlParameter

End Interface
