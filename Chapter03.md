# WPF 데이터 바인딩, 데이터 바인딩이용하여 오라클테이블 데이터를 ListView에 출력

- Oracle Database Express Edition을 설치한다.
  - Oracle 사이트 가입 진행
  - [Oracle Database Express Edition 사이트](https://www.oracle.com/database/technologies/xe-downloads.html) > 다운로드
- Oracle Developer Tools를 설치한다.
  - Oracle 사이트 가입 진행
  - [Oracle Developer Tools 사이트](https://www.oracle.com/kr/database/technologies/developer-tools/visual-studio/) 접속 > 다운로드 클릭
- Oeacle Developer Tools 파일들을, Oracle 설치된 폴더 > NETWORK 폴더 > Ad
- 접속하고자 하는 DB TNS 설정
  - Oracle 설치된 폴더 > NETWORK 폴더 > Admin 폴더 > tnsnames.ora 열기
  - 다음 내용 기입
    ```
    ONJ = 
     (DESCRIPTION = 
      (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
      (CONNECT_DATA = 
        (SERVER = DEDICATED)
        (SERVER_NAME = onj)
      )
    ```
