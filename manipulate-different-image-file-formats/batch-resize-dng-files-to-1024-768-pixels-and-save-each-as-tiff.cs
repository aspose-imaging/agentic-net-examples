using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all DNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.dng");

            foreach (var inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path with .tif extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".tif");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DNG, resize, and save as TIFF
                using (DngImage dng = (DngImage)Image.Load(inputPath))
                {
                    dng.Resize(1024, 768, ResizeType.NearestNeighbourResample);
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    dng.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}