select * from T_AdminUsers

select * from T_AdminUserRoles

select * from T_Roles


SELECT 
    [Extent2].[Id] AS [Id], 
    [Extent2].[Name] AS [Name], 
    [Extent2].[CreateDateTime] AS [CreateDateTime], 
    [Extent2].[IsDeleted] AS [IsDeleted]
    FROM  [dbo].[T_AdminUserRoles] AS [Extent1]
    INNER JOIN [dbo].[T_Roles] AS [Extent2] ON [Extent1].[RoleId] = [Extent2].[Id]
    WHERE [Extent1].[AdminUserId] = 10


	--insert into T_AdminUsers values('333',17867567653,12,12,GETDATE(),0)

    --delete  from T_AdminUsers where name='333'