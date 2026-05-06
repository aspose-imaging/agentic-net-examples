using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            // Parallel processing options (limit degree of parallelism to avoid high memory usage)
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            Parallel.ForEach(tiffFiles, parallelOptions, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .webp extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Release page resources after each page is saved to keep memory usage low
                    tiffImage.PageExportingAction = (index, page) => { GC.Collect(); };

                    // Configure WebP export options
                    var webpOptions = new WebPOptions
                    {
                        Lossless = false,   // Use lossy compression
                        Quality = 80        // Adjust quality as needed
                    };

                    // Save as WebP
                    tiffImage.Save(outputPath, webpOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}