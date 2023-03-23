﻿using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class PersonRepositoryMapper : DbModelMapperBase<PersonDbModel, Persona>
    {
        public override PersonDbModel DataBaseToDbModelMapper(Persona input)
        {
            return new PersonDbModel()
            {
                Id = input.Id,
                FirstName = input.PrimerNombre,
                OtherNames = input.OtrosNombres,
                FirstLastName = input.PrimerApellido,
                SecondLastName = input.SegundoApellido,
                IdentificationNumber = input.Documento.ToString(),
                CellPhone = input.Telefono.ToString(),
                Email = input.Correo,
                DocumentType = input.Id_TipoDocumento
            };
        }

        public override IEnumerable<PersonDbModel> DataBaseToDbModelMapper(IEnumerable<Persona> input)
        {
            IList<PersonDbModel> list = new List<PersonDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Persona DbModelToDataBaseMapper(PersonDbModel input)
        {
            return new Persona()
            {
                Id = input.Id,
                PrimerNombre = input.FirstName,
                OtrosNombres = input.OtherNames,
                PrimerApellido = input.FirstLastName,
                SegundoApellido = input.SecondLastName,
                Documento = int.Parse(input.IdentificationNumber),
                Telefono = int.Parse(input.CellPhone),
                Correo = input.Email,
                Id_TipoDocumento = input.DocumentType
            };
        }

        public override IEnumerable<Persona> DbModelToDataBaseMapper(IEnumerable<PersonDbModel> input)
        {
            IList<Persona> list = new List<Persona>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}