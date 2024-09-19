Imports System.Data.SqlClient
Imports sampleForm

'테이블에 옮길 데이터를 담습니다.
Public Class SampleTableModel : Implements ITableModel

    Private _idx As Integer
    Private _name As String
    Private _score As Integer

    Public Property Idx As Integer
        Get
            Return _idx
        End Get
        Set(value As Integer)
            _idx = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Score As Integer
        Get
            Return _score
        End Get
        Set(value As Integer)
            _score = value
        End Set
    End Property

    Public Sub New(name As String, score As Integer)

        Me.Name = name
        Me.Score = score

    End Sub

    '기본 sql 라이브러리에는 쿼리 작성 시 @param라고 문자열에 포함하면 실제로 실행할 땐 특정 값과 매칭되도록 설정할 수 있습니다
    '그러한 기능을 사용하기 위해서는 그 파라미터의 타입과 값이 설정하여야 합니다.
    '컬럼명에 따라서 db column Type과 값을 저장한 인스턴스를 반환하는 함수입니다. 
    Public Function GetSqlParameter(columnName As String) As SqlParameter Implements ITableModel.GetSqlParameter

        Dim param As SqlParameter = Nothing

        Select Case columnName
            Case "idx"

                param = New SqlParameter()
                param.SqlDbType = SqlDbType.Int
                param.Value = Idx

            Case "name"

                param = New SqlParameter()
                param.SqlDbType = SqlDbType.VarChar
                param.Value = Name

            Case "score"

                param = New SqlParameter()
                param.SqlDbType = SqlDbType.Int
                param.Value = Score

        End Select

        Return param
    End Function
End Class
