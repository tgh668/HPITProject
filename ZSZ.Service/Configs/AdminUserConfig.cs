using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service;

namespace ZSZ.DAL.ModelConfig
{
    class AdminUserConfig : EntityTypeConfiguration<AdminUserEntity>
    {
        public AdminUserConfig()
        {
            ToTable("T_AdminUsers");

            //配置用户和角色的多对多关系
            HasMany(u => u.Roles).WithMany(r => r.AdminUsers).Map(m=>m.ToTable("T_AdminUserRoles")
                .MapLeftKey("AdminUserId").MapRightKey("RoleId"));
            Property(e => e.Name).HasMaxLength(50).IsRequired();
            Property(e => e.PhoneNum).HasMaxLength(20).IsRequired().IsUnicode(false);//对应数据库中的varchar类型
            Property(e => e.PasswordSalt).HasMaxLength(20).IsRequired().IsUnicode(false);
            Property(e => e.PasswordHash).HasMaxLength(100).IsRequired().IsUnicode(false);
        }
    }
}
