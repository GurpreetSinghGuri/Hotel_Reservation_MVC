INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6263c1ca-46dd-4f35-88f1-57568977d28a', N'admin@hotels.com', N'ADMIN@HOTELS.COM', N'admin@hotels.com', N'ADMIN@HOTELS.COM', 1, N'AQAAAAEAACcQAAAAENY7ZVUzS2G22mxbtqSevyxj3c0cuMvkh7cqJxDPh/Daz2XAJjqCREUMsTaV0Jc9Pg==', N'YB2CCNI2FMU53YO3UL75XYMXK7V2MTGO', N'f9b1d92d-854e-4e89-8525-a8fdf7025916', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Client] ON
INSERT INTO [dbo].[Client] ([Id], [Name], [ContactNumber]) VALUES (1, N'Samson Kent', N'021044987123')
INSERT INTO [dbo].[Client] ([Id], [Name], [ContactNumber]) VALUES (2, N'David Gower', N'022345678345')
INSERT INTO [dbo].[Client] ([Id], [Name], [ContactNumber]) VALUES (3, N'Neil  Peters', N'023345644990')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Hotel] ON
INSERT INTO [dbo].[Hotel] ([Id], [HotelName], [PricePerRoom]) VALUES (1, N'Grand Hotel', CAST(90.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Hotel] ([Id], [HotelName], [PricePerRoom]) VALUES (2, N'Sky Hotel', CAST(100.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Hotel] ([Id], [HotelName], [PricePerRoom]) VALUES (3, N'Holiday Inn', CAST(85.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Hotel] OFF
SET IDENTITY_INSERT [dbo].[Reservation] ON
INSERT INTO [dbo].[Reservation] ([Id], [ClientId], [HotelId]) VALUES (1, 1, 3)
INSERT INTO [dbo].[Reservation] ([Id], [ClientId], [HotelId]) VALUES (2, 2, 2)
INSERT INTO [dbo].[Reservation] ([Id], [ClientId], [HotelId]) VALUES (3, 3, 1)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
