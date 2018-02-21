using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace test.Data.Maps
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder){
            entityBuilder.HasKey(t => t.Id);  
            entityBuilder.Property(t => t.name).IsRequired();  
            entityBuilder.Property(t => t.count).IsRequired();  
            entityBuilder.Property(t => t.ModifiedDate);
        }
    }
}