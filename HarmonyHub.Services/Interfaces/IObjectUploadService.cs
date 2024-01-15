using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services.Interfaces
{
	public interface IObjectUploadService
	{
		void UploadObject(string filePath, string keyName);
		string UploadFormFile(IFormFile file, string keyName);
	}
}
