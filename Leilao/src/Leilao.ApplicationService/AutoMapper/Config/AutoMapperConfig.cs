using AutoMapper;
using Leilao.ApplicationService.AutoMapper.Profiles;

namespace Leilao.ApplicationService.AutoMapper.Config {

    public class AutoMapperConfig {
    
        public static MapperConfiguration RegisterMaps() {

            return new MapperConfiguration(c => {
                c.AddProfile(new DomainToEntity());
                c.AddProfile(new ViewModelToDomain());
                c.AddProfile(new EntityToResponseViewModel());
            });

        }
    
    }
}
