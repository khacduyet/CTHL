using Microsoft.EntityFrameworkCore;
using QuanLyChiPhi.Entities;
using QuanLyChiPhi.Common;

namespace QuanLyChiPhi.Entities
{
    public abstract class Entity
    {
        public virtual void OnBeforeInsert() { }
        public virtual void OnBeforeUpdate() { }
    }

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        ~ApplicationContext()
        {
            Dispose();
        }
        public CurrentUser currentUser { get; set; }


        public override int SaveChanges()
        {
            var changedEntities = this.ChangeTracker.Entries();
            foreach (var entry in changedEntities)
            {
                if (entry.Entity is Entity)
                {
                    var entity = (Entity)entry.Entity;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.OnBeforeInsert();
                            break;

                        case EntityState.Modified:
                            entity.OnBeforeUpdate();
                            break;
                    }
                }

                if (entry.State == EntityState.Added)
                {
                    //List<string> listColumn = entry.CurrentValues.PropertyNames.ToList();
                    //if (listColumn.Contains("Created"))
                    {
                        entry.Property("Created").CurrentValue = DateTime.Now;
                    }
                    //if (listColumn.Contains("CreatedBy"))
                    {
                        entry.Property("CreatedBy").CurrentValue = currentUser.Id;
                    }
                    {
                        entry.Property("CreatedByName").CurrentValue = currentUser.TenNhanVien;
                    }
                    //if (listColumn.Contains("Modified"))
                    {
                        entry.Property("Modified").CurrentValue = DateTime.Now;
                    }
                    //if (listColumn.Contains("ModifiedBy"))
                    {
                        entry.Property("ModifiedBy").CurrentValue = currentUser.Id;
                    }
                    {
                        entry.Property("ModifiedByName").CurrentValue = currentUser.TenNhanVien;
                    }


                }
                else if (entry.State == EntityState.Modified)
                {
                    //List<string> listColumn = entry.CurrentValues.PropertyNames.ToList();
                    //if (listColumn.Contains("Created"))
                    {
                        DateTime OriginalValue = entry.GetDatabaseValues().GetValue<DateTime>("Created");
                        if (OriginalValue == DateTime.MinValue || OriginalValue == DateTime.Parse("1900-01-01 00:00:00.000"))
                            entry.Property("Created").CurrentValue = DateTime.Now;
                        else
                            entry.Property("Created").CurrentValue = OriginalValue;
                    }
                    //if (listColumn.Contains("CreatedBy"))
                    {
                        string OriginalValue = entry.GetDatabaseValues().GetValue<string>("CreatedBy");
                        if (string.IsNullOrEmpty(OriginalValue))
                        {
                            entry.Property("CreatedBy").CurrentValue = currentUser.Id;
                        }
                        else
                        {
                            entry.Property("CreatedBy").CurrentValue = OriginalValue;
                        }
                    }
                    {
                        string OriginalValue = entry.GetDatabaseValues().GetValue<string>("CreatedByName");
                        if (string.IsNullOrEmpty(OriginalValue))
                        {
                            entry.Property("CreatedByName").CurrentValue = currentUser.TenNhanVien;
                        }
                        else
                        {
                            entry.Property("CreatedByName").CurrentValue = OriginalValue;
                        }
                    }

                    {
                        entry.Property("Modified").CurrentValue = DateTime.Now;
                    }
                    //if (listColumn.Contains("ModifiedBy"))
                    {
                        entry.Property("ModifiedBy").CurrentValue = currentUser.Id;
                    }
                    {
                        entry.Property("ModifiedByName").CurrentValue = currentUser.TenNhanVien;
                    }
                }
                //if(entry.CurrentValues != null)
                //{

                //}
            }
            return base.SaveChanges();
        }

        #region QuanLyChiPhi
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<PSM_FileDinhKem> PSM_FileDinhKem { get; set; }
        public virtual DbSet<ChungCu> ChungCu { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVu { get; set; }
        public virtual DbSet<LoaiXe> LoaiXe { get; set; }
        public virtual DbSet<PhuongTien> PhuongTien { get; set; }
        public virtual DbSet<LoaiDongPhi> LoaiDongPhi { get; set; }
        public virtual DbSet<CanHo> CanHo { get; set; }
        public virtual DbSet<CanHo_PhuongTien> CanHo_PhuongTien { get; set; }
        public virtual DbSet<XeNgoai> XeNgoai { get; set; }
        public virtual DbSet<QuanLyPhi> QuanLyPhi { get; set; }
        #endregion
    }

}
