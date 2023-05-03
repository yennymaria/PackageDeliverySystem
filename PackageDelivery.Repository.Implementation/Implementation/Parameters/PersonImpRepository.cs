using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class PersonImpRepository : IPersonRepository
    {
        public PersonDbModel createRecord(PersonDbModel record)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Eliminación de un registro en la base de datos por Id
        /// </summary>
        /// <param name="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    Persona record = db.Persona.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Persona.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cunado si lo encuentra</returns>
        public PersonDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                Persona record = db.Persona.Find(id);
                if (record == null)
                {
                    return null;
                }
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PersonDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<Persona> list = db.Persona.Where(x => x.PrimerNombre.Contains(filter));
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public PersonDbModel updateRecord(PersonDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}