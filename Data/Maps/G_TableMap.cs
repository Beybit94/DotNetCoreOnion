using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace test.Data.Maps
{
    public class G_TableMap
    {
        public G_TableMap(EntityTypeBuilder<G_Table> entityBuilder){
            entityBuilder.HasKey(t => t.Id);  
            entityBuilder.Property(t => t.name).IsRequired();  
            entityBuilder.Property(t => t.code).IsRequired(); 
            entityBuilder.Property(t => t.ModifiedDate);
        }
    }
}