using DAL.dataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    /// <summary>
    /// Interface para acciones GET
    /// </summary>
    interface iDALGet
    {
        /// <summary>
        /// Obtener lista de personas
        /// </summary>
        /// <param name="filter">filtro tipo caPerson</param>
        /// <returns>lista de tipo caPerson</returns>
        List<caPerson> person(Expression<Func<caPerson, bool>> filter = null);

        /// <summary>
        /// Obtener lista de usuarios
        /// </summary>
        /// <param name="filter">filtro tipo caUsers</param>
        /// <returns>lista de tipo caUsers</returns>
        List<caUsers> user(Expression<Func<caUsers, bool>> filter = null);

        /// <summary>
        /// Obtener registros de rostros
        /// </summary>
        /// <param name="filter">filtro tipo caFaces</param>
        /// <returns>lista de tipo caFaces</returns>
        List<caFaces> faces(Expression<Func<caFaces, bool>> filter = null);
    }
}
