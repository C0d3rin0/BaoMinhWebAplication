
USE [DevDB]
/****** Object:  Table [dbo].[AGNTPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AGNTPF$](
	[AGNTPFX] [nvarchar](255) NULL,
	[AGNTCOY] [nvarchar](255) NULL,
	[AGNTNUM] [nvarchar](255) NULL,
	[TRANID] [nvarchar](255) NULL,
	[VALIDFLAG] [nvarchar](255) NULL,
	[CLNTPFX] [nvarchar](255) NULL,
	[CLNTCOY] [nvarchar](255) NULL,
	[CLNTNUM] [nvarchar](255) NULL,
	[AGNTREL] [nvarchar](255) NULL,
	[AGTYPE01] [nvarchar](255) NULL,
	[AGNTBR] [nvarchar](255) NULL,
	[REPLVL] [float] NULL,
	[REPAGENT01] [nvarchar](255) NULL,
	[REPAGENT02] [nvarchar](255) NULL,
	[REPAGENT03] [nvarchar](255) NULL,
	[REPAGENT04] [nvarchar](255) NULL,
	[REPAGENT05] [nvarchar](255) NULL,
	[REPAGENT06] [nvarchar](255) NULL,
	[REPORTAG01] [nvarchar](255) NULL,
	[REPORTAG02] [nvarchar](255) NULL,
	[REPORTAG03] [nvarchar](255) NULL,
	[REPORTAG04] [nvarchar](255) NULL,
	[REPORTAG05] [nvarchar](255) NULL,
	[REPORTAG06] [nvarchar](255) NULL,
	[FGAGNT] [nvarchar](255) NULL,
	[FGCOMMTABL] [nvarchar](255) NULL,
	[LIFAGNT] [nvarchar](255) NULL,
	[CHDRSTCDA] [nvarchar](255) NULL,
	[CHDRSTCDB] [nvarchar](255) NULL,
	[CHDRSTCDC] [nvarchar](255) NULL,
	[CHDRSTCDD] [nvarchar](255) NULL,
	[CHDRS0001] [nvarchar](255) NULL,
	[START_DATE] [nvarchar](255) NULL,
	[DATEEND] [nvarchar](255) NULL,
	[CONTPERS] [nvarchar](255) NULL,
	[TAKOAGNT] [nvarchar](255) NULL,
	[ACCOUNT_RECONCILIATION] [nvarchar](255) NULL,
	[STATEMENT_REQD] [nvarchar](255) NULL,
	[CRTERM] [nvarchar](255) NULL,
	[CRLIMIT] [float] NULL,
	[STLBASIS] [nvarchar](255) NULL,
	[EXPIRY_NOTICE] [nvarchar](255) NULL,
	[LICENCE] [nvarchar](255) NULL,
	[RIDESC01] [nvarchar](255) NULL,
	[RLRPFX] [nvarchar](255) NULL,
	[RLRCOY] [nvarchar](255) NULL,
	[RLRACC] [nvarchar](255) NULL,
	[MSAGNT] [nvarchar](255) NULL,
	[REPORTTO] [nvarchar](255) NULL,
	[CREDITTRM] [float] NULL,
	[ZBKIND] [nvarchar](255) NULL,
	[ZDISTRICT] [nvarchar](255) NULL,
	[ZFGCMTBN] [nvarchar](255) NULL,
	[ZSTAFFCD01] [nvarchar](255) NULL,
	[BANKCODE01] [nvarchar](255) NULL,
	[BANKCODE02] [nvarchar](255) NULL,
	[BANKCODE03] [nvarchar](255) NULL,
	[BANKCODE04] [nvarchar](255) NULL,
	[BANKCODE05] [nvarchar](255) NULL,
	[USER_PRO0001] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHDRPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHDRPF$](
	[CHDRPFX] [nvarchar](255) NULL,
	[CHDRCOY] [nvarchar](255) NULL,
	[CHDRNUM] [nvarchar](255) NULL,
	[RECODE] [nvarchar](255) NULL,
	[SERVUNIT] [nvarchar](255) NULL,
	[CNTTYPE] [nvarchar](255) NULL,
	[TRANNO] [float] NULL,
	[TRANID] [nvarchar](255) NULL,
	[VALIDFLAG] [nvarchar](255) NULL,
	[CURRFROM] [float] NULL,
	[CURRTO] [float] NULL,
	[PROCTRANCD] [nvarchar](255) NULL,
	[PROCFLAG] [nvarchar](255) NULL,
	[PROCID] [nvarchar](255) NULL,
	[STATCODE] [nvarchar](255) NULL,
	[STATREASN] [nvarchar](255) NULL,
	[STATDATE] [float] NULL,
	[STATTRAN] [float] NULL,
	[TRANLUSED] [float] NULL,
	[OCCDATE] [nvarchar](255) NULL,
	[CCDATE] [nvarchar](255) NULL,
	[CRDATE] [nvarchar](255) NULL,
	[ANNAMT01] [float] NULL,
	[ANNAMT02] [float] NULL,
	[ANNAMT03] [float] NULL,
	[ANNAMT04] [float] NULL,
	[ANNAMT05] [float] NULL,
	[ANNAMT06] [float] NULL,
	[RNLTYPE] [nvarchar](255) NULL,
	[RNLNOTS] [nvarchar](255) NULL,
	[RNLNOTTO] [nvarchar](255) NULL,
	[RNLATTN] [nvarchar](255) NULL,
	[RNLDURN] [float] NULL,
	[REPTYPE] [nvarchar](255) NULL,
	[REPNUM] [nvarchar](255) NULL,
	[COWNPFX] [nvarchar](255) NULL,
	[COWNCOY] [nvarchar](255) NULL,
	[COWNNUM] [nvarchar](255) NULL,
	[JOWNNUM] [nvarchar](255) NULL,
	[PAYRPFX] [nvarchar](255) NULL,
	[PAYRCOY] [nvarchar](255) NULL,
	[PAYRNUM] [nvarchar](255) NULL,
	[DESPPFX] [nvarchar](255) NULL,
	[DESPCOY] [nvarchar](255) NULL,
	[DESPNUM] [nvarchar](255) NULL,
	[ASGNPFX] [nvarchar](255) NULL,
	[ASGNCOY] [nvarchar](255) NULL,
	[ASGNNUM] [nvarchar](255) NULL,
	[CNTBRANCH] [nvarchar](255) NULL,
	[AGNTPFX] [nvarchar](255) NULL,
	[AGNTCOY] [nvarchar](255) NULL,
	[AGNTNUM] [nvarchar](255) NULL,
	[CNTCURR] [nvarchar](255) NULL,
	[ACCTCCY] [nvarchar](255) NULL,
	[CRATE] [float] NULL,
	[PAYPLAN] [nvarchar](255) NULL,
	[ACCTMETH] [nvarchar](255) NULL,
	[BILLFREQ] [nvarchar](255) NULL,
	[BILLCHNL] [nvarchar](255) NULL,
	[COLLCHNL] [nvarchar](255) NULL,
	[BILLDAY] [nvarchar](255) NULL,
	[BILLMONTH] [nvarchar](255) NULL,
	[BILLCD] [float] NULL,
	[BTDATE] [float] NULL,
	[PTDATE] [float] NULL,
	[PAYFLAG] [nvarchar](255) NULL,
	[SINSTFROM] [float] NULL,
	[SINSTTO] [float] NULL,
	[SINSTAMT01] [float] NULL,
	[SINSTAMT02] [float] NULL,
	[SINSTAMT03] [float] NULL,
	[SINSTAMT04] [float] NULL,
	[SINSTAMT05] [float] NULL,
	[SINSTAMT06] [float] NULL,
	[INSTFROM] [float] NULL,
	[INSTTO] [float] NULL,
	[INSTBCHNL] [nvarchar](255) NULL,
	[INSTCCHNL] [nvarchar](255) NULL,
	[INSTFREQ] [nvarchar](255) NULL,
	[INSTTOT01] [float] NULL,
	[INSTTOT02] [float] NULL,
	[INSTTOT03] [float] NULL,
	[INSTTOT04] [float] NULL,
	[INSTTOT05] [float] NULL,
	[INSTTOT06] [float] NULL,
	[INSTPAST01] [float] NULL,
	[INSTPAST02] [float] NULL,
	[INSTPAST03] [float] NULL,
	[INSTPAST04] [float] NULL,
	[INSTPAST05] [float] NULL,
	[INSTPAST06] [float] NULL,
	[INSTJCTL] [nvarchar](255) NULL,
	[NOFOUTINST] [float] NULL,
	[OUTSTAMT] [float] NULL,
	[BILLDATE01] [float] NULL,
	[BILLDATE02] [float] NULL,
	[BILLDATE03] [float] NULL,
	[BILLDATE04] [float] NULL,
	[BILLAMT01] [float] NULL,
	[BILLAMT02] [float] NULL,
	[BILLAMT03] [float] NULL,
	[BILLAMT04] [float] NULL,
	[FACTHOUS] [nvarchar](255) NULL,
	[BANKKEY] [nvarchar](255) NULL,
	[BANKACCKEY] [nvarchar](255) NULL,
	[DISCODE01] [nvarchar](255) NULL,
	[DISCODE02] [nvarchar](255) NULL,
	[DISCODE03] [nvarchar](255) NULL,
	[DISCODE04] [nvarchar](255) NULL,
	[GRUPKEY] [nvarchar](255) NULL,
	[MEMBSEL] [nvarchar](255) NULL,
	[APLSUPR] [nvarchar](255) NULL,
	[APLSPFROM] [float] NULL,
	[APLSPTO] [float] NULL,
	[BILLSUPR] [nvarchar](255) NULL,
	[BILLSPFROM] [float] NULL,
	[BILLSPTO] [float] NULL,
	[COMMSUPR] [nvarchar](255) NULL,
	[COMMSPFROM] [float] NULL,
	[COMMSPTO] [float] NULL,
	[LAPSSUPR] [nvarchar](255) NULL,
	[LAPSSPFROM] [float] NULL,
	[LAPSSPTO] [float] NULL,
	[MAILSUPR] [nvarchar](255) NULL,
	[MAILSPFROM] [float] NULL,
	[MAILSPTO] [float] NULL,
	[NOTSSUPR] [nvarchar](255) NULL,
	[NOTSSPFROM] [float] NULL,
	[NOTSSPTO] [float] NULL,
	[RNWLSUPR] [nvarchar](255) NULL,
	[RNWLSPFROM] [float] NULL,
	[RNWLSPTO] [float] NULL,
	[CAMPAIGN] [nvarchar](255) NULL,
	[SRCEBUS] [nvarchar](255) NULL,
	[NOFRISKS] [float] NULL,
	[JACKET] [nvarchar](255) NULL,
	[INSTSTAMT01] [float] NULL,
	[INSTSTAMT02] [float] NULL,
	[INSTSTAMT03] [float] NULL,
	[INSTSTAMT04] [float] NULL,
	[INSTSTAMT05] [float] NULL,
	[INSTSTAMT06] [float] NULL,
	[PSTATCODE] [nvarchar](255) NULL,
	[PSTATREASN] [nvarchar](255) NULL,
	[PSTATTRAN] [float] NULL,
	[PSTATDATE] [float] NULL,
	[PDIND] [nvarchar](255) NULL,
	[REGISTER] [nvarchar](255) NULL,
	[CHDRSTCDA] [nvarchar](255) NULL,
	[CHDRSTCDB] [nvarchar](255) NULL,
	[CHDRSTCDC] [nvarchar](255) NULL,
	[CHDRSTCDD] [nvarchar](255) NULL,
	[CHDRSTCDE] [nvarchar](255) NULL,
	[MPLPFX] [nvarchar](255) NULL,
	[MPLCOY] [nvarchar](255) NULL,
	[MPLNUM] [nvarchar](255) NULL,
	[POAPFX] [nvarchar](255) NULL,
	[POACOY] [nvarchar](255) NULL,
	[POANUM] [nvarchar](255) NULL,
	[FINPFX] [nvarchar](255) NULL,
	[FINCOY] [nvarchar](255) NULL,
	[FINNUM] [nvarchar](255) NULL,
	[WVFDAT] [float] NULL,
	[WVTDAT] [float] NULL,
	[WVFIND] [nvarchar](255) NULL,
	[CLUPFX] [nvarchar](255) NULL,
	[CLUCOY] [nvarchar](255) NULL,
	[CLUNUM] [nvarchar](255) NULL,
	[POLPLN] [nvarchar](255) NULL,
	[CHGFLAG] [nvarchar](255) NULL,
	[LAPRIND] [nvarchar](255) NULL,
	[SPECIND] [nvarchar](255) NULL,
	[DUEFLG] [nvarchar](255) NULL,
	[BFCHARGE] [nvarchar](255) NULL,
	[DISHNRCNT] [float] NULL,
	[PDTYPE] [nvarchar](255) NULL,
	[DISHNRDTE] [float] NULL,
	[STMPDTYAMT] [float] NULL,
	[STMPDTYDTE] [float] NULL,
	[POLINC] [float] NULL,
	[POLSUM] [float] NULL,
	[NXTSFX] [float] NULL,
	[AVLISU] [nvarchar](255) NULL,
	[STATEMENT_DATE] [float] NULL,
	[BILLCURR] [nvarchar](255) NULL,
	[FREE_SWITCHES_USED] [float] NULL,
	[FREE_SWITCHES_LEFT] [float] NULL,
	[LAST_SWITCH_DATE] [float] NULL,
	[MANDREF] [nvarchar](255) NULL,
	[CNTISS] [float] NULL,
	[CNTRCV] [float] NULL,
	[COPPN] [float] NULL,
	[COTYPE] [nvarchar](255) NULL,
	[COVERNT] [nvarchar](255) NULL,
	[DOCNUM] [nvarchar](255) NULL,
	[DTECAN] [float] NULL,
	[QUOTENO] [nvarchar](255) NULL,
	[RNLSTS] [nvarchar](255) NULL,
	[SUSTRCDE] [nvarchar](255) NULL,
	[BANKCODE] [nvarchar](255) NULL,
	[PNDATE] [float] NULL,
	[SUBSFLG] [nvarchar](255) NULL,
	[HRSKIND] [nvarchar](255) NULL,
	[SLRYPFLG] [nvarchar](255) NULL,
	[TAKOVRFLG] [nvarchar](255) NULL,
	[GPRNLTYP] [nvarchar](255) NULL,
	[GPRMNTHS] [float] NULL,
	[COYSRVAC] [nvarchar](255) NULL,
	[MRKSRVAC] [nvarchar](255) NULL,
	[POLSCHPFLG] [nvarchar](255) NULL,
	[ADJDATE] [float] NULL,
	[PTDATEAB] [float] NULL,
	[LMBRNO] [float] NULL,
	[LHEADNO] [float] NULL,
	[EFFDCLDT] [float] NULL,
	[PNTRCDE] [nvarchar](255) NULL,
	[TAXFLAG] [nvarchar](255) NULL,
	[AGEDEF] [nvarchar](255) NULL,
	[TERMAGE] [float] NULL,
	[PERSONCOV] [nvarchar](255) NULL,
	[ENROLLTYP] [nvarchar](255) NULL,
	[SPLITSUBS] [nvarchar](255) NULL,
	[DTLSIND] [nvarchar](255) NULL,
	[ZRENNO] [float] NULL,
	[ZENDNO] [float] NULL,
	[ZRESNPD] [nvarchar](255) NULL,
	[ZREPOLNO] [nvarchar](255) NULL,
	[ZCOMTYP] [nvarchar](255) NULL,
	[ZRINUM] [nvarchar](255) NULL,
	[ZSCHPRT] [nvarchar](255) NULL,
	[ZPAYMODE] [nvarchar](255) NULL,
	[USER_PROFILE] [nvarchar](255) NULL,
	[JOBNAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHEXPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHEXPF$](
	[CHDRPFX] [nvarchar](255) NULL,
	[CHDRCOY] [nvarchar](255) NULL,
	[CHDRNUM] [nvarchar](255) NULL,
	[VALIDFLAG] [nvarchar](255) NULL,
	[CURRFROM] [float] NULL,
	[TRANNO] [float] NULL,
	[ZREFRA] [nvarchar](255) NULL,
	[ZREFRB] [nvarchar](255) NULL,
	[BUSORG] [nvarchar](255) NULL,
	[ACSTYP] [nvarchar](255) NULL,
	[ZSTAFFCD] [nvarchar](255) NULL,
	[ZDEPTCD] [nvarchar](255) NULL,
	[OVRDIND] [nvarchar](255) NULL,
	[ZPQRIND] [nvarchar](255) NULL,
	[ZPQRCONV] [nvarchar](255) NULL,
	[TEMPLT] [nvarchar](255) NULL,
	[BULKBOOK] [nvarchar](255) NULL,
	[VATMETH] [nvarchar](255) NULL,
	[VATDOCTY] [nvarchar](255) NULL,
	[NONMOC] [nvarchar](255) NULL,
	[FRECOVR] [nvarchar](255) NULL,
	[FREINST] [float] NULL,
	[USER_PROFILE] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CLNTPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLNTPF$](
	[CLNTPFX] [nvarchar](255) NULL,
	[CLNTCOY] [nvarchar](255) NULL,
	[CLNTNUM] [nvarchar](255) NULL,
	[TRANID] [nvarchar](255) NULL,
	[VALIDFLAG] [nvarchar](255) NULL,
	[CLTTYPE] [nvarchar](255) NULL,
	[SECUITYNO] [nvarchar](255) NULL,
	[PAYROLLNO] [nvarchar](255) NULL,
	[SURNAME] [nvarchar](255) NULL,
	[GIVNAME] [nvarchar](255) NULL,
	[SALUT] [nvarchar](255) NULL,
	[INITIALS] [nvarchar](255) NULL,
	[CLTSEX] [nvarchar](255) NULL,
	[CLTADDR01] [nvarchar](255) NULL,
	[CLTADDR02] [nvarchar](255) NULL,
	[CLTADDR03] [nvarchar](255) NULL,
	[CLTADDR04] [nvarchar](255) NULL,
	[CLTADDR05] [nvarchar](255) NULL,
	[CLTPCODE] [nvarchar](255) NULL,
	[CTRYCODE] [nvarchar](255) NULL,
	[MAILING] [nvarchar](255) NULL,
	[DIRMAIL] [nvarchar](255) NULL,
	[ADDRTYPE] [nvarchar](255) NULL,
	[CLTPHONE01] [nvarchar](255) NULL,
	[CLTPHONE02] [nvarchar](255) NULL,
	[VIP] [nvarchar](255) NULL,
	[OCCPCODE] [nvarchar](255) NULL,
	[SERVBRH] [nvarchar](255) NULL,
	[STATCODE] [nvarchar](255) NULL,
	[CLTDOB] [float] NULL,
	[SOE] [nvarchar](255) NULL,
	[DOCNO] [nvarchar](255) NULL,
	[CLTDOD] [float] NULL,
	[CLTSTAT] [nvarchar](255) NULL,
	[CLTMCHG] [nvarchar](255) NULL,
	[MIDDL01] [nvarchar](255) NULL,
	[MIDDL02] [nvarchar](255) NULL,
	[MARRYD] [nvarchar](255) NULL,
	[TLXNO] [nvarchar](255) NULL,
	[FAXNO] [nvarchar](255) NULL,
	[TGRAM] [nvarchar](255) NULL,
	[BIRTHP] [nvarchar](255) NULL,
	[SALUTL] [nvarchar](255) NULL,
	[ROLEFLAG01] [nvarchar](255) NULL,
	[ROLEFLAG02] [nvarchar](255) NULL,
	[ROLEFLAG03] [nvarchar](255) NULL,
	[ROLEFLAG04] [nvarchar](255) NULL,
	[ROLEFLAG05] [nvarchar](255) NULL,
	[ROLEFLAG06] [nvarchar](255) NULL,
	[ROLEFLAG07] [nvarchar](255) NULL,
	[ROLEFLAG08] [nvarchar](255) NULL,
	[ROLEFLAG09] [nvarchar](255) NULL,
	[ROLEFLAG10] [nvarchar](255) NULL,
	[ROLEFLAG11] [nvarchar](255) NULL,
	[ROLEFLAG12] [nvarchar](255) NULL,
	[LSURNAME] [nvarchar](255) NULL,
	[LGIVNAME] [nvarchar](255) NULL,
	[TAXFLAG] [nvarchar](255) NULL,
	[USER_PROFILE] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DESCPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DESCPF$](
	[DESCPFX] [nvarchar](255) NULL,
	[DESCCOY] [nvarchar](255) NULL,
	[DESCTABL] [nvarchar](255) NULL,
	[DESCITEM] [nvarchar](255) NULL,
	[ITEMSEQ] [nvarchar](255) NULL,
	[LANGUAGE] [nvarchar](255) NULL,
	[TRANID] [nvarchar](255) NULL,
	[SHORTDESC] [nvarchar](255) NULL,
	[LONGDESC] [nvarchar](255) NULL,
	[USER_PROFILE] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuImport]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuImport](
	[ThoiGian] [datetime] NULL,
	[LaChayTuDong] [bit] NULL,
	[TrangThai] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nhom]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhom](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nchar](10) NOT NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_Nhom] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhomThuocChiNhanh]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomThuocChiNhanh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaChiNhanh] [int] NOT NULL,
	[MaNhom] [int] NOT NULL,
 CONSTRAINT [PK_NhomThuocChiNhanh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PQDONVI$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PQDONVI$](
	[id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
 CONSTRAINT [PK__PQDONVI$__3213E83FAE7C035B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PREMPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PREMPF$](
	[RSKPFX] [nvarchar](255) NULL,
	[RSKCOY] [nvarchar](255) NULL,
	[CHDRNO] [nvarchar](255) NULL,
	[RSKNO] [float] NULL,
	[DTEEFF] [float] NULL,
	[TRANNO] [float] NULL,
	[PREMCL] [nvarchar](255) NULL,
	[CRDATE] [nvarchar](255) NULL,
	[SACSCODE] [nvarchar](255) NULL,
	[SACSTYP01] [nvarchar](255) NULL,
	[SACSTYP02] [nvarchar](255) NULL,
	[SACSTYP03] [nvarchar](255) NULL,
	[SACSTYP04] [nvarchar](255) NULL,
	[SACSTYP05] [nvarchar](255) NULL,
	[SACSTYP06] [nvarchar](255) NULL,
	[SACSTYP07] [nvarchar](255) NULL,
	[SACSTYP08] [nvarchar](255) NULL,
	[SACSTYP09] [nvarchar](255) NULL,
	[SACSTYP10] [nvarchar](255) NULL,
	[SACSTYP11] [nvarchar](255) NULL,
	[SACSTYP12] [nvarchar](255) NULL,
	[SACSTYP13] [nvarchar](255) NULL,
	[SACSTYP14] [nvarchar](255) NULL,
	[SACSTYP15] [nvarchar](255) NULL,
	[ANNL01] [float] NULL,
	[ANNL02] [float] NULL,
	[ANNL03] [float] NULL,
	[ANNL04] [float] NULL,
	[ANNL05] [float] NULL,
	[ANNL06] [float] NULL,
	[ANNL07] [float] NULL,
	[ANNL08] [float] NULL,
	[ANNL09] [float] NULL,
	[ANNL10] [float] NULL,
	[ANNL11] [float] NULL,
	[ANNL12] [float] NULL,
	[ANNL13] [float] NULL,
	[ANNL14] [float] NULL,
	[ANNL15] [float] NULL,
	[EXTR01] [float] NULL,
	[EXTR02] [float] NULL,
	[EXTR03] [float] NULL,
	[EXTR04] [float] NULL,
	[EXTR05] [float] NULL,
	[EXTR06] [float] NULL,
	[EXTR07] [float] NULL,
	[EXTR08] [float] NULL,
	[EXTR09] [float] NULL,
	[EXTR10] [float] NULL,
	[EXTR11] [float] NULL,
	[EXTR12] [float] NULL,
	[EXTR13] [float] NULL,
	[EXTR14] [float] NULL,
	[EXTR15] [float] NULL,
	[CALMETH01] [nvarchar](255) NULL,
	[CALMETH02] [nvarchar](255) NULL,
	[CALMETH03] [nvarchar](255) NULL,
	[CALMETH04] [nvarchar](255) NULL,
	[CALMETH05] [nvarchar](255) NULL,
	[CALMETH06] [nvarchar](255) NULL,
	[CALMETH07] [nvarchar](255) NULL,
	[INDISC] [float] NULL,
	[EXRAT] [float] NULL,
	[TPIND01] [nvarchar](255) NULL,
	[TPIND02] [nvarchar](255) NULL,
	[TPIND03] [nvarchar](255) NULL,
	[AGPC] [float] NULL,
	[ORPC] [float] NULL,
	[GRNR] [nvarchar](255) NULL,
	[ORAGNT] [nvarchar](255) NULL,
	[PRORIG] [float] NULL,
	[METHOD] [nvarchar](255) NULL,
	[RIMETH] [nvarchar](255) NULL,
	[INSTNO] [float] NULL,
	[TRANS_CODE] [nvarchar](255) NULL,
	[TERMID] [nvarchar](255) NULL,
	[TRANSACTION_DATE] [float] NULL,
	[TRANSACTION_TIME] [float] NULL,
	[USER] [float] NULL,
	[REVPREM] [float] NULL,
	[USER_PROFILE] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL,
	[CALMETHCCM] [nvarchar](255) NULL,
	[CALMETHCOR] [nvarchar](255) NULL,
	[ZOAPC] [float] NULL,
	[DTETER] [float] NULL,
	[CURRFROM] [float] NULL,
	[CURRTO] [float] NULL,
	[RNLTYPE] [nvarchar](255) NULL,
	[ZMEPC] [float] NULL,
	[ZMEANNL] [float] NULL,
	[ZMEEXTR] [float] NULL,
	[ZCMPC] [float] NULL,
	[ZCMANNL] [float] NULL,
	[ZCMEXTR] [float] NULL,
	[ZCMIND] [nvarchar](255) NULL,
	[GTGRNR] [nvarchar](255) NULL,
	[TOTSI] [float] NULL,
	[IND] [nvarchar](255) NULL,
	[RATE01] [float] NULL,
	[RATE02] [float] NULL,
	[RATE03] [float] NULL,
	[RATE04] [float] NULL,
	[RATE05] [float] NULL,
	[RATE06] [float] NULL,
	[RATE07] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuyenTai_NhomThuocChiNhanh]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyenTai_NhomThuocChiNhanh](
	[id] [int] NOT NULL,
	[Quyen] [int] NOT NULL,
 CONSTRAINT [PK_QuyenTai_NhomThuocChiNhanh] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[Quyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuyenXem_NhomThuocChiNhanh]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyenXem_NhomThuocChiNhanh](
	[id] [int] NOT NULL,
	[Quyen] [int] NOT NULL,
 CONSTRAINT [PK_QuyenXem_NhomThuocChiNhanh_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[Quyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RISKPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RISKPF$](
	[RSKPFX] [nvarchar](255) NULL,
	[RSKCOY] [nvarchar](255) NULL,
	[CHDRNO] [nvarchar](255) NULL,
	[RSKNO] [float] NULL,
	[VALID_FLAG] [nvarchar](255) NULL,
	[CNTTYP] [nvarchar](255) NULL,
	[RSKTYP] [nvarchar](255) NULL,
	[TRANNO] [float] NULL,
	[TRANID] [nvarchar](255) NULL,
	[DTEEFF] [float] NULL,
	[DTEATT] [float] NULL,
	[DTETER] [float] NULL,
	[RECFORMAT] [nvarchar](255) NULL,
	[RATFLG] [nvarchar](255) NULL,
	[SICURR] [nvarchar](255) NULL,
	[SIRAT] [float] NULL,
	[TOTSI] [float] NULL,
	[TOTSIL] [float] NULL,
	[TOTPRE] [float] NULL,
	[USER_PROFILE] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](255) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[LaAdmin] [bit] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoanThuocNhom]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanThuocNhom](
	[MaTaiKhoan] [int] NOT NULL,
	[MaNhom] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoanThuocNhom] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC,
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ZTRNPF$]    Script Date: 11-Mar-18 1:17:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZTRNPF$](
	[BATCPFX] [nvarchar](255) NULL,
	[BATCCOY] [nvarchar](255) NULL,
	[BATCBRN] [nvarchar](255) NULL,
	[BATCACTYR] [float] NULL,
	[BATCACTMN] [float] NULL,
	[BATCTRCDE] [nvarchar](255) NULL,
	[BATCBATCH] [nvarchar](255) NULL,
	[RLDGPFX] [nvarchar](255) NULL,
	[RLDGCOY] [nvarchar](255) NULL,
	[RLDGACCT] [nvarchar](255) NULL,
	[ORIGCURR] [nvarchar](255) NULL,
	[ACCTCURR] [nvarchar](255) NULL,
	[CRATE] [float] NULL,
	[CNTTYPE] [nvarchar](255) NULL,
	[TRANNO] [float] NULL,
	[CNTBRANCH] [nvarchar](255) NULL,
	[CHDRSTCDA] [nvarchar](255) NULL,
	[CHDRSTCDB] [nvarchar](255) NULL,
	[CHDRSTCDC] [nvarchar](255) NULL,
	[CHDRSTCDD] [nvarchar](255) NULL,
	[CHDRSTCDE] [nvarchar](255) NULL,
	[POSTMONTH] [nvarchar](255) NULL,
	[POSTYEAR] [nvarchar](255) NULL,
	[TRANDATE] [float] NULL,
	[TRANTIME] [float] NULL,
	[EFFDATE] [float] NULL,
	[SACSCODE] [nvarchar](255) NULL,
	[SACSTYP01] [nvarchar](255) NULL,
	[SACSTYP02] [nvarchar](255) NULL,
	[SACSTYP03] [nvarchar](255) NULL,
	[SACSTYP04] [nvarchar](255) NULL,
	[SACSTYP05] [nvarchar](255) NULL,
	[SACSTYP06] [nvarchar](255) NULL,
	[SACSTYP07] [nvarchar](255) NULL,
	[SACSTYP08] [nvarchar](255) NULL,
	[SACSTYP09] [nvarchar](255) NULL,
	[SACSTYP10] [nvarchar](255) NULL,
	[SACSTYP11] [nvarchar](255) NULL,
	[SACSTYP12] [nvarchar](255) NULL,
	[SACSTYP13] [nvarchar](255) NULL,
	[SACSTYP14] [nvarchar](255) NULL,
	[SACSTYP15] [nvarchar](255) NULL,
	[TRANAMT01] [float] NULL,
	[TRANAMT02] [float] NULL,
	[TRANAMT03] [float] NULL,
	[TRANAMT04] [float] NULL,
	[TRANAMT05] [float] NULL,
	[TRANAMT06] [float] NULL,
	[TRANAMT07] [float] NULL,
	[TRANAMT08] [float] NULL,
	[TRANAMT09] [float] NULL,
	[TRANAMT10] [float] NULL,
	[TRANAMT11] [float] NULL,
	[TRANAMT12] [float] NULL,
	[TRANAMT13] [float] NULL,
	[TRANAMT14] [float] NULL,
	[TRANAMT15] [float] NULL,
	[GLSIGN01] [nvarchar](255) NULL,
	[GLSIGN02] [nvarchar](255) NULL,
	[GLSIGN03] [nvarchar](255) NULL,
	[GLSIGN04] [nvarchar](255) NULL,
	[GLSIGN05] [nvarchar](255) NULL,
	[GLSIGN06] [nvarchar](255) NULL,
	[GLSIGN07] [nvarchar](255) NULL,
	[GLSIGN08] [nvarchar](255) NULL,
	[GLSIGN09] [nvarchar](255) NULL,
	[GLSIGN10] [nvarchar](255) NULL,
	[GLSIGN11] [nvarchar](255) NULL,
	[GLSIGN12] [nvarchar](255) NULL,
	[GLSIGN13] [nvarchar](255) NULL,
	[GLSIGN14] [nvarchar](255) NULL,
	[GLSIGN15] [nvarchar](255) NULL,
	[GENLCUR] [nvarchar](255) NULL,
	[GENLPFX] [nvarchar](255) NULL,
	[GENLCOY] [nvarchar](255) NULL,
	[GLCODE01] [nvarchar](255) NULL,
	[GLCODE02] [nvarchar](255) NULL,
	[GLCODE03] [nvarchar](255) NULL,
	[GLCODE04] [nvarchar](255) NULL,
	[GLCODE05] [nvarchar](255) NULL,
	[GLCODE06] [nvarchar](255) NULL,
	[GLCODE07] [nvarchar](255) NULL,
	[GLCODE08] [nvarchar](255) NULL,
	[GLCODE09] [nvarchar](255) NULL,
	[GLCODE10] [nvarchar](255) NULL,
	[GLCODE11] [nvarchar](255) NULL,
	[GLCODE12] [nvarchar](255) NULL,
	[GLCODE13] [nvarchar](255) NULL,
	[GLCODE14] [nvarchar](255) NULL,
	[GLCODE15] [nvarchar](255) NULL,
	[ACCPFX] [nvarchar](255) NULL,
	[ACCCOY] [nvarchar](255) NULL,
	[ACCNUM] [nvarchar](255) NULL,
	[CCDATE] [nvarchar](255) NULL,
	[EXPIRY_DATE] [float] NULL,
	[LIFE] [nvarchar](255) NULL,
	[COVERAGE] [nvarchar](255) NULL,
	[RIDER] [nvarchar](255) NULL,
	[ACCTYP] [nvarchar](255) NULL,
	[USER_PROFILE] [nvarchar](255) NULL,
	[JOB_NAME] [nvarchar](255) NULL,
	[DATIME] [nvarchar](255) NULL,
	[ORAGNT] [nvarchar](255) NULL,
	[BANKCODE] [nvarchar](255) NULL,
	[DOCTPFX] [nvarchar](255) NULL,
	[DOCTCOY] [nvarchar](255) NULL,
	[DOCTNUM] [nvarchar](255) NULL,
	[INSTNO] [float] NULL,
	[BILLFREQ] [nvarchar](255) NULL,
	[STATREASN] [nvarchar](255) NULL,
	[PRTFLG] [nvarchar](255) NULL,
	[RITYPE] [nvarchar](255) NULL,
	[RDOCPFX] [nvarchar](255) NULL,
	[RDOCCOY] [nvarchar](255) NULL,
	[RDOCNUM] [nvarchar](255) NULL,
	[NOSCHCPY] [float] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (4, N'BẢO MINH HÀ NỘI')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (5, N'BẢO MINH THĂNG LONG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (6, N'BẢO MINH ĐÔNG ĐÔ')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (7, N'BẢO MINH TRÀNG AN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (8, N'BẢO MINH SÀI GÒN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (9, N'BẢO MINH CHỢ LỚN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (10, N'BẢO MINH BẾN THÀNH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (11, N'BẢO MINH BẾN NGHÉ')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (20, N'BẢO MINH LÀO CAI')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (21, N'BẢO MINH PHÚ THỌ')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (24, N'BẢO MINH BẮC GIANG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (25, N'BẢO MINH LẠNG SƠN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (28, N'BẢO MINH THÁI NGUYÊN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (29, N'BẢO MINH YÊN BÁI')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (30, N'BẢO MINH NINH BÌNH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (31, N'BẢO MINH HẢI PHÒNG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (32, N'BẢO MINH HẢI DƯƠNG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (33, N'BẢO MINH QUẢNG NINH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (35, N'BẢO MINH NAM ĐỊNH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (36, N'BẢO MINH THÁI BÌNH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (37, N'BẢO MINH THANH HÓA')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (38, N'BẢO MINH NGHỆ AN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (39, N'BẢO MINH HÀ TĨNH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (40, N'BẢO MINH VĨNH PHÚC')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (41, N'BẢO MINH BẮC NINH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (42, N'BẢO MINH HƯNG YÊN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (43, N'BẢO MINH HÀ NAM')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (44, N'BẢO MINH ĐAK NÔNG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (45, N'BẢO MINH ĐÀ NẴNG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (46, N'BẢO MINH BÌNH PHƯỚC')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (48, N'BẢO MINH BẠC LIÊU')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (50, N'BẢO MINH ĐAKLAK')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (51, N'BẢO MINH QUẢNG NAM')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (52, N'BẢO MINH QUẢNG BÌNH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (53, N'BẢO MINH QUẢNG TRỊ')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (54, N'BẢO MINH HUẾ')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (55, N'BẢO MINH QUẢNG NGÃI')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (56, N'BẢO MINH BÌNH ĐỊNH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (57, N'BẢO MINH PHÚ YÊN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (58, N'BẢO MINH KHÁNH HÒA')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (59, N'BẢO MINH GIA LAI')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (60, N'BẢO MINH KON TUM')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (61, N'BẢO MINH ĐỒNG NAI')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (62, N'BẢO MINH BÌNH THUẬN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (63, N'BẢO MINH LÂM ĐỒNG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (64, N'BẢO MINH VŨNG TÀU')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (65, N'BẢO MINH BÌNH DƯƠNG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (66, N'BẢO MINH TÂY NINH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (67, N'BẢO MINH ĐỒNG THÁP')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (68, N'BẢO MINH NINH THUẬN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (69, N'BẢO MINH SÔNG BÉ')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (70, N'BẢO MINH VĨNH LONG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (71, N'BẢO MINH CẦN THƠ')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (72, N'BẢO MINH LONG AN')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (73, N'BẢO MINH TIỀN GIANG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (74, N'BẢO MINH TRÀ VINH')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (75, N'BẢO MINH BẾN TRE')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (76, N'BẢO MINH AN GIANG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (77, N'BẢO MINH KIÊN GIANG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (78, N'BẢO MINH CÀ MAU')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (79, N'BẢO MINH SÓC TRĂNG')
INSERT [dbo].[PQDONVI$] ([id], [name]) VALUES (90, N'BẢO MINH GIA ĐỊNH')
ALTER TABLE [dbo].[Nhom] ADD  CONSTRAINT [DF_Nhom_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [DF_TaiKhoan_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhomThuocChiNhanh]  WITH CHECK ADD  CONSTRAINT [FK_NhomThuocChiNhanh_Nhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[Nhom] ([id])
GO
ALTER TABLE [dbo].[NhomThuocChiNhanh] CHECK CONSTRAINT [FK_NhomThuocChiNhanh_Nhom]
GO
ALTER TABLE [dbo].[NhomThuocChiNhanh]  WITH CHECK ADD  CONSTRAINT [FK_NhomThuocChiNhanh_NhomThuocChiNhanh1] FOREIGN KEY([id])
REFERENCES [dbo].[NhomThuocChiNhanh] ([id])
GO
ALTER TABLE [dbo].[NhomThuocChiNhanh] CHECK CONSTRAINT [FK_NhomThuocChiNhanh_NhomThuocChiNhanh1]
GO
ALTER TABLE [dbo].[NhomThuocChiNhanh]  WITH CHECK ADD  CONSTRAINT [FK_NhomThuocChiNhanh_PQDONVI$] FOREIGN KEY([MaChiNhanh])
REFERENCES [dbo].[PQDONVI$] ([id])
GO
ALTER TABLE [dbo].[NhomThuocChiNhanh] CHECK CONSTRAINT [FK_NhomThuocChiNhanh_PQDONVI$]
GO
ALTER TABLE [dbo].[QuyenTai_NhomThuocChiNhanh]  WITH CHECK ADD  CONSTRAINT [FK_QuyenTai_NhomThuocChiNhanh_NhomThuocChiNhanh] FOREIGN KEY([id])
REFERENCES [dbo].[NhomThuocChiNhanh] ([id])
GO
ALTER TABLE [dbo].[QuyenTai_NhomThuocChiNhanh] CHECK CONSTRAINT [FK_QuyenTai_NhomThuocChiNhanh_NhomThuocChiNhanh]
GO
ALTER TABLE [dbo].[QuyenXem_NhomThuocChiNhanh]  WITH CHECK ADD  CONSTRAINT [FK_QuyenXem_NhomThuocChiNhanh_NhomThuocChiNhanh] FOREIGN KEY([id])
REFERENCES [dbo].[NhomThuocChiNhanh] ([id])
GO
ALTER TABLE [dbo].[QuyenXem_NhomThuocChiNhanh] CHECK CONSTRAINT [FK_QuyenXem_NhomThuocChiNhanh_NhomThuocChiNhanh]
GO
ALTER TABLE [dbo].[TaiKhoanThuocNhom]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoanThuocNhom_Nhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[Nhom] ([id])
GO
ALTER TABLE [dbo].[TaiKhoanThuocNhom] CHECK CONSTRAINT [FK_TaiKhoanThuocNhom_Nhom]
GO
ALTER TABLE [dbo].[TaiKhoanThuocNhom]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoanThuocNhom_TaiKhoan] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([id])
GO
ALTER TABLE [dbo].[TaiKhoanThuocNhom] CHECK CONSTRAINT [FK_TaiKhoanThuocNhom_TaiKhoan]
GO
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [Ten]) VALUES (N'admin@admin.com', N'$MYHASH$V1$10000$8LVM9e4f6k8ghW5XmAJJfNlxAwQb5IRy6tqhW27NdH2zGis0', N'admin')
GO
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [Ten]) VALUES (N'admin2@admin.com', N'$MYHASH$V1$10000$8LVM9e4f6k8ghW5XmAJJfNlxAwQb5IRy6tqhW27NdH2zGis0', N'admin2')
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
