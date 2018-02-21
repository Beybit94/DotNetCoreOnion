using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace test.Data.Maps
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder){
            entityBuilder.HasKey(t => t.Id);  
            entityBuilder.Property(t => t.name).IsRequired();  
            entityBuilder.Property(t => t.login).IsRequired();  
            entityBuilder.Property(t => t.pass).IsRequired();   
            entityBuilder.Property(t => t.ModifiedDate);
        }
    }
}