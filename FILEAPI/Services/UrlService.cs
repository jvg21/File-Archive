using FILEAPI.Data.Models;
using FILEAPI.Data.Request.Exceptions;
using FILEAPI.Repository;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services.Interfaces;
using Mapster;

namespace FILEAPI.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            this._urlRepository = urlRepository;
        }


        //public async Task<>(){}

        public async Task<List<UrlGetDTO>> GetAll()
        {
            var request = await _urlRepository.GetAll();
            return request.Adapt<List<UrlGetDTO>>();
        }

        public async Task<UrlGetDTO> GetById(int id)
        {
            var request = await _urlRepository.GetById(id);
            if (request == null) throw new EntityNotFoundException();
            return request.Adapt<UrlGetDTO>();
        }

        public async Task<UrlGetDTO> Insert(UrlInsertDTO urlInsertDTO)
        {
            if (urlInsertDTO == null) throw new InvalidFormException();

            var url = urlInsertDTO.Adapt<Url>();

            var request = await _urlRepository.Insert(url);
            var response = request.Adapt<UrlGetDTO>();

            return response;
        }

        public async Task<UrlGetDTO> Update(UrlUpdateDTO urlUpdateDTO)
        {
            if (urlUpdateDTO == null) throw new InvalidFormException();

            var url = await _urlRepository.GetById(urlUpdateDTO.Id);
            if (url == null) throw new EntityNotFoundException();

            /**Update Values**/
            if (urlUpdateDTO.Content != null) url.Content = urlUpdateDTO.Content;
            if (urlUpdateDTO.Name != null) url.Name = urlUpdateDTO.Name;

            var request = await _urlRepository.Update(url);
            return request.Adapt<UrlGetDTO>();
        }

        public async Task Delete(int id)
        {
            var url = await _urlRepository.GetById(id);
            if (url == null) throw new EntityNotFoundException();
            await _urlRepository.Delete(url);
        }
    }
}
