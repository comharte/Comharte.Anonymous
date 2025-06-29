CREATE VIEW [dbo].[OrganizationMemberView]
AS
	SELECT
		 om.OrganizationId
		,om.MemberRef
		,om.MemberTypeGlobalId
	FROM dbo.OrganizationMember om
GO