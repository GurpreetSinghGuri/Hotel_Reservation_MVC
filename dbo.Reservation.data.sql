SET IDENTITY_INSERT [dbo].[Reservation] ON
INSERT INTO [dbo].[Reservation] ([Id], [ClientId], [HotelId]) VALUES (1, 1, 3)
INSERT INTO [dbo].[Reservation] ([Id], [ClientId], [HotelId]) VALUES (2, 2, 2)
INSERT INTO [dbo].[Reservation] ([Id], [ClientId], [HotelId]) VALUES (3, 3, 1)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
