create table Events(
    Id INTEGER  primary key AUTOINCREMENT, 
    Title nvarchar(100),
    Description nvarchar(100),
    StartDate DATE,
    EndDate DATE,
    Status NVARCHAR(100),
    BannerUrl NVARCHAR(100)
)