using CloudinaryDotNet.Actions;

namespace Api.TheSill.src.interfaces {
    public interface IUploadService {
        Task<ImageUploadResult> UploadPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}