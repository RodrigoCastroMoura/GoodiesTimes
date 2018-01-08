using System.Data.Entity.ModelConfiguration;
using GoodiesTime.Domain.Entities;

namespace GoodiesTime.Infrastructure.Mappings
{
    public class tb_partnersMap : EntityTypeConfiguration<tb_partners>
    {
        public tb_partnersMap()
        {
            ToTable("tb_partners");

            HasKey(x => x.id_partners);

            
        }
    }
}
