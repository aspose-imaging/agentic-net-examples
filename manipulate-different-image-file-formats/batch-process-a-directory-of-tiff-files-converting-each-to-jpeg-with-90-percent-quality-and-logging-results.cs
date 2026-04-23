using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputTiffs";
            string outputDirectory = @"C:\OutputJpegs";

            // Get all TIFF files in the input directory (both .tif and .tiff)
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allTiffFiles, 0);
            tiffFilesAlt.CopyTo(allTiffFiles, tiffFiles.Length);

            foreach (string inputPath in allTiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .jpg extension
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG options with 90% quality
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}