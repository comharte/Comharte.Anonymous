CREATE VIEW [dbo].[OrganizationView]
AS

	SELECT
		 o.Id
		,o.GlobalId
		,o.DisplayName
		,o.IsDeleted
		,o.CreationUserRef
		,o.CreationDate
	FROM dbo.Organization o

GO