using FILEAPI.Data.Models;
using FILEAPI.Data.Request.Exceptions;
using FILEAPI.Repository;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services.Interfaces;
using Mapster;

namespace FILEAPI.Services
{
    public class FileArchiveService : IFileArchiveService
    {
        private readonly IFileArchiveRepository _fileArchiveRepository;

        public FileArchiveService(IFileArchiveRepository fileArchiveRepository)
        {
            this._fileArchiveRepository = fileArchiveRepository;
        }


        //public async Task<>(){}

        public async Task<List<FileArchiveGetDTO>> GetAll()
        {
            var request = await _fileArchiveRepository.GetAll();
            return request.Adapt<List<FileArchiveGetDTO>>();
        }

        public async Task<FileArchiveGetDTO> GetById(int id)
        {
            var request = await _fileArchiveRepository.GetById(id);
            if (request == null) throw new EntityNotFoundException();
            return request.Adapt<FileArchiveGetDTO>();
        }

        public async Task<FileArchiveGetDTO> Insert(FileArchiveInsertDTO fileArchiveInsertDTO)
        {
            if (fileArchiveInsertDTO == null) throw new InvalidFormException();

            var fileArchive = fileArchiveInsertDTO.Adapt<FileArchive>();

            var request = await _fileArchiveRepository.Insert(fileArchive);
            var response = request.Adapt<FileArchiveGetDTO>();

            return response;
        }

        public async Task<FileArchiveGetDTO> Update(FileArchiveUpdateDTO fileArchiveUpdateDTO)
        {
            if (fileArchiveUpdateDTO == null) throw new InvalidFormException();

            var fileArchive = await _fileArchiveRepository.GetById(fileArchiveUpdateDTO.Id);
            if (fileArchive == null) throw new EntityNotFoundException();

            /**Update Values**/
            if (fileArchiveUpdateDTO.Name != null) fileArchive.Name = fileArchiveUpdateDTO.Name;
            if (fileArchiveUpdateDTO.StorageName != null) fileArchive.StorageName = fileArchiveUpdateDTO.StorageName;
            if (fileArchiveUpdateDTO.Extension != null) fileArchive.Extension = fileArchiveUpdateDTO.Extension;
            if (fileArchiveUpdateDTO.MimeType != null) fileArchive.MimeType = fileArchiveUpdateDTO.MimeType;
            if (fileArchiveUpdateDTO.Path != null) fileArchive.Path = fileArchiveUpdateDTO.Path;
            if (fileArchiveUpdateDTO.StorageBytes != null) fileArchive.StorageBytes = fileArchiveUpdateDTO.StorageBytes.Value;


            var request = await _fileArchiveRepository.Update(fileArchive);
            return request.Adapt<FileArchiveGetDTO>();
        }

        public async Task Delete(int id)
        {
            var fileArchive = await _fileArchiveRepository.GetById(id);
            if (fileArchive == null) throw new EntityNotFoundException();
            await _fileArchiveRepository.Delete(fileArchive);
        }
    }
}
