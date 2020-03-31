using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service
{
    public class ZSZContext : DbContext
    {
        private static ILog log = LogManager.GetLogger(typeof(ZSZContext));//声明Log4NET对象，建议一个类就声明一个ILog对象
        public ZSZContext() : base("name=connstr")
        {
            //将EF生成的sql语句记录在日志里面
            this.Database.Log = (sql) =>
            {
                log.DebugFormat("EF开始执行sql语句{0}", sql);
            };

            // Database.SetInitializer<ZSZContext>(null);//只要数据库建造好后，就加上这句话，禁止Ef再去帮你创建数据库的一些操作

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AdminUserEntity> AdminUsers { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<SettingEntity> Settings { get; set; }
        public DbSet<CandidateEntity> Candidates { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<EmployMentsEntity> EmployMents { get; set; }
        public DbSet<IdNameEntity> IdNames { get; set; }
        public DbSet<InterViewerEntity> InterViewer { get; set; }
        public DbSet<PEMEntity> PEMs { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<PRMEntity> PRMs { get; set; }
        public DbSet<ResumeSourceEntity> ResumeSources { get; set; }
        public DbSet<TutorEntity> Tutors { get; set; }

    }
}
