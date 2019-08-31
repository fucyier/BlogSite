SET IDENTITY_INSERT [dbo].[Authors] ON
INSERT INTO [dbo].[Authors] ([AuthorId], [Name], [Mail], [AuthorCreationDate], [Info], [Photo], [AuthorStatus], [ImageMimeType], [UserId]) VALUES (1, N'Caner Demir', N'can.demir@gmail.com', N'2019-03-20 00:00:00', N'yazılım geliştir', <Binary Data>, 0, N'image/jpeg', N'ece389cc-054d-44af-a431-1cf9a8693bae')
INSERT INTO [dbo].[Authors] ([AuthorId], [Name], [Mail], [AuthorCreationDate], [Info], [Photo], [AuthorStatus], [ImageMimeType], [UserId]) VALUES (2, N'Ahmet Yılmaz', N'ahmet@gmail.com', N'2019-03-25 00:00:00', N'bilgisayar mühendisi', <SQLVARIANT>, 1, NULL, N'caf33f99-92c8-469c-a3ea-2aa9879c21d5')
SET IDENTITY_INSERT [dbo].[Authors] OFF
