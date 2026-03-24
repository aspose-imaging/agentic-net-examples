using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.tif";
        string outputPath = "output\\updated.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (var image = (TiffImage)Image.Load(inputPath))
        {
            var newPath = new PathResource
            {
                BlockId = 2000,
                Name = "Updated Clipping Path"
            };

            image.ActiveFrame.PathResources = new List<PathResource> { newPath };
            image.Save(outputPath);
        }
    }
}