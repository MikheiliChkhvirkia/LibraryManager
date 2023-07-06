using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using LibraryManagement.FileManager.Interfaces;
using LibraryManagement.FileManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp.Formats.Jpeg;
using Image = SixLabors.ImageSharp.Image;

namespace LibraryManagement.FileManager.Services
{
    internal class FileUploadService : IFileUploadService
    {
        private readonly IConfiguration configuration;

        public FileUploadService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<FileResponse> UploadAsync(IFormFile request, CancellationToken cancellationToken)
        {
            if (request.Length <= 0)
            {
                throw new Exception("File has no length!");
            }

            // Set the desired maximum file size (in bytes)
            const int maxFileSizeBytes = 1000000;

            string fileExtension = System.IO.Path.GetExtension(request.FileName);

            await using var memoryStream = new MemoryStream();
            using var image = await Image.LoadAsync(request.OpenReadStream(), cancellationToken);

            // Resize the image until it's smaller than the maximum file size
            while (memoryStream.Length > maxFileSizeBytes)
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size((int)(image.Width * 0.9), (int)(image.Height * 0.9)),
                    Mode = ResizeMode.Max,
                }));
            }

            // Save the resized image to a memory stream
            await image.SaveAsync(memoryStream, new JpegEncoder(), cancellationToken);

            Guid uniqueId = Guid.NewGuid();

            var credentials = new BasicAWSCredentials(
                configuration["AwsConfiguration:AWSAccesKey"],
                configuration["AwsConfiguration:AWSSecretKey"]);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUCentral1
            };
            var fileName = $"{uniqueId}{fileExtension}";
            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = new MemoryStream(memoryStream.ToArray()),
                    Key = fileName,
                    BucketName = configuration["AwsConfiguration:BucketName"],
                    CannedACL = S3CannedACL.PublicRead
                };

                using var client = new AmazonS3Client(credentials, config);

                var transferUtility = new TransferUtility(client);

                await transferUtility.UploadAsync(uploadRequest, cancellationToken);

            }
            catch (AmazonS3Exception)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return new FileResponse { Extension = fileExtension, FileName = fileName, UniqueId = uniqueId };
        }
    }
}
