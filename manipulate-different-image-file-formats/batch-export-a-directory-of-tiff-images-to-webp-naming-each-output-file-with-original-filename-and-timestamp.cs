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
            string inputDirectory = @"C:\Images\Tiff";
            string outputDirectory = @"C:\Images\WebP";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file name: original name + timestamp + .webp
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save it as WebP
                using (Image image = Image.Load(inputPath))
                {
                    var webpOptions = new WebPOptions();
                    image.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}