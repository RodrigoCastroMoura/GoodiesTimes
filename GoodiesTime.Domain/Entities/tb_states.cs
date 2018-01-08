using GoodiesTime.Domain.DTO;

namespace GoodiesTime.Domain.Entities
{
    public class tb_states
    {
        public int id_state { get; private set; }

        public string ds_name { get; private set; }

        public string ds_cod { get; private set; }

        protected tb_states()
        {
            
        }

        private tb_states(tb_statesDto dto)
        {
            id_state = dto.id_state;

            ds_name = dto.ds_name;

            ds_cod = dto.ds_cod;

        }

        public static tb_states RetornotBusiness(tb_statesDto dto)
        {
            return new tb_states(dto);
        }
    }
}
