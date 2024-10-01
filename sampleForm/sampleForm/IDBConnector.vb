Imports System.Data.SqlClient

Public Interface IDBConnector

    Function SelectTable(tableName As String, columnNames As String()) As DataTable
    Sub InsertTable(tableName As String, insColumnNames As String(), model As ITableModel)
    Function LoadTable() As DataSet
    Function AddData(name As String, score As Integer) As DataSet

End Interface
