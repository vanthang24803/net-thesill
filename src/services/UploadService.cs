using Api.TheSill.src.interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Api.TheSill.src.services {
    public class UploadService : IUploadService {
        private readonly Cloudinary _cloudinary;

        public UploadService(IConfiguration configuration) {
            var config = configuration.GetSection("CloudinarySetting");

            var account = new Account(
                config["CloudName"],
                config["ApiKey"],
                config["ApiSecret"]
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId) {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile file) {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0) {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams {
                    File = new FileDescription(file.Name, stream)
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);

            }
            return uploadResult;
        }
    }
}