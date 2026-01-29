using ApplicationService.Dtos.Resposes.Superpoder;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace ApplicationService.Mappings
{

    [Mapper]
    public partial class SuperpoderMapper
    {
        public partial SuperpoderResponse MapToResponse(Superpoderes superpoder);

        public partial List<SuperpoderResponse> MapToResponseList(List<Superpoderes> superpoderes);

        [MapProperty(nameof(HeroisSuperpoderes.SuperpoderId), nameof(SuperpoderResponse.Id))]
        [MapProperty($"{nameof(HeroisSuperpoderes.Superpoder)}.{nameof(Superpoderes.Superpoder)}", nameof(SuperpoderResponse.Superpoder))]
        [MapProperty($"{nameof(HeroisSuperpoderes.Superpoder)}.{nameof(Superpoderes.Descricao)}", nameof(SuperpoderResponse.Descricao))]
        public partial SuperpoderResponse MapFromHeroiSuperpoder(HeroisSuperpoderes heroiSuperpoder);

        public partial List<SuperpoderResponse> MapFromHeroiSuperpodereslist(List<HeroisSuperpoderes> heroiSuperpoderes);
    }
}
