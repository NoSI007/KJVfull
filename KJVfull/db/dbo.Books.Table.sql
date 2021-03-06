USE [KJVBible]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 20/02/2022 13:38:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Books] ([ID], [Name]) VALUES (1, N'Genesis')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (2, N'Exodus')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (3, N'Leviticus')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (4, N'Numbers')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (5, N'Deuteronomy')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (6, N'Joshua')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (7, N'Judges')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (8, N'Ruth')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (9, N'1 Samuel')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (10, N'2 Samuel')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (11, N'1 Kings')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (12, N'2 Kings')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (13, N'1 Chronicles')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (14, N'2 Chronicles')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (15, N'Ezra')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (16, N'Nehemiah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (17, N'Esther')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (18, N'Job')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (19, N'Psalms')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (20, N'Proverbs')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (21, N'Ecclesiastes')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (22, N'Song of Solomon')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (23, N'Isaiah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (24, N'Jeremiah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (25, N'Lamentations')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (26, N'Ezekiel')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (27, N'Daniel')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (28, N'Hosea')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (29, N'Joel')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (30, N'Amos')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (31, N'Obadiah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (32, N'Jonah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (33, N'Micah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (34, N'Nahum')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (35, N'Habakkuk')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (36, N'Zephaniah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (37, N'Haggai')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (38, N'Zechariah')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (39, N'Malachi')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (40, N'Matthew')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (41, N'Mark')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (42, N'Luke')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (43, N'John')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (44, N'Acts')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (45, N'Romans')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (46, N'1 Corinthians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (47, N'2 Corinthians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (48, N'Galatians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (49, N'Ephesians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (50, N'Philippians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (51, N'Colossians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (52, N'1 Thessalonians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (53, N'2 Thessalonians')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (54, N'1 Timothy')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (55, N'2 Timothy')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (56, N'Titus')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (57, N'Philemon')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (58, N'Hebrews')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (59, N'James')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (60, N'1 Peter')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (61, N'2 Peter')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (62, N'1 John')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (63, N'2 John')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (64, N'3 John')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (65, N'Jude')
INSERT [dbo].[Books] ([ID], [Name]) VALUES (66, N'Revelation')
GO
