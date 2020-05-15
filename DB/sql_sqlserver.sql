use hospital_test
GO
CREATE TABLE user_Users
(
userId int null,
userName char(20),
userPassword char(20),
userAttribute char(20)
)

create table [dbo].[Used] (
  DbId varchar(17)
  , OtherID varchar(20)
  , HospitalNo varchar(100)
  , ScanDate varchar(17) not null
  , TagCode varchar(max)
  , BedTagCode varchar(max)
  , Signed bit
  , Pass bit
  , FileName varchar(50) not null
  , ImgFile varchar(max)
);
--drop table Used
