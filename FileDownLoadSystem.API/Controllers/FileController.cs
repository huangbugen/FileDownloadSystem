using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDownLoadSystem.Core.Utility;
using FileDownLoadSystem.System.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FileDownLoadSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            this._fileService = fileService;
        }

        [HttpGet]
        public async Task<WebResponseContent> GetFilesByTypeId(int fileTypeId)
        {
            return await _fileService.GetFilesByTypeId(fileTypeId);
        }
    }
}