using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class DocumentTypeImpRepository : IDocumentTypeRepository
    {
        public DocumentTypeDbModel createRecord(DocumentTypeDbModel record)
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
                    TipoDocumento record = db.TipoDocumento.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.TipoDocumento.Remove(record);
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
        public DocumentTypeDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                TipoDocumento record = db.TipoDocumento.Find(id);
                if (record == null)
                {
                    return null;
                }
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<DocumentTypeDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<TipoDocumento> list = db.TipoDocumento.Where(x => x.Nombre.Contains(filter));
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                return mapper.DataBaseToDbModelMapper(list);
            }
        }

        public DocumentTypeDbModel updateRecord(DocumentTypeDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}