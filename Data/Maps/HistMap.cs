using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace test.Data.Maps
{
    public class HistMap
    {
        public HistMap(EntityTypeBuilder<Hist> entityBuilder){
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ModifiedDate);
        }
    }
}