namespace test.Data
{
    public class Privilege:BaseEntity
    {
        public bool isView{get;set;}
        public bool isUpdate{get;set;}
        public bool isInsert{get;set;}
        public bool isDelete{get;set;}

        public virtual User user {get;set;}
        public virtual G_Table table {get;set;}

    }
}