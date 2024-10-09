using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Data{

    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext>options):base(options){}
        
        public DbSet<Bootcamp> Kurslar => Set<Bootcamp>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<BootcampKayit> KursKayitlari => Set<BootcampKayit>();
    }
}