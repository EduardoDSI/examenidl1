using ic_tienda_bussines.Store.models;
using ic_tienda_data.sources.BaseDeDatos.Tables;

namespace ic_tienda_data.Store.extentions
{
    public static class CitaExtentions
    {
        // Convertir de la tabla (CitaTable) al modelo de negocio (Cita)
        public static Cita ToModel(this CitaTable table)
        {
            return new Cita
            {
                Id = table.id,
                IdCargaHoraria = table.id_carga_horaria,
                IdUsuario = table.id_usuario,
                HoraInicio = table.hora_inicio,
                Estado = table.estado
            };
        }

        // Convertir del modelo de negocio (Cita) a la tabla (CitaTable)
        public static CitaTable ToTable(this Cita model)
        {
            return new CitaTable
            {
                id = model.Id,
                id_carga_horaria = model.IdCargaHoraria,
                id_usuario = model.IdUsuario,
                hora_inicio = model.HoraInicio,
                estado = model.Estado
            };
        }
    }
}
