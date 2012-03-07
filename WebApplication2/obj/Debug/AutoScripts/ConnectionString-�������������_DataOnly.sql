SET IDENTITY_INSERT [dbo].[netusers] ON 

GO
INSERT [dbo].[netusers] ([id], [login], [pass], [status]) VALUES (1, N'user1', N'1', N'Open')
GO
SET IDENTITY_INSERT [dbo].[netusers] OFF
GO
SET IDENTITY_INSERT [dbo].[netadmins] ON 

GO
INSERT [dbo].[netadmins] ([id], [login], [pass]) VALUES (1, N'admin1', N'admin1')
GO
INSERT [dbo].[netadmins] ([id], [login], [pass]) VALUES (2, N'admin2', N'2')
GO
INSERT [dbo].[netadmins] ([id], [login], [pass]) VALUES (3, N'admin3', N'3')
GO
SET IDENTITY_INSERT [dbo].[netadmins] OFF
GO
