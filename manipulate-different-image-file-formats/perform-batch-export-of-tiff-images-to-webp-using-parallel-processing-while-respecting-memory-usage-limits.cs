// HOW-TO: Batch Convert Multiple TIFF Files to WebP in Parallel with C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded list of TIFF files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.tif",
                @"C:\Images\sample2.tif",
                @"C:\Images\sample3.tif"
            };

            // Limit parallelism to the number of logical processors
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path with .webp extension
                string outputPath = Path.ChangeExtension(inputPath, ".webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // If the image is a multi‑page TIFF, release pages after each export to keep memory low
                    if (image is TiffImage tiffImage)
                    {
                        tiffImage.PageExportingAction = (index, page) =>
                        {
                            // Force garbage collection after each page is saved
                            GC.Collect();
                        };
                    }

                    // Configure WebP export options (adjust as needed)
                    var webpOptions = new WebPOptions
                    {
                        Lossless = false,
                        Quality = 80
                    };

                    // Save the image as WebP
                    image.Save(outputPath, webpOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly shrink a large collection of high‑resolution TIFF scans into smaller WebP files for faster web delivery.
 * 2. When processing multi‑page TIFF documents on a server, you want each page saved as WebP while keeping memory usage low.
 * 3. When a desktop application must convert dozens of TIFF images to WebP simultaneously, leveraging all CPU cores for speed.
 * 4. When automating image migration in a CI pipeline, you require parallel conversion with controlled parallelism to avoid out‑of‑memory errors.
 * 5. When building a photo‑archiving tool that exports TIFF archives to WebP format without blocking the UI, using Aspose.Imaging’s parallel API.
 */
