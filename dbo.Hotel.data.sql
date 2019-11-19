SET IDENTITY_INSERT [dbo].[Hotel] ON
INSERT INTO [dbo].[Hotel] ([Id], [HotelName], [PricePerRoom]) VALUES (1, N'Grand Hotel', CAST(90.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Hotel] ([Id], [HotelName], [PricePerRoom]) VALUES (2, N'Sky Hotel', CAST(100.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Hotel] ([Id], [HotelName], [PricePerRoom]) VALUES (3, N'Holiday Inn', CAST(85.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Hotel] OFF
