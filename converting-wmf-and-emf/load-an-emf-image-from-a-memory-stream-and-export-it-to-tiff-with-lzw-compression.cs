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
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image into a memory stream
        byte[] emfData = File.ReadAllBytes(inputPath);
        using (MemoryStream ms = new MemoryStream(emfData))
        {
            using (Image image = Image.Load(ms))
            {
                // Set up TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw
                };

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
    }
}