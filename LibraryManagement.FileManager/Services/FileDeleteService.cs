using Amazon.S3;
using Amazon.S3.Model;
using LibraryManagement.FileManager.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LibraryManagement.FileManager.Services
{
    internal class FileDeleteService : IFileDeleteService
    {
        private readonly IConfiguration configuration;
        public FileDeleteService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task Delete(List<string> fileName)
        {
            var s3Client = new AmazonS3Client(configuration["AwsConfiguration:AWSAccesKey"], configuration["AwsConfiguration:AWSSecretKey"], Amazon.RegionEndpoint.EUCentral1);

            var deleteRequest = new DeleteObjectsRequest
            {
                BucketName = configuration["AwsConfiguration:BucketName"],
                Objects = fileName.Select(key => new KeyVersion { Key = key }).ToList()
            };

            await s3Client.DeleteObjectsAsync(deleteRequest);
        }

        public async Task Delete(string fileName)
        {
            var s3Client = new AmazonS3Client(configuration["AwsConfiguration:AWSAccesKey"], configuration["AwsConfiguration:AWSSecretKey"], Amazon.RegionEndpoint.EUCentral1);

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = configuration["AwsConfiguration:BucketName"],
                Key = fileName
            };

            await s3Client.DeleteObjectAsync(deleteRequest);
        }
    }
}
