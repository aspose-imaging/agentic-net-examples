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
        // Hardcoded input TIFF files and output directory
        string[] inputFiles = new[]
        {
            @"C:\Images\Input1.tif",
            @"C:\Images\Input2.tif",
            @"C:\Images\Input3.tif"
        };
        string outputDirectory = @"C:\Images\WebPOutput";

        try
        {
            // Ensure the output directory exists once (additional calls are safe)
            Directory.CreateDirectory(outputDirectory);

            // Limit parallelism to avoid excessive memory consumption
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };

            Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
            {
                // Verify input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path (same name with .webp extension)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory exists (safe to call repeatedly)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, set a page exporting action to release resources,
                // and save it as WebP using default options.
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Release page resources after each page is saved (helps memory usage)
                    tiffImage.PageExportingAction = (index, page) =>
                    {
                        GC.Collect();
                    };

                    // Save as WebP; you can adjust options (e.g., Quality, Lossless) if needed
                    tiffImage.Save(outputPath, new WebPOptions());
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}