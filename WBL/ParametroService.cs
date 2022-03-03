using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class ParametroService
    {
        private readonly IDataAccess sql;

        public ParametroService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region Metodos CRUD

        //Metodo GET
        public async Task<IEnumerable<ParametroEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ParametroEntity>("dbo.ParametroObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo GETbyId
        public async Task<ParametroEntity> GetById(ParametroEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ParametroEntity>("dbo.ParametroObtener", new { entity.Id_Parametro});
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo Create o Insertar
        public async Task<DBEntity> Create(ParametroEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ParametroInsertar", new
                           {entity.Codigo,
                            entity.Descripcion,
                            entity.Valor,
                            entity.Estado
                            });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo UPDATE
        public async Task<DBEntity> Update(ParametroEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ParametroInsertar", new
                {
                    entity.Codigo,
                    entity.Descripcion,
                    entity.Valor,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo DELETE
        public async Task<DBEntity> Delete(ParametroEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ParametroEliminar", new
                {
                    entity.Id_Parametro
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
