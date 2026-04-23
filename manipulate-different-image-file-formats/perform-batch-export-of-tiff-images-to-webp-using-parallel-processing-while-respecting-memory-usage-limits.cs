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
        // Wrap the entire execution in a try/catch to report any unexpected errors.
        try
        {
            // Hard‑coded input and output directories.
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Retrieve all TIFF files from the input folder.
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            // Limit parallelism to avoid excessive memory consumption.
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };

            // Process each TIFF file in parallel.
            Parallel.ForEach(tiffFiles, parallelOptions, inputPath =>
            {
                // Verify that the source file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output WebP file path.
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image.
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Optional: release page resources after each page is saved.
                    tiffImage.PageExportingAction = (index, page) => { GC.Collect(); };

                    // Configure WebP export options.
                    var webpOptions = new WebPOptions
                    {
                        Lossless = false,   // Use lossy compression.
                        Quality = 80        // Adjust quality as needed.
                    };

                    // Save the image as WebP.
                    tiffImage.Save(outputPath, webpOptions);
                }
            });
        }
        catch (Exception ex)
        {
            // Report any errors without crashing the process.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}