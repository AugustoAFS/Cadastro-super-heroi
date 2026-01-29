using ApplicationService.Dtos.Requests.Heroi;
using ApplicationService.Dtos.Resposes.Heroi;
using ApplicationService.Dtos.Resposes.Superpoder;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace ApplicationService.Mappings
{
    [Mapper]
    public partial class HeroiMapper
    {
        [MapProperty(nameof(Herois.HeroisSuperpoderes), nameof(HeroiResponse.Superpoderes))]
        public partial HeroiResponse MapToResponse(Herois heroi);
        public partial List<HeroiResponse> MapToResponseList(List<Herois> herois);

        [MapProperty(nameof(@HeroisSuperpoderes.Superpoder.Superpoder), nameof(@SuperpoderResponse.Superpoder))]
        [MapProperty(nameof(@HeroisSuperpoderes.Superpoder.Descricao), nameof(@SuperpoderResponse.Descricao))]
        [MapProperty(nameof(@HeroisSuperpoderes.SuperpoderId), nameof(@SuperpoderResponse.Id))]
        private partial SuperpoderResponse MapHeroisSuperpoderesToSuperpoderResponse(HeroisSuperpoderes source);



        [MapperIgnoreTarget(nameof(Herois.Id))]
        [MapperIgnoreTarget(nameof(Herois.Created_At))]
        [MapperIgnoreTarget(nameof(Herois.HeroisSuperpoderes))]
        public partial Herois MapFromCreateRequest(CreateHeroiRequest request);

        [MapperIgnoreTarget(nameof(Herois.Id))]
        [MapperIgnoreTarget(nameof(Herois.Created_At))]
        [MapperIgnoreTarget(nameof(Herois.HeroisSuperpoderes))]
        public partial void UpdateHeroiFromRequest(UpdateHeroiRequest request, [MappingTarget] Herois heroiTarget);

    }
}