using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (var image = (TiffImage)Image.Load(inputPath))
        {
            var existingPaths = image.ActiveFrame.PathResources;

            if (existingPaths != null && existingPaths.Count > 0)
            {
                image.ActiveFrame.PathResources = existingPaths.Take(1).ToList();
            }
            else
            {
                var newPath = new Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource
                {
                    BlockId = 2000,
                    Name = "New Clipping Path"
                };
                image.ActiveFrame.PathResources = new List<Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource> { newPath };
            }

            image.Save(outputPath);
        }
    }
}