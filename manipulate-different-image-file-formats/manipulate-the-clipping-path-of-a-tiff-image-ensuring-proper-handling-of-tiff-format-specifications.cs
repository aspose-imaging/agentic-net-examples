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
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, modify its clipping paths, and save
        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Keep only the first clipping path (if any)
            var paths = image.ActiveFrame.PathResources;
            image.ActiveFrame.PathResources = paths.Take(1).ToList();

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}