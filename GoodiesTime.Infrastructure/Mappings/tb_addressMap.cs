using System.Data.Entity.ModelConfiguration;
using GoodiesTime.Domain.Entities;

namespace GoodiesTime.Infrastructure.Mappings
{
    public class tb_addressMap : EntityTypeConfiguration<tb_address>
    {
        public tb_addressMap()
        {
            ToTable("tb_address");
            HasKey(x => x.id_address);
        }
    }
}
