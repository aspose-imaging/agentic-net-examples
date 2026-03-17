using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            var newPath = new Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource
            {
                BlockId = 2000,
                Name = "Updated Clipping Path",
                Records = null
            };

            image.ActiveFrame.PathResources = new List<Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource> { newPath };

            image.Save(outputPath);
        }
    }
}
