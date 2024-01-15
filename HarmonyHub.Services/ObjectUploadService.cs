using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Threading.Tasks;
using System.Reflection;
using Amazon.S3.Transfer;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;

namespace HarmonyHub.Services
{
	public class ObjectUploadService : IObjectUploadService
	{
		private IAmazonS3 _s3Client;

		private TransferUtility _fileTransferUtility;

		private const string BUCKET_NAME = "harmonyhub";

		private const string ACCESS_KEY = "6de0d166-6cf5-4b86-ba20-e033140f41b7";
		private const string SECRET_KEY = "f17e853a2ff76f6d0e8436dcd6f9bff68e87c33f585d3e8391fbe1c1fd6fafe2";
		private const string ENDPOINT = "https://s3.ir-thr-at1.arvanstorage.ir";

		private const string OBJECT_NAME = "<OBJECT_NAME>";

		private static string LOCAL_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public ObjectUploadService(
			)
        {
			var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(ACCESS_KEY, SECRET_KEY);
			var config = new AmazonS3Config { ServiceURL = ENDPOINT, };
			_s3Client = new AmazonS3Client(awsCredentials, config);
			_fileTransferUtility = new TransferUtility(_s3Client);
        }

		public void UploadObject(string filePath, string keyName)
		{
			try
			{
				// Upload the file to Amazon S3
				_fileTransferUtility.Upload(filePath, BUCKET_NAME, keyName);
				Console.WriteLine("Upload completed!");
			}
			catch (AmazonS3Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
				Console.ResetColor();
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
				Console.ResetColor();
			}
		}

		public string UploadFormFile(IFormFile file, string keyName)
		{
			try
			{
                var request = new TransferUtilityUploadRequest
                {
                    BucketName = BUCKET_NAME,
                    Key = keyName,
                    InputStream = file.OpenReadStream(),
                    CannedACL = S3CannedACL.PublicRead
                };
                // Upload the file to Amazon S3
                _fileTransferUtility.Upload(request);
                Console.WriteLine("Upload completed!");
				// the url is https://<bucket-name>.s3.ir-thr-at1.arvanstorage.ir/<key-name>
				var url = $"https://{BUCKET_NAME}.s3.ir-thr-at1.arvanstorage.ir/{keyName}";
				return url;
            }
            catch (AmazonS3Exception e)
			{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
			{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
                Console.ResetColor();
            }
			return "";
		}
	}
}


