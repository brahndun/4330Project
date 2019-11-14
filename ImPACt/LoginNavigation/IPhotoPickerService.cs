using System;
using System.Collections;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LoginNavigation
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
