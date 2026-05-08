using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and list of TIFF files to process
            string inputDirectory = @"C:\Images\Input";
            string[] tiffFiles = new string[]
            {
                Path.Combine(inputDirectory, "image1.tif"),
                Path.Combine(inputDirectory, "image2.tif"),
                Path.Combine(inputDirectory, "image3.tif")
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\Output";

            foreach (string inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Build output file name with timestamp suffix
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as WebP using default options
                    image.Save(outputPath, new WebPOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}