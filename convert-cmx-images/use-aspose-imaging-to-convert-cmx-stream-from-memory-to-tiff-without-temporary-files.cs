using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CMX image from memory stream
        byte[] cmxBytes = File.ReadAllBytes(inputPath);
        using (var cmxStream = new MemoryStream(cmxBytes))
        using (Image cmxImage = Image.Load(cmxStream))
        {
            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the image as TIFF directly to the output path
            cmxImage.Save(outputPath, tiffOptions);
        }
    }
}