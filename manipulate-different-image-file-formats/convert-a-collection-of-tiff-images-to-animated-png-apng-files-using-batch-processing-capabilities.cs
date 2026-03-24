using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded collection of input TIFF files
        string[] inputPaths = {
            @"C:\Images\input1.tif",
            @"C:\Images\input2.tif",
            @"C:\Images\input3.tif"
        };

        // Output directory for generated APNG files
        string outputDirectory = @"C:\Images\Output";

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output file path (same name with .apng extension)
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".apng");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image and save as APNG
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                tiffImage.Save(outputPath, new ApngOptions());
            }
        }
    }
}