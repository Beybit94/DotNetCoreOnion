using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace test.Data.Maps
{
    public class PrivilegeMap
    {
       public PrivilegeMap(EntityTypeBuilder<Privilege> entityBuilder){
            entityBuilder.HasKey(t => t.Id);  
            entityBuilder.Property(t => t.isView).IsRequired();  
            entityBuilder.Property(t => t.isUpdate).IsRequired(); 
            entityBuilder.Property(t => t.isInsert).IsRequired();  
            entityBuilder.Property(t => t.isDelete).IsRequired();
            entityBuilder.Property(t => t.ModifiedDate);
       } 
    }
}