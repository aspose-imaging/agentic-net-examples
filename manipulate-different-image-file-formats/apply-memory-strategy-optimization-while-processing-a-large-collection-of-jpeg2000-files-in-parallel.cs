using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\input\jp2\";
        string outputDirectory = @"C:\output\png\";

        try
        {
            // Get all JPEG2000 files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jp2", SearchOption.AllDirectories);

            // Process files in parallel
            Parallel.ForEach(inputFiles, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same file name with .png extension)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load JPEG2000 image with memory limit (BufferSizeHint in MB)
                var loadOptions = new Jpeg2000LoadOptions
                {
                    BufferSizeHint = 100 // limit internal buffers to 100 MB
                };

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save as PNG
                    image.Save(outputPath, new PngOptions());
                }
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
 * 1. When a developer must batch‑convert thousands of JPEG2000 (.jp2) files to PNG in a high‑performance C# application while preventing excessive RAM consumption, this parallel processing code with BufferSizeHint is ideal.
 * 2. When a server‑side image‑processing service needs to generate web‑ready PNG thumbnails from a deep folder hierarchy of JP2 medical scans without exhausting memory, the example demonstrates the required approach.
 * 3. When an automated migration tool has to move legacy JP2 assets to a modern PNG repository on Windows and must respect limited system resources, the code shows how to load each image with a 100 MB buffer and save it concurrently.
 * 4. When a cloud‑based batch job processes large satellite JP2 imagery on a multi‑core VM and must keep the memory footprint predictable, the Parallel.ForEach pattern with Jpeg2000LoadOptions provides a scalable solution.
 * 5. When a desktop utility needs to convert user‑selected JP2 pictures to PNG while ensuring the UI remains responsive and the application stays within a defined memory budget, this example illustrates the necessary C# techniques.
 */