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
    /// Interface para acciones POST
    /// </summary>
    interface iDALPost
    {
        /// <summary>
        /// registrar Usuario
        /// </summary>
        /// <param name="model">modelo tipo caUsers</param>
        /// <returns>objeto tipo caUsers</returns>
        caUsers saveUser(caUsers model);

        /// <summary>
        /// Registrar rostro
        /// </summary>
        /// <param name="model">modelo tipo caFaces</param>
        /// <returns>objeto tipo caFaces</returns>
        caFaces saveFace(caFaces model);

        /// <summary>
        /// Actualizar información de la persona
        /// </summary>
        /// <param name="model">modelo tipo caPerson</param>
        /// <returns>objeto tipo caPerson</returns>
        caPerson updatePerson(caPerson model);

        /// <summary>
        /// Actualizar información del usuario
        /// </summary>
        /// <param name="model">modelo tipo caUsers</param>
        /// <returns></returns>
        caUsers updateUser(caUsers model);

        /// <summary>
        /// Desactivar usuario
        /// </summary>
        /// <param name="idUser">identificador del usuario</param>
        /// <returns>Falso o Verdadero</returns>
        void deactivateUser(int idUser);

        /// <summary>
        /// Desactivar rostro
        /// </summary>
        /// <param name="idFace">identificador del rostro</param>
        /// <returns>Falso o Verdadero</returns>
        void deactivateFace(int idFace);
    }
}
