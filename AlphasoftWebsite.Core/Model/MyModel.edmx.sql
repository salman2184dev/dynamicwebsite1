
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2018 16:42:22
-- Generated from EDMX file: H:\Alphasoft\TestAMS\AlphasoftWebsite\AlphasoftWebsite.Core\Model\MyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AlphasoftWebsiteDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Blog_BlogCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blog] DROP CONSTRAINT [FK_Blog_BlogCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ChatMessages_ChatMessages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatMessages] DROP CONSTRAINT [FK_ChatMessages_ChatMessages];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanySocialAccountDetail_CompanyDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanySocialAccountDetail] DROP CONSTRAINT [FK_CompanySocialAccountDetail_CompanyDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanySocialAccountDetail_SocialAccountType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanySocialAccountDetail] DROP CONSTRAINT [FK_CompanySocialAccountDetail_SocialAccountType];
GO
IF OBJECT_ID(N'[dbo].[FK_ConnectionProperties_ConnectionProperties]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConnectionProperties] DROP CONSTRAINT [FK_ConnectionProperties_ConnectionProperties];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Designation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employee_Designation];
GO
IF OBJECT_ID(N'[dbo].[FK_FactorDetails_IconList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactorDetails] DROP CONSTRAINT [FK_FactorDetails_IconList];
GO
IF OBJECT_ID(N'[dbo].[FK_FeatureDetails_IconList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeatureDetails] DROP CONSTRAINT [FK_FeatureDetails_IconList];
GO
IF OBJECT_ID(N'[AlphasoftWebsiteDBModelStoreContainer].[FK_LoginInfo_User]', 'F') IS NOT NULL
    ALTER TABLE [AlphasoftWebsiteDBModelStoreContainer].[LoginInfo] DROP CONSTRAINT [FK_LoginInfo_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PricingDetail_PricingDetailType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PricingDetail] DROP CONSTRAINT [FK_PricingDetail_PricingDetailType];
GO
IF OBJECT_ID(N'[dbo].[FK_PricingDetail_PricingTableType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PricingDetail] DROP CONSTRAINT [FK_PricingDetail_PricingTableType];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_ProductCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ResetPassword_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResetPassword] DROP CONSTRAINT [FK_ResetPassword_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Service_IconList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Service] DROP CONSTRAINT [FK_Service_IconList];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceProperty_Service]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceProperty] DROP CONSTRAINT [FK_ServiceProperty_Service];
GO
IF OBJECT_ID(N'[dbo].[FK_SmtpHost_HostType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SmtpHost] DROP CONSTRAINT [FK_SmtpHost_HostType];
GO
IF OBJECT_ID(N'[dbo].[FK_SocialAccountType_IconList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SocialAccountType] DROP CONSTRAINT [FK_SocialAccountType_IconList];
GO
IF OBJECT_ID(N'[dbo].[FK_Software_SoftwareCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Software] DROP CONSTRAINT [FK_Software_SoftwareCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Blog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blog];
GO
IF OBJECT_ID(N'[dbo].[BlogCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogCategory];
GO
IF OBJECT_ID(N'[dbo].[ChatMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatMessages];
GO
IF OBJECT_ID(N'[dbo].[ChatUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatUser];
GO
IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[ClientList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientList];
GO
IF OBJECT_ID(N'[dbo].[CompanyDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyDetail];
GO
IF OBJECT_ID(N'[dbo].[CompanySocialAccountDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanySocialAccountDetail];
GO
IF OBJECT_ID(N'[dbo].[ConnectionProperties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConnectionProperties];
GO
IF OBJECT_ID(N'[dbo].[Designations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Designations];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[FactorDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactorDetails];
GO
IF OBJECT_ID(N'[dbo].[FactorHeader]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactorHeader];
GO
IF OBJECT_ID(N'[dbo].[FAQ]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQ];
GO
IF OBJECT_ID(N'[dbo].[FAQHeader]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQHeader];
GO
IF OBJECT_ID(N'[dbo].[FeatureDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeatureDetails];
GO
IF OBJECT_ID(N'[dbo].[FeatureHeader]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeatureHeader];
GO
IF OBJECT_ID(N'[dbo].[HomeBanner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HomeBanner];
GO
IF OBJECT_ID(N'[dbo].[HostType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HostType];
GO
IF OBJECT_ID(N'[dbo].[IconList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IconList];
GO
IF OBJECT_ID(N'[dbo].[NewsletterMail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsletterMail];
GO
IF OBJECT_ID(N'[dbo].[NewsletterSubscribers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsletterSubscribers];
GO
IF OBJECT_ID(N'[dbo].[OnlineUserFeedBackDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OnlineUserFeedBackDetail];
GO
IF OBJECT_ID(N'[dbo].[Pricing]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pricing];
GO
IF OBJECT_ID(N'[dbo].[PricingDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PricingDetail];
GO
IF OBJECT_ID(N'[dbo].[PricingDetailType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PricingDetailType];
GO
IF OBJECT_ID(N'[dbo].[PricingTableType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PricingTableType];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[ResetPassword]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResetPassword];
GO
IF OBJECT_ID(N'[dbo].[SentMailLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SentMailLog];
GO
IF OBJECT_ID(N'[dbo].[Service]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Service];
GO
IF OBJECT_ID(N'[dbo].[ServiceProperty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceProperty];
GO
IF OBJECT_ID(N'[dbo].[SmtpHost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SmtpHost];
GO
IF OBJECT_ID(N'[dbo].[SocialAccountType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SocialAccountType];
GO
IF OBJECT_ID(N'[dbo].[Software]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Software];
GO
IF OBJECT_ID(N'[dbo].[SoftwareCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoftwareCategory];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[AlphasoftWebsiteDBModelStoreContainer].[LoginInfo]', 'U') IS NOT NULL
    DROP TABLE [AlphasoftWebsiteDBModelStoreContainer].[LoginInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [BlogId] int IDENTITY(1,1) NOT NULL,
    [BlogName] nvarchar(50)  NOT NULL,
    [BlogDescription] nvarchar(max)  NULL,
    [BlogCategoryId] int  NOT NULL,
    [BlogImage] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'BlogCategories'
CREATE TABLE [dbo].[BlogCategories] (
    [BlogCategoryId] int IDENTITY(1,1) NOT NULL,
    [BlogCategoryName] nvarchar(50)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'ChatMessages'
CREATE TABLE [dbo].[ChatMessages] (
    [ChatMessageId] int IDENTITY(1,1) NOT NULL,
    [ChatMessageDateTime] datetime  NULL,
    [Message] nvarchar(max)  NULL,
    [UserName] nvarchar(100)  NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'ChatUsers'
CREATE TABLE [dbo].[ChatUsers] (
    [ChatUserId] int IDENTITY(1,1) NOT NULL,
    [ChatUserName] nvarchar(100)  NOT NULL,
    [ConnectionId] nvarchar(100)  NULL,
    [UserImage] nvarchar(100)  NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'CompanyDetails'
CREATE TABLE [dbo].[CompanyDetails] (
    [CompanyId] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(255)  NOT NULL,
    [CompanyEmail] nvarchar(150)  NOT NULL,
    [CompanyFax] nvarchar(150)  NULL,
    [CompanyImage] nvarchar(250)  NULL,
    [CompanyAddress] nvarchar(255)  NOT NULL,
    [GoogleMapLocation] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'CompanySocialAccountDetails'
CREATE TABLE [dbo].[CompanySocialAccountDetails] (
    [CompanySocialAccountDetailId] int IDENTITY(1,1) NOT NULL,
    [CompanyId] int  NOT NULL,
    [URL] nvarchar(max)  NULL,
    [SocialAccountTypeId] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'ConnectionProperties'
CREATE TABLE [dbo].[ConnectionProperties] (
    [UserConnectionId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [ConnectionId] nvarchar(50)  NOT NULL,
    [ConnectionStatus] bit  NOT NULL
);
GO

-- Creating table 'Designations'
CREATE TABLE [dbo].[Designations] (
    [DesignationId] int IDENTITY(1,1) NOT NULL,
    [DesignationName] nvarchar(50)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [EmployeeName] nvarchar(50)  NULL,
    [EmployeeAddress] nvarchar(250)  NULL,
    [EmployeeImage] nvarchar(max)  NULL,
    [DesignationId] int  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'FactorDetails'
CREATE TABLE [dbo].[FactorDetails] (
    [FactorDetailId] int IDENTITY(1,1) NOT NULL,
    [FactorDetailName] nvarchar(50)  NOT NULL,
    [FactorDetailDescription] nvarchar(250)  NOT NULL,
    [IconId] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'FactorHeaders'
CREATE TABLE [dbo].[FactorHeaders] (
    [FactorHeaderId] int IDENTITY(1,1) NOT NULL,
    [FactorHeaderName] varchar(50)  NOT NULL,
    [FactorHeaderBody] varchar(100)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'FAQs'
CREATE TABLE [dbo].[FAQs] (
    [FAQId] int IDENTITY(1,1) NOT NULL,
    [FAQQuestion] nvarchar(max)  NOT NULL,
    [FAQAnswer] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'FeatureDetails'
CREATE TABLE [dbo].[FeatureDetails] (
    [FeatureDetailId] int IDENTITY(1,1) NOT NULL,
    [FeatureDetailTitle] nvarchar(50)  NOT NULL,
    [FeatureDetailDescription] nvarchar(250)  NULL,
    [IconId] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'FeatureHeaders'
CREATE TABLE [dbo].[FeatureHeaders] (
    [FeatureHeaderId] int IDENTITY(1,1) NOT NULL,
    [FeatureHeaderTitle] nvarchar(50)  NOT NULL,
    [FeatureHeaderBody] nvarchar(250)  NOT NULL,
    [FeatureHeaderImage] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'HomeBanners'
CREATE TABLE [dbo].[HomeBanners] (
    [HomeBannerId] int IDENTITY(1,1) NOT NULL,
    [HomeBannerHeader] nvarchar(50)  NOT NULL,
    [HomeBannerDescription] nvarchar(250)  NOT NULL,
    [HomeBannerImage] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [SerialNo] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'IconLists'
CREATE TABLE [dbo].[IconLists] (
    [IconId] int IDENTITY(1,1) NOT NULL,
    [IconFor] nvarchar(150)  NULL,
    [IconName] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] int  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] int  NULL
);
GO

-- Creating table 'NewsletterMails'
CREATE TABLE [dbo].[NewsletterMails] (
    [NewsletterMailId] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(50)  NOT NULL,
    [Body] nvarchar(4000)  NOT NULL,
    [AttachFile] nvarchar(500)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(50)  NOT NULL,
    [ProductDetails] nvarchar(max)  NULL,
    [ProductImage] nvarchar(max)  NOT NULL,
    [ProductCategoryId] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'ProductCategories'
CREATE TABLE [dbo].[ProductCategories] (
    [ProductCategoryId] int IDENTITY(1,1) NOT NULL,
    [ProductCategoryName] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'ResetPasswords'
CREATE TABLE [dbo].[ResetPasswords] (
    [ResetPasswordId] int IDENTITY(1,1) NOT NULL,
    [NewPassword] nvarchar(max)  NOT NULL,
    [ResetCode] nvarchar(max)  NOT NULL,
    [ResetTime] datetime  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [ServiceId] int IDENTITY(1,1) NOT NULL,
    [ServiceName] nvarchar(50)  NOT NULL,
    [ServiceHeader] nvarchar(50)  NOT NULL,
    [ServiceDescription] nvarchar(250)  NOT NULL,
    [IconId] int  NOT NULL,
    [ServiceImage] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'ServiceProperties'
CREATE TABLE [dbo].[ServiceProperties] (
    [ServicePropertyId] int IDENTITY(1,1) NOT NULL,
    [ServicePropertyName] nvarchar(20)  NOT NULL,
    [ServiceId] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'SocialAccountTypes'
CREATE TABLE [dbo].[SocialAccountTypes] (
    [SocialAccountTypeId] int IDENTITY(1,1) NOT NULL,
    [SocialAccountName] nvarchar(150)  NOT NULL,
    [IconId] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL
);
GO

-- Creating table 'Softwares'
CREATE TABLE [dbo].[Softwares] (
    [SoftwareId] int IDENTITY(1,1) NOT NULL,
    [SoftwareName] nvarchar(50)  NOT NULL,
    [SoftwareDetails] nvarchar(max)  NOT NULL,
    [SoftwareImage] nvarchar(max)  NULL,
    [SoftwareCategoryId] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'SoftwareCategories'
CREATE TABLE [dbo].[SoftwareCategories] (
    [SoftwareCategoryId] int IDENTITY(1,1) NOT NULL,
    [SoftwareCategoryName] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [IsEmailVerified] bit  NOT NULL,
    [RoleId] int  NOT NULL,
    [ActivationCode] nvarchar(max)  NULL,
    [ResetPasswordCode] nvarchar(max)  NULL,
    [RegistrationDate] datetime  NOT NULL
);
GO

-- Creating table 'LoginInfoes'
CREATE TABLE [dbo].[LoginInfoes] (
    [LogInIfoId] int  NOT NULL,
    [LogInTime] datetime  NOT NULL,
    [LoginIp] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'FAQHeaders'
CREATE TABLE [dbo].[FAQHeaders] (
    [FAQHeaderId] int IDENTITY(1,1) NOT NULL,
    [FAQHeaderName] varchar(50)  NOT NULL,
    [FAQHeaderBody] varchar(100)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'SentMailLogs'
CREATE TABLE [dbo].[SentMailLogs] (
    [SentMailLogId] int IDENTITY(1,1) NOT NULL,
    [NewsletterSubscriberEmailId] nvarchar(250)  NOT NULL,
    [NewsletterMailSubject] nvarchar(max)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [IsSent] bit  NOT NULL
);
GO

-- Creating table 'NewsletterSubscribers'
CREATE TABLE [dbo].[NewsletterSubscribers] (
    [NewsletterSubscriberId] int IDENTITY(1,1) NOT NULL,
    [NewsletterSubscriberEmail] nvarchar(50)  NOT NULL,
    [MachineIP] nvarchar(50)  NULL,
    [SubscriptionDate] datetime  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Pricings'
CREATE TABLE [dbo].[Pricings] (
    [PricingID] int IDENTITY(1,1) NOT NULL,
    [PricingHeader] nvarchar(50)  NOT NULL,
    [PricingBody] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'PricingDetails'
CREATE TABLE [dbo].[PricingDetails] (
    [PricingDetailID] int IDENTITY(1,1) NOT NULL,
    [PricingTableTypeID] int  NOT NULL,
    [PricingDetailTypeID] int  NOT NULL,
    [PricingDetailQuantity] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL
);
GO

-- Creating table 'PricingDetailTypes'
CREATE TABLE [dbo].[PricingDetailTypes] (
    [PricingDetailTypeID] int IDENTITY(1,1) NOT NULL,
    [PricingDetailTypeName] nvarchar(250)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL
);
GO

-- Creating table 'PricingTableTypes'
CREATE TABLE [dbo].[PricingTableTypes] (
    [PricingTableTypeID] int IDENTITY(1,1) NOT NULL,
    [PricingTableTypeName] nvarchar(250)  NOT NULL,
    [PricePerMonth] decimal(18,2)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL
);
GO

-- Creating table 'SmtpHosts'
CREATE TABLE [dbo].[SmtpHosts] (
    [SmtpHostId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(250)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [IsActiveUserName] bit  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL,
    [HostTypeId] int  NOT NULL
);
GO

-- Creating table 'HostTypes'
CREATE TABLE [dbo].[HostTypes] (
    [HostTypeId] int IDENTITY(1,1) NOT NULL,
    [HostTypeName] nvarchar(50)  NOT NULL,
    [HostName] nvarchar(50)  NOT NULL,
    [PortNumber] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [EnableSsl] bit  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ClientID] int IDENTITY(1,1) NOT NULL,
    [ClientHeader] nvarchar(50)  NOT NULL,
    [ClientBody] nvarchar(max)  NULL,
    [ClientBackgroundImage] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'ClientLists'
CREATE TABLE [dbo].[ClientLists] (
    [ClientID] int IDENTITY(1,1) NOT NULL,
    [ClientName] nvarchar(150)  NOT NULL,
    [ClientReview] nvarchar(max)  NOT NULL,
    [ClientImage] nvarchar(150)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL
);
GO

-- Creating table 'OnlineUserFeedBackDetails'
CREATE TABLE [dbo].[OnlineUserFeedBackDetails] (
    [UserFeedBackId] int IDENTITY(1,1) NOT NULL,
    [UserFullName] nvarchar(150)  NOT NULL,
    [UserEmail] nvarchar(50)  NOT NULL,
    [UserMessageSubject] nvarchar(250)  NOT NULL,
    [UserMessage] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [MachineIP] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BlogId] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([BlogId] ASC);
GO

-- Creating primary key on [BlogCategoryId] in table 'BlogCategories'
ALTER TABLE [dbo].[BlogCategories]
ADD CONSTRAINT [PK_BlogCategories]
    PRIMARY KEY CLUSTERED ([BlogCategoryId] ASC);
GO

-- Creating primary key on [ChatMessageId] in table 'ChatMessages'
ALTER TABLE [dbo].[ChatMessages]
ADD CONSTRAINT [PK_ChatMessages]
    PRIMARY KEY CLUSTERED ([ChatMessageId] ASC);
GO

-- Creating primary key on [ChatUserId] in table 'ChatUsers'
ALTER TABLE [dbo].[ChatUsers]
ADD CONSTRAINT [PK_ChatUsers]
    PRIMARY KEY CLUSTERED ([ChatUserId] ASC);
GO

-- Creating primary key on [CompanyId] in table 'CompanyDetails'
ALTER TABLE [dbo].[CompanyDetails]
ADD CONSTRAINT [PK_CompanyDetails]
    PRIMARY KEY CLUSTERED ([CompanyId] ASC);
GO

-- Creating primary key on [CompanySocialAccountDetailId] in table 'CompanySocialAccountDetails'
ALTER TABLE [dbo].[CompanySocialAccountDetails]
ADD CONSTRAINT [PK_CompanySocialAccountDetails]
    PRIMARY KEY CLUSTERED ([CompanySocialAccountDetailId] ASC);
GO

-- Creating primary key on [UserConnectionId] in table 'ConnectionProperties'
ALTER TABLE [dbo].[ConnectionProperties]
ADD CONSTRAINT [PK_ConnectionProperties]
    PRIMARY KEY CLUSTERED ([UserConnectionId] ASC);
GO

-- Creating primary key on [DesignationId] in table 'Designations'
ALTER TABLE [dbo].[Designations]
ADD CONSTRAINT [PK_Designations]
    PRIMARY KEY CLUSTERED ([DesignationId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [FactorDetailId] in table 'FactorDetails'
ALTER TABLE [dbo].[FactorDetails]
ADD CONSTRAINT [PK_FactorDetails]
    PRIMARY KEY CLUSTERED ([FactorDetailId] ASC);
GO

-- Creating primary key on [FactorHeaderId] in table 'FactorHeaders'
ALTER TABLE [dbo].[FactorHeaders]
ADD CONSTRAINT [PK_FactorHeaders]
    PRIMARY KEY CLUSTERED ([FactorHeaderId] ASC);
GO

-- Creating primary key on [FAQId] in table 'FAQs'
ALTER TABLE [dbo].[FAQs]
ADD CONSTRAINT [PK_FAQs]
    PRIMARY KEY CLUSTERED ([FAQId] ASC);
GO

-- Creating primary key on [FeatureDetailId] in table 'FeatureDetails'
ALTER TABLE [dbo].[FeatureDetails]
ADD CONSTRAINT [PK_FeatureDetails]
    PRIMARY KEY CLUSTERED ([FeatureDetailId] ASC);
GO

-- Creating primary key on [FeatureHeaderId] in table 'FeatureHeaders'
ALTER TABLE [dbo].[FeatureHeaders]
ADD CONSTRAINT [PK_FeatureHeaders]
    PRIMARY KEY CLUSTERED ([FeatureHeaderId] ASC);
GO

-- Creating primary key on [HomeBannerId] in table 'HomeBanners'
ALTER TABLE [dbo].[HomeBanners]
ADD CONSTRAINT [PK_HomeBanners]
    PRIMARY KEY CLUSTERED ([HomeBannerId] ASC);
GO

-- Creating primary key on [IconId] in table 'IconLists'
ALTER TABLE [dbo].[IconLists]
ADD CONSTRAINT [PK_IconLists]
    PRIMARY KEY CLUSTERED ([IconId] ASC);
GO

-- Creating primary key on [NewsletterMailId] in table 'NewsletterMails'
ALTER TABLE [dbo].[NewsletterMails]
ADD CONSTRAINT [PK_NewsletterMails]
    PRIMARY KEY CLUSTERED ([NewsletterMailId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [ProductCategoryId] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [PK_ProductCategories]
    PRIMARY KEY CLUSTERED ([ProductCategoryId] ASC);
GO

-- Creating primary key on [ResetPasswordId] in table 'ResetPasswords'
ALTER TABLE [dbo].[ResetPasswords]
ADD CONSTRAINT [PK_ResetPasswords]
    PRIMARY KEY CLUSTERED ([ResetPasswordId] ASC);
GO

-- Creating primary key on [ServiceId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([ServiceId] ASC);
GO

-- Creating primary key on [ServicePropertyId] in table 'ServiceProperties'
ALTER TABLE [dbo].[ServiceProperties]
ADD CONSTRAINT [PK_ServiceProperties]
    PRIMARY KEY CLUSTERED ([ServicePropertyId] ASC);
GO

-- Creating primary key on [SocialAccountTypeId] in table 'SocialAccountTypes'
ALTER TABLE [dbo].[SocialAccountTypes]
ADD CONSTRAINT [PK_SocialAccountTypes]
    PRIMARY KEY CLUSTERED ([SocialAccountTypeId] ASC);
GO

-- Creating primary key on [SoftwareId] in table 'Softwares'
ALTER TABLE [dbo].[Softwares]
ADD CONSTRAINT [PK_Softwares]
    PRIMARY KEY CLUSTERED ([SoftwareId] ASC);
GO

-- Creating primary key on [SoftwareCategoryId] in table 'SoftwareCategories'
ALTER TABLE [dbo].[SoftwareCategories]
ADD CONSTRAINT [PK_SoftwareCategories]
    PRIMARY KEY CLUSTERED ([SoftwareCategoryId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [LogInIfoId], [LogInTime], [LoginIp], [UserId] in table 'LoginInfoes'
ALTER TABLE [dbo].[LoginInfoes]
ADD CONSTRAINT [PK_LoginInfoes]
    PRIMARY KEY CLUSTERED ([LogInIfoId], [LogInTime], [LoginIp], [UserId] ASC);
GO

-- Creating primary key on [FAQHeaderId] in table 'FAQHeaders'
ALTER TABLE [dbo].[FAQHeaders]
ADD CONSTRAINT [PK_FAQHeaders]
    PRIMARY KEY CLUSTERED ([FAQHeaderId] ASC);
GO

-- Creating primary key on [SentMailLogId] in table 'SentMailLogs'
ALTER TABLE [dbo].[SentMailLogs]
ADD CONSTRAINT [PK_SentMailLogs]
    PRIMARY KEY CLUSTERED ([SentMailLogId] ASC);
GO

-- Creating primary key on [NewsletterSubscriberId] in table 'NewsletterSubscribers'
ALTER TABLE [dbo].[NewsletterSubscribers]
ADD CONSTRAINT [PK_NewsletterSubscribers]
    PRIMARY KEY CLUSTERED ([NewsletterSubscriberId] ASC);
GO

-- Creating primary key on [PricingID] in table 'Pricings'
ALTER TABLE [dbo].[Pricings]
ADD CONSTRAINT [PK_Pricings]
    PRIMARY KEY CLUSTERED ([PricingID] ASC);
GO

-- Creating primary key on [PricingDetailID] in table 'PricingDetails'
ALTER TABLE [dbo].[PricingDetails]
ADD CONSTRAINT [PK_PricingDetails]
    PRIMARY KEY CLUSTERED ([PricingDetailID] ASC);
GO

-- Creating primary key on [PricingDetailTypeID] in table 'PricingDetailTypes'
ALTER TABLE [dbo].[PricingDetailTypes]
ADD CONSTRAINT [PK_PricingDetailTypes]
    PRIMARY KEY CLUSTERED ([PricingDetailTypeID] ASC);
GO

-- Creating primary key on [PricingTableTypeID] in table 'PricingTableTypes'
ALTER TABLE [dbo].[PricingTableTypes]
ADD CONSTRAINT [PK_PricingTableTypes]
    PRIMARY KEY CLUSTERED ([PricingTableTypeID] ASC);
GO

-- Creating primary key on [SmtpHostId] in table 'SmtpHosts'
ALTER TABLE [dbo].[SmtpHosts]
ADD CONSTRAINT [PK_SmtpHosts]
    PRIMARY KEY CLUSTERED ([SmtpHostId] ASC);
GO

-- Creating primary key on [HostTypeId] in table 'HostTypes'
ALTER TABLE [dbo].[HostTypes]
ADD CONSTRAINT [PK_HostTypes]
    PRIMARY KEY CLUSTERED ([HostTypeId] ASC);
GO

-- Creating primary key on [ClientID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [ClientID] in table 'ClientLists'
ALTER TABLE [dbo].[ClientLists]
ADD CONSTRAINT [PK_ClientLists]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [UserFeedBackId] in table 'OnlineUserFeedBackDetails'
ALTER TABLE [dbo].[OnlineUserFeedBackDetails]
ADD CONSTRAINT [PK_OnlineUserFeedBackDetails]
    PRIMARY KEY CLUSTERED ([UserFeedBackId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BlogCategoryId] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [FK_Blog_BlogCategory]
    FOREIGN KEY ([BlogCategoryId])
    REFERENCES [dbo].[BlogCategories]
        ([BlogCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Blog_BlogCategory'
CREATE INDEX [IX_FK_Blog_BlogCategory]
ON [dbo].[Blogs]
    ([BlogCategoryId]);
GO

-- Creating foreign key on [UserId] in table 'ChatMessages'
ALTER TABLE [dbo].[ChatMessages]
ADD CONSTRAINT [FK_ChatMessages_ChatMessages]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatMessages_ChatMessages'
CREATE INDEX [IX_FK_ChatMessages_ChatMessages]
ON [dbo].[ChatMessages]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'ConnectionProperties'
ALTER TABLE [dbo].[ConnectionProperties]
ADD CONSTRAINT [FK_ConnectionProperties_ConnectionProperties]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[ChatUsers]
        ([ChatUserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConnectionProperties_ConnectionProperties'
CREATE INDEX [IX_FK_ConnectionProperties_ConnectionProperties]
ON [dbo].[ConnectionProperties]
    ([UserId]);
GO

-- Creating foreign key on [CompanyId] in table 'CompanySocialAccountDetails'
ALTER TABLE [dbo].[CompanySocialAccountDetails]
ADD CONSTRAINT [FK_CompanySocialAccountDetail_CompanyDetail]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[CompanyDetails]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanySocialAccountDetail_CompanyDetail'
CREATE INDEX [IX_FK_CompanySocialAccountDetail_CompanyDetail]
ON [dbo].[CompanySocialAccountDetails]
    ([CompanyId]);
GO

-- Creating foreign key on [SocialAccountTypeId] in table 'CompanySocialAccountDetails'
ALTER TABLE [dbo].[CompanySocialAccountDetails]
ADD CONSTRAINT [FK_CompanySocialAccountDetail_SocialAccountType]
    FOREIGN KEY ([SocialAccountTypeId])
    REFERENCES [dbo].[SocialAccountTypes]
        ([SocialAccountTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanySocialAccountDetail_SocialAccountType'
CREATE INDEX [IX_FK_CompanySocialAccountDetail_SocialAccountType]
ON [dbo].[CompanySocialAccountDetails]
    ([SocialAccountTypeId]);
GO

-- Creating foreign key on [DesignationId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Designation]
    FOREIGN KEY ([DesignationId])
    REFERENCES [dbo].[Designations]
        ([DesignationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Designation'
CREATE INDEX [IX_FK_Employee_Designation]
ON [dbo].[Employees]
    ([DesignationId]);
GO

-- Creating foreign key on [IconId] in table 'FactorDetails'
ALTER TABLE [dbo].[FactorDetails]
ADD CONSTRAINT [FK_FactorDetails_IconList]
    FOREIGN KEY ([IconId])
    REFERENCES [dbo].[IconLists]
        ([IconId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FactorDetails_IconList'
CREATE INDEX [IX_FK_FactorDetails_IconList]
ON [dbo].[FactorDetails]
    ([IconId]);
GO

-- Creating foreign key on [IconId] in table 'FeatureDetails'
ALTER TABLE [dbo].[FeatureDetails]
ADD CONSTRAINT [FK_FeatureDetails_IconList]
    FOREIGN KEY ([IconId])
    REFERENCES [dbo].[IconLists]
        ([IconId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FeatureDetails_IconList'
CREATE INDEX [IX_FK_FeatureDetails_IconList]
ON [dbo].[FeatureDetails]
    ([IconId]);
GO

-- Creating foreign key on [IconId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_Service_IconList]
    FOREIGN KEY ([IconId])
    REFERENCES [dbo].[IconLists]
        ([IconId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Service_IconList'
CREATE INDEX [IX_FK_Service_IconList]
ON [dbo].[Services]
    ([IconId]);
GO

-- Creating foreign key on [IconId] in table 'SocialAccountTypes'
ALTER TABLE [dbo].[SocialAccountTypes]
ADD CONSTRAINT [FK_SocialAccountType_IconList]
    FOREIGN KEY ([IconId])
    REFERENCES [dbo].[IconLists]
        ([IconId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SocialAccountType_IconList'
CREATE INDEX [IX_FK_SocialAccountType_IconList]
ON [dbo].[SocialAccountTypes]
    ([IconId]);
GO

-- Creating foreign key on [ProductCategoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_ProductCategory]
    FOREIGN KEY ([ProductCategoryId])
    REFERENCES [dbo].[ProductCategories]
        ([ProductCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_ProductCategory'
CREATE INDEX [IX_FK_Product_ProductCategory]
ON [dbo].[Products]
    ([ProductCategoryId]);
GO

-- Creating foreign key on [UserId] in table 'ResetPasswords'
ALTER TABLE [dbo].[ResetPasswords]
ADD CONSTRAINT [FK_ResetPassword_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResetPassword_User'
CREATE INDEX [IX_FK_ResetPassword_User]
ON [dbo].[ResetPasswords]
    ([UserId]);
GO

-- Creating foreign key on [ServiceId] in table 'ServiceProperties'
ALTER TABLE [dbo].[ServiceProperties]
ADD CONSTRAINT [FK_ServiceProperty_Service]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([ServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceProperty_Service'
CREATE INDEX [IX_FK_ServiceProperty_Service]
ON [dbo].[ServiceProperties]
    ([ServiceId]);
GO

-- Creating foreign key on [SoftwareCategoryId] in table 'Softwares'
ALTER TABLE [dbo].[Softwares]
ADD CONSTRAINT [FK_Software_SoftwareCategory]
    FOREIGN KEY ([SoftwareCategoryId])
    REFERENCES [dbo].[SoftwareCategories]
        ([SoftwareCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Software_SoftwareCategory'
CREATE INDEX [IX_FK_Software_SoftwareCategory]
ON [dbo].[Softwares]
    ([SoftwareCategoryId]);
GO

-- Creating foreign key on [LogInIfoId] in table 'LoginInfoes'
ALTER TABLE [dbo].[LoginInfoes]
ADD CONSTRAINT [FK_LoginInfo_User]
    FOREIGN KEY ([LogInIfoId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PricingDetailTypeID] in table 'PricingDetails'
ALTER TABLE [dbo].[PricingDetails]
ADD CONSTRAINT [FK_PricingDetail_PricingDetailType]
    FOREIGN KEY ([PricingDetailTypeID])
    REFERENCES [dbo].[PricingDetailTypes]
        ([PricingDetailTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PricingDetail_PricingDetailType'
CREATE INDEX [IX_FK_PricingDetail_PricingDetailType]
ON [dbo].[PricingDetails]
    ([PricingDetailTypeID]);
GO

-- Creating foreign key on [PricingTableTypeID] in table 'PricingDetails'
ALTER TABLE [dbo].[PricingDetails]
ADD CONSTRAINT [FK_PricingDetail_PricingTableType]
    FOREIGN KEY ([PricingTableTypeID])
    REFERENCES [dbo].[PricingTableTypes]
        ([PricingTableTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PricingDetail_PricingTableType'
CREATE INDEX [IX_FK_PricingDetail_PricingTableType]
ON [dbo].[PricingDetails]
    ([PricingTableTypeID]);
GO

-- Creating foreign key on [HostTypeId] in table 'SmtpHosts'
ALTER TABLE [dbo].[SmtpHosts]
ADD CONSTRAINT [FK_SmtpHost_HostType]
    FOREIGN KEY ([HostTypeId])
    REFERENCES [dbo].[HostTypes]
        ([HostTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SmtpHost_HostType'
CREATE INDEX [IX_FK_SmtpHost_HostType]
ON [dbo].[SmtpHosts]
    ([HostTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------