using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.Parameters;

using System;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class DocumentTypeImpApplication : IDocumentTypeApplication
    {
        IDocumentTypeRepository _repository = new DocumentTypeImpRepository();

        DocumentTypeDTO IDocumentTypeApplication.createRecord(DocumentTypeDTO record)
        {
            throw new NotImplementedException();
        }

        bool IDocumentTypeApplication.deleteRecordById(int id)
        {
            throw new NotImplementedException();
        }

        DocumentTypeDTO IDocumentTypeApplication.getRecordById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DocumentTypeDTO> IDocumentTypeApplication.getRecordList(string filter)
        {
            throw new NotImplementedException();
        }

        DocumentTypeDTO IDocumentTypeApplication.updateRecord(DocumentTypeDTO record)
        {
            throw new NotImplementedException();
        }
    }
}