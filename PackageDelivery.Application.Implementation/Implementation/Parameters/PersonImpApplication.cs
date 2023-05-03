using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.Parameters;

using System;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class PersonImpApplication : IPersonApplication
    {
        IPersonRepository _repository = new PersonImpRepository();

        PersonDTO IPersonApplication.createRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }

        bool IPersonApplication.deleteRecordById(int id)
        {
            throw new NotImplementedException();
        }

        PersonDTO IPersonApplication.getRecordById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PersonDTO> IPersonApplication.getRecordList(string filter)
        {
            throw new NotImplementedException();
        }

        PersonDTO IPersonApplication.updateRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }
    }
}