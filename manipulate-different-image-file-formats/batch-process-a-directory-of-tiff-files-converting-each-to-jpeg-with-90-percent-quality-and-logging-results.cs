using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Get all TIFF files in the input directory (both .tif and .tiff)
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allTiffFiles, 0);
            tiffFilesAlt.CopyTo(allTiffFiles, tiffFiles.Length);

            foreach (string inputPath in allTiffFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name, .jpg extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG options with 90% quality
                    var jpegOptions = new JpegOptions
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
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}