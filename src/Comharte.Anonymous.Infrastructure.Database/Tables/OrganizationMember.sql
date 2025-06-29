CREATE TABLE [dbo].[OrganizationMember]
(
	 [OrganizationId] INT NOT NULL
	,[MemberRef] UNIQUEIDENTIFIER NOT NULL
	,[MemberTypeGlobalId] UNIQUEIDENTIFIER NOT NULL
)