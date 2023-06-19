using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tender.DataAccess.Models;
using TenderProject.Models;

using TenderModel = Tender.DataAccess.Models.Tender;

namespace TenderProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //modelBuilder.Entity<EmployeeRole>().HasKey(e => new { e.RoleId, e.EmployeeId });
          modelBuilder.Entity<TenderAttachment>().HasKey(t => new { t.TenderId, t.AttachmentTypeId });

         modelBuilder.Entity<SupplierTenderFavourite>().HasKey(s => new { s.TenderId, s.SupplierId });
            modelBuilder.Entity<InvitedSupplier>().HasKey(s => new { s.TenderId, s.SupplierId });

   

            modelBuilder.Entity<OpeningEnvelopeCommittee>().HasData(

                new OpeningEnvelopeCommittee { Id = 1, Name_Ar = "لجنه فتح المظارييف الحكومية", Name_En = "public committe", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

                new OpeningEnvelopeCommittee { Id = 2, Name_Ar = "لجنه فتح المظارييف الخاصة", Name_En = "private committe", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

                new OpeningEnvelopeCommittee { Id = 3, Name_Ar = "لجنه فتح المظارييف للوزارة الكهربا", Name_En = "electical committe", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") }
                );



            modelBuilder.Entity<TechnicalSide>().HasData(

    new TechnicalSide { Id = 1, Name_Ar = "الجهه الفنية التابعه لوزارة الاتصالات", Name_En = "communication technical side", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

    new TechnicalSide { Id = 2, Name_Ar = "الجهه الفنية التابعه لوزارة الكهربا", Name_En = "electrical technical side", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

    new TechnicalSide { Id = 3, Name_Ar = "الجهه الفنية التابعه لوزارة الطاقه", Name_En = "power technical side", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") }
    );


            modelBuilder.Entity<OffersExaminationCommitte>().HasData(

    new OffersExaminationCommitte { Id = 1, Name_Ar = "لجنه فحص العرووض الحكومية", Name_En = "public offer committe", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

    new OffersExaminationCommitte { Id = 2, Name_Ar = "لجنه فحص العرووض الخاصة", Name_En = "private offer committe", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

    new OffersExaminationCommitte { Id = 3, Name_Ar = "لجنه فحص العرووض للوزارة الكهربا", Name_En = "electical offer committe", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") }
    );


            modelBuilder.Entity<AttachmentType>().HasData(

 new AttachmentType { Id=1, Name_Ar = "كراسة الشروط ", Name_En = "refrence condition pdf", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

 new AttachmentType { Id = 2, Name_Ar = "كراسة التاميين الابتدائى", Name_En = "intial insurance pdf", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") },

 new AttachmentType { Id = 3, Name_Ar = "صور تابعه للمناقصة", Name_En = "tender pics", CreatedAt = DateTime.Parse("1-1-2023"), UpdatedAt = DateTime.Parse("1-1-2023") }
 );
        }

         public  DbSet<Employee> Employees { get; set; }
          public DbSet <Role> Roles { get; set; }
         public DbSet<Activity> Activities { get; set; }
         public DbSet<Supplier> Suppliers { get; set; } 
        
        public DbSet<Government> Governments { get; set; }
        public DbSet<City> Cities { get; set; }

    
        public DbSet<SupplierDelegate> SupplierDelegates { get; set; }
        public DbSet<SupplierBranch> SupplierBranches{ get; set; }

        public DbSet<Permission> Permissions { get; set; }  

        public DbSet<TechnicalSide> TechnicalSides { get; set; }

        public DbSet<OpeningEnvelopeCommittee> OpeningEnvelopeCommittees{ get; set; }
        public DbSet<OffersExaminationCommitte> OffersExaminationCommittes{ get; set; }
        public DbSet<AttachmentType>AttachmentTypes  { get; set; }

        public DbSet<TenderModel> Tenders { get; set; }

       public DbSet<TenderAttachment> TenderAttachments { get; set; }

      public DbSet<Offer>Offers { get; set; }

       public DbSet<SupplierTenderFavourite> SupplierTenderFavourites { get; set; }

      public DbSet<InvitedSupplier>InvitedSuppliers { get;set; }


        public DbSet<PaymentType>PaymentTypes { get; set; }

     public DbSet<TenderPayment> TenderPayments{ get; set; }
      public DbSet<SupplierPayment>SupplierPayments { get; set; }
    }
}
