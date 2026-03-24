using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // Example format, adjust as needed
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = @"C:\temp\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image as a RasterImage (base class for raster formats)
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Retrieve the last modification timestamp.
            // The 'true' argument tells the method to fall back to FileInfo if metadata is missing.
            DateTime modifyDate = image.GetModifyDate(true);

            Console.WriteLine($"Last modification date of '{Path.GetFileName(inputPath)}': {modifyDate}");
        }

        // Example of creating an output directory if you later need to save something.
        // This follows the required rule but is not used in this read‑only scenario.
        string outputPath = @"C:\temp\output\placeholder.txt";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
    }
}