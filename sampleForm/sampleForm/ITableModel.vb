Imports System.Data.SqlClient

'테이블을 조회하고 수정하고 삭제할 때 필요한 정보를 가진 모델입니다.
Public Interface ITableModel


    '기본 sql 라이브러리에는 쿼리 작성 시 @param라고 문자열에 포함하면 실제로 실행할 땐 특정 값과 매칭되도록 설정할 수 있습니다
    '그러한 기능을 사용하기 위해서는 그 파라미터의 타입과 값이 설정하여야 합니다.
    '컬럼명에 따라서 db column Type과 값을 저장한 인스턴스를 반환하는 함수입니다. 
    Function GetSqlParameter(columnName As String) As SqlParameter

End Interface
