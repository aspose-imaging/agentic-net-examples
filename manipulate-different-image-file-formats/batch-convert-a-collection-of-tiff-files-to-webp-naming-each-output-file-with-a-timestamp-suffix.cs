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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists (will be called for each file as required)
            // This call is also safe if the directory already exists.
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (Image tiffImage = Image.Load(inputPath))
                {
                    // Build output file name with timestamp suffix
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the directory for the output file exists (unconditional as per rules)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as WebP using default options
                    WebPOptions webpOptions = new WebPOptions();
                    tiffImage.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}