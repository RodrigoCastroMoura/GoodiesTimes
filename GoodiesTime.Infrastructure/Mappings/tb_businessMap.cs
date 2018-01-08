using System.Data.Entity.ModelConfiguration;
using GoodiesTime.Domain.Entities;

namespace GoodiesTime.Infrastructure.Mappings
{
    public class tb_businessMap : EntityTypeConfiguration<tb_business>
    {
        public tb_businessMap()
        {
            ToTable("tb_business");
            HasKey(x => x.id_business);
        }
    }
}
