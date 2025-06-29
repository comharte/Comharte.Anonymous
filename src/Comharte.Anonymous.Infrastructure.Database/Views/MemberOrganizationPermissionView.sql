CREATE VIEW [dbo].[MemberOrganizationPermissionView]
AS
	
	SELECT
		 om.MemberRef
		,om.MemberTypeGlobalId
		,o.GlobalId AS OrganizationGlobalId
	FROM dbo.Organization o
		INNER JOIN dbo.OrganizationMember om ON o.Id = om.OrganizationId