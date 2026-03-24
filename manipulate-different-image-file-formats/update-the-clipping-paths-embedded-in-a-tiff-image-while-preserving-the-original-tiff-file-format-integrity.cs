using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            var existingPaths = image.ActiveFrame.PathResources;
            image.ActiveFrame.PathResources = existingPaths.Take(1).ToList();
            image.Save(outputPath);
        }
    }
}