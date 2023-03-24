using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class PackageRepositoryMapper : DbModelMapperBase<PackageDbModel, Paquete>
    {
        public override PackageDbModel DataBaseToDbModelMapper(Paquete input)
        {
            return new PackageDbModel()
            {
                Id = input.Id,
                Weight = input.Peso.ToString(),
                Depth = input.Profundidad.ToString(),
                Width = input.Ancho.ToString(),
                Height = input.Altura.ToString(),
                Id_Office = input.Id_Oficina
            };
        }

        public override IEnumerable<PackageDbModel> DataBaseToDbModelMapper(IEnumerable<Paquete> input)
        {
            IList<PackageDbModel> list = new List<PackageDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DataBaseToDbModelMapper(item));
            }
            return list;
        }

        public override Paquete DbModelToDataBaseMapper(PackageDbModel input)
        {
            return new Paquete()
            {
                Id = input.Id,
                Peso = int.Parse(input.Weight),
                Profundidad = int.Parse(input.Depth),
                Ancho = int.Parse(input.Width),
                Altura = int.Parse(input.Height),
                Id_Oficina = input.Id_Office
            };
        }

        public override IEnumerable<Paquete> DbModelToDataBaseMapper(IEnumerable<PackageDbModel> input)
        {
            IList<Paquete> list = new List<Paquete>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDataBaseMapper(item));
            }
            return list;
        }
    }
}
