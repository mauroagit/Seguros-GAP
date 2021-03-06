USE [SegurosGAP]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 2/4/2019 3:34:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [uniqueidentifier] NOT NULL,
	[TipoCliente] [tinyint] NOT NULL,
	[Identificacion] [nvarchar](30) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Telefono] [nvarchar](30) NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
	[Correo] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientesPolizas]    Script Date: 2/4/2019 3:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientesPolizas](
	[Id] [uniqueidentifier] NOT NULL,
	[Cliente] [uniqueidentifier] NOT NULL,
	[Poliza] [uniqueidentifier] NOT NULL,
	[InicioVigencia] [datetime] NOT NULL,
	[Precio] [decimal](10, 0) NOT NULL,
	[ValorAsegurado] [decimal](12, 0) NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_ClientesPolizas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cubrimientos]    Script Date: 2/4/2019 3:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cubrimientos](
	[Id] [smallint] NOT NULL,
	[Nombre] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Cubrimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CubrimientosPoliza]    Script Date: 2/4/2019 3:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CubrimientosPoliza](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Poliza] [uniqueidentifier] NOT NULL,
	[Cubrimiento] [smallint] NOT NULL,
 CONSTRAINT [PK_CubrimientosPoliza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelesRiesgo]    Script Date: 2/4/2019 3:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelesRiesgo](
	[Id] [tinyint] NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_NivelesRiesgo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Polizas]    Script Date: 2/4/2019 3:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polizas](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [nvarchar](15) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](1000) NOT NULL,
	[PeriodoCobertura] [tinyint] NOT NULL,
	[PorcentajeCubrimiento] [decimal](5, 2) NOT NULL,
	[Riesgo] [tinyint] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [uniqueidentifier] NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [uniqueidentifier] NULL,
	[FechaBorrado] [datetime] NULL,
	[UsuarioBorrado] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Polizas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposCliente]    Script Date: 2/4/2019 3:34:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposCliente](
	[Id] [tinyint] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([Id], [TipoCliente], [Identificacion], [Nombre], [Telefono], [Direccion], [Correo]) VALUES (N'cd4efd7e-a625-e911-9536-d481d78d706b', 1, N'18522539', N'Mauricio Arias Lopez', N'3113592034', N'Villa del Campo, Itagui', N'mauro.soluciones@gmail.com')
INSERT [dbo].[Clientes] ([Id], [TipoCliente], [Identificacion], [Nombre], [Telefono], [Direccion], [Correo]) VALUES (N'8d29a3dd-a828-e911-9536-d481d78d706b', 1, N'145865561', N'Carlos Peres', N'3212312133', N'La casa', N'correo@gmail.com')
INSERT [dbo].[ClientesPolizas] ([Id], [Cliente], [Poliza], [InicioVigencia], [Precio], [ValorAsegurado], [Activa]) VALUES (N'00000000-0000-0000-0000-000000000000', N'8d29a3dd-a828-e911-9536-d481d78d706b', N'8c6c00ae-0f27-e911-9536-d481d78d706b', CAST(N'2019-02-04T14:54:26.250' AS DateTime), CAST(1000000 AS Decimal(10, 0)), CAST(10000000 AS Decimal(12, 0)), 1)
INSERT [dbo].[ClientesPolizas] ([Id], [Cliente], [Poliza], [InicioVigencia], [Precio], [ValorAsegurado], [Activa]) VALUES (N'bc45b5ba-a625-e911-9536-d481d78d706b', N'cd4efd7e-a625-e911-9536-d481d78d706b', N'19fc9b62-a625-e911-9536-d481d78d706b', CAST(N'2019-01-02T00:00:00.000' AS DateTime), CAST(1500000 AS Decimal(10, 0)), CAST(20000000 AS Decimal(12, 0)), 0)
INSERT [dbo].[ClientesPolizas] ([Id], [Cliente], [Poliza], [InicioVigencia], [Precio], [ValorAsegurado], [Activa]) VALUES (N'4e2a13b4-b928-e911-9536-d481d78d706b', N'cd4efd7e-a625-e911-9536-d481d78d706b', N'8c6c00ae-0f27-e911-9536-d481d78d706b', CAST(N'2019-02-04T15:16:07.643' AS DateTime), CAST(1000000 AS Decimal(10, 0)), CAST(10000000 AS Decimal(12, 0)), 0)
INSERT [dbo].[Cubrimientos] ([Id], [Nombre]) VALUES (1, N'Terremoto')
INSERT [dbo].[Cubrimientos] ([Id], [Nombre]) VALUES (2, N'Incendio')
INSERT [dbo].[Cubrimientos] ([Id], [Nombre]) VALUES (3, N'Robo')
INSERT [dbo].[Cubrimientos] ([Id], [Nombre]) VALUES (4, N'Perdida')
SET IDENTITY_INSERT [dbo].[CubrimientosPoliza] ON 

INSERT [dbo].[CubrimientosPoliza] ([Id], [Poliza], [Cubrimiento]) VALUES (6, N'00000000-0000-0000-0000-000000000000', 1)
INSERT [dbo].[CubrimientosPoliza] ([Id], [Poliza], [Cubrimiento]) VALUES (7, N'00000000-0000-0000-0000-000000000000', 4)
INSERT [dbo].[CubrimientosPoliza] ([Id], [Poliza], [Cubrimiento]) VALUES (1, N'19fc9b62-a625-e911-9536-d481d78d706b', 1)
INSERT [dbo].[CubrimientosPoliza] ([Id], [Poliza], [Cubrimiento]) VALUES (2, N'19fc9b62-a625-e911-9536-d481d78d706b', 2)
INSERT [dbo].[CubrimientosPoliza] ([Id], [Poliza], [Cubrimiento]) VALUES (4, N'19fc9b62-a625-e911-9536-d481d78d706b', 3)
INSERT [dbo].[CubrimientosPoliza] ([Id], [Poliza], [Cubrimiento]) VALUES (13, N'8c6c00ae-0f27-e911-9536-d481d78d706b', 3)
SET IDENTITY_INSERT [dbo].[CubrimientosPoliza] OFF
INSERT [dbo].[NivelesRiesgo] ([Id], [Nombre]) VALUES (1, N'Bajo')
INSERT [dbo].[NivelesRiesgo] ([Id], [Nombre]) VALUES (2, N'Medio')
INSERT [dbo].[NivelesRiesgo] ([Id], [Nombre]) VALUES (3, N'Medio-Alto')
INSERT [dbo].[NivelesRiesgo] ([Id], [Nombre]) VALUES (4, N'Alto')
INSERT [dbo].[Polizas] ([Id], [Codigo], [Nombre], [Descripcion], [PeriodoCobertura], [PorcentajeCubrimiento], [Riesgo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [FechaBorrado], [UsuarioBorrado]) VALUES (N'00000000-0000-0000-0000-000000000000', N'POL-PL-01', N'Poliza Platinum', N'Mejor q la basica', 6, CAST(85.00 AS Decimal(5, 2)), 2, CAST(N'2019-02-02T11:50:43.807' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2019-02-04T08:29:25.203' AS DateTime), N'1759b4d9-5024-4cc1-941d-7868a59c69bd', NULL, NULL)
INSERT [dbo].[Polizas] ([Id], [Codigo], [Nombre], [Descripcion], [PeriodoCobertura], [PorcentajeCubrimiento], [Riesgo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [FechaBorrado], [UsuarioBorrado]) VALUES (N'19fc9b62-a625-e911-9536-d481d78d706b', N'POL-BA-01', N'Poliza Basica', N'La mas basica', 12, CAST(70.00 AS Decimal(5, 2)), 2, CAST(N'2019-01-31T22:20:17.067' AS DateTime), N'76d18b99-c3fe-43ac-8dbc-d4a6bd17eadc', CAST(N'2019-01-31T22:20:17.067' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Polizas] ([Id], [Codigo], [Nombre], [Descripcion], [PeriodoCobertura], [PorcentajeCubrimiento], [Riesgo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [FechaBorrado], [UsuarioBorrado]) VALUES (N'8c6c00ae-0f27-e911-9536-d481d78d706b', N'POL-PL-02', N'Poliza Platinum B', N'Mejor q la basica', 12, CAST(45.00 AS Decimal(5, 2)), 4, CAST(N'2019-02-02T12:26:31.873' AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2019-02-04T13:11:35.983' AS DateTime), N'1759b4d9-5024-4cc1-941d-7868a59c69bd', NULL, NULL)
INSERT [dbo].[TiposCliente] ([Id], [Nombre]) VALUES (1, N'Persona Natural')
INSERT [dbo].[TiposCliente] ([Id], [Nombre]) VALUES (2, N'Persona Juridica')
/****** Object:  Index [UK_ClientePoliza]    Script Date: 2/4/2019 3:34:54 PM ******/
ALTER TABLE [dbo].[ClientesPolizas] ADD  CONSTRAINT [UK_ClientePoliza] UNIQUE NONCLUSTERED 
(
	[Cliente] ASC,
	[Poliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_PolizaCubrimiento]    Script Date: 2/4/2019 3:34:54 PM ******/
ALTER TABLE [dbo].[CubrimientosPoliza] ADD  CONSTRAINT [UK_PolizaCubrimiento] UNIQUE NONCLUSTERED 
(
	[Poliza] ASC,
	[Cubrimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_PolizasCodigo]    Script Date: 2/4/2019 3:34:54 PM ******/
ALTER TABLE [dbo].[Polizas] ADD  CONSTRAINT [UK_PolizasCodigo] UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ClientesPolizas] ADD  CONSTRAINT [DF_ClientesPolizas_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ClientesPolizas] ADD  CONSTRAINT [DF_ClientesPolizas_Activa]  DEFAULT ((1)) FOR [Activa]
GO
ALTER TABLE [dbo].[Polizas] ADD  CONSTRAINT [DF_Polizas_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Polizas] ADD  CONSTRAINT [DF_Polizas_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Polizas] ADD  CONSTRAINT [DF_Polizas_FechaCreacion1]  DEFAULT (getutcdate()) FOR [FechaModificacion]
GO
ALTER TABLE [dbo].[Polizas] ADD  CONSTRAINT [DF_Polizas_FechaModificacion1]  DEFAULT (getutcdate()) FOR [FechaBorrado]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposCliente] FOREIGN KEY([TipoCliente])
REFERENCES [dbo].[TiposCliente] ([Id])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposCliente]
GO
ALTER TABLE [dbo].[ClientesPolizas]  WITH CHECK ADD  CONSTRAINT [FK_ClientesPolizas_Clientes] FOREIGN KEY([Cliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[ClientesPolizas] CHECK CONSTRAINT [FK_ClientesPolizas_Clientes]
GO
ALTER TABLE [dbo].[ClientesPolizas]  WITH CHECK ADD  CONSTRAINT [FK_ClientesPolizas_Polizas] FOREIGN KEY([Poliza])
REFERENCES [dbo].[Polizas] ([Id])
GO
ALTER TABLE [dbo].[ClientesPolizas] CHECK CONSTRAINT [FK_ClientesPolizas_Polizas]
GO
ALTER TABLE [dbo].[CubrimientosPoliza]  WITH CHECK ADD  CONSTRAINT [FK_CubrimientosPoliza_Cubrimientos] FOREIGN KEY([Cubrimiento])
REFERENCES [dbo].[Cubrimientos] ([Id])
GO
ALTER TABLE [dbo].[CubrimientosPoliza] CHECK CONSTRAINT [FK_CubrimientosPoliza_Cubrimientos]
GO
ALTER TABLE [dbo].[CubrimientosPoliza]  WITH CHECK ADD  CONSTRAINT [FK_CubrimientosPoliza_Polizas] FOREIGN KEY([Poliza])
REFERENCES [dbo].[Polizas] ([Id])
GO
ALTER TABLE [dbo].[CubrimientosPoliza] CHECK CONSTRAINT [FK_CubrimientosPoliza_Polizas]
GO
ALTER TABLE [dbo].[Polizas]  WITH CHECK ADD  CONSTRAINT [FK_Polizas_NivelesRiesgo] FOREIGN KEY([Riesgo])
REFERENCES [dbo].[NivelesRiesgo] ([Id])
GO
ALTER TABLE [dbo].[Polizas] CHECK CONSTRAINT [FK_Polizas_NivelesRiesgo]
GO
