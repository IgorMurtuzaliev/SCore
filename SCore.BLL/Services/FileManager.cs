﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SCore.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BLL.Services
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Avatar"];
        }
        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }
        public async Task<string> SaveImage(IFormFile image)
        {
            try {
            var _savePath = Path.Combine(_imagePath);
            if (!Directory.Exists(_savePath))
            {
                Directory.CreateDirectory(_savePath);
            }
            var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
            var file_name = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";


            using (var fileStream = new FileStream(Path.Combine(_savePath, file_name), FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return file_name;
 }
            catch
            {
                return "Error";
            }
        }

        //public async Task<List<string>> SaveImage(IFormFileCollection images)
        //{
        //    var _savePath = Path.Combine(_imagePath);
        //    if (!Directory.Exists(_savePath))
        //    {
        //        Directory.CreateDirectory(_savePath);
        //    }
        //    foreach(var image in images)
        //    {
        //        var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
        //        var file_name = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";
        //        using (var fileStream = new FileStream(Path.Combine(_savePath, file_name), FileMode.Create))
        //        {
        //            await image.CopyToAsync(fileStream);
        //        }
        //        return file_name;
        //    }
        //}
    }
}