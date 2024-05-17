using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.FileUpLoadService
{
    public interface IFileUpLoadServices
    {
        Task<string> UpLoadFile(IFormFile file);
    }
}