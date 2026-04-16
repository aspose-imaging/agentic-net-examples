using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.emf";
        string outputPath = "output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EMF image from a memory stream
        byte[] emfData = File.ReadAllBytes(inputPath);
        using (MemoryStream ms = new MemoryStream(emfData))
        using (Image emfImage = Image.Load(ms))
        {
            // Configure TIFF save options with LZW compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Lzw
            };

            // Save the image as TIFF
            emfImage.Save(outputPath, tiffOptions);
        }
    }
}