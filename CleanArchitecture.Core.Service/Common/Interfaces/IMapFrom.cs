using AutoMapper;

namespace CleanArchitecture.Core.Service
{
   public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
}



