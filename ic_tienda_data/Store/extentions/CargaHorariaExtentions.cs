using ic_tienda_bussines.Store.models;
using ic_tienda_data.sources.BaseDeDatos.Tables;

namespace ic_tienda_data.Store.extentions
{
    public static class CargaHorariaExtentions
    {
        // Convertir de la tabla (CargaHorariaTable) al modelo de negocio (CargaHoraria)
        public static CargaHoraria ToModel(this CargaHorariaTable table)
        {
            return new CargaHoraria
            {
                Id = table.id,
                IdOperador = table.id_operador,
                Fecha = table.fecha,
                HoraInicio = table.hora_inicio,
                HoraFin = table.hora_fin
            };
        }

        // Convertir del modelo de negocio (CargaHoraria) a la tabla (CargaHorariaTable)
        public static CargaHorariaTable ToTable(this CargaHoraria model)
        {
            return new CargaHorariaTable
            {
                id = model.Id,
                id_operador = model.IdOperador,
                fecha = model.Fecha,
                hora_inicio = model.HoraInicio,
                hora_fin = model.HoraFin
            };
        }
    }
}
