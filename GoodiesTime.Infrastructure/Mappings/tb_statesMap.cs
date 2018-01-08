using System.Data.Entity.ModelConfiguration;
using GoodiesTime.Domain.Entities;
namespace GoodiesTime.Infrastructure.Mappings
{
    public class tb_statesMap : EntityTypeConfiguration<tb_states>
    {
        public tb_statesMap()
        {
            ToTable("tb_states");
            HasKey(x => x.id_state);
        }
    }
}
