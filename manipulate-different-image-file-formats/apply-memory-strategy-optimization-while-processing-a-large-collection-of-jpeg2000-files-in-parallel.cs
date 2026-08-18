// HOW-TO: Convert Large JPEG2000 Collection to PNG with Parallel Memory Optimization in C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\temp\input";
            string outputDir = @"C:\temp\output";

            // Get all JPEG2000 files in the input directory (including subfolders)
            string[] jpeg2000Files = Directory.GetFiles(inputDir, "*.jp2", SearchOption.AllDirectories);

            // Process files in parallel
            Parallel.ForEach(jpeg2000Files, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the corresponding output path (PNG with same name)
                string relativePath = Path.GetRelativePath(inputDir, inputPath);
                string outputPath = Path.Combine(outputDir, Path.ChangeExtension(relativePath, ".png"));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set load options with a memory buffer hint (e.g., 50 MB)
                var loadOptions = new Jpeg2000LoadOptions
                {
                    BufferSizeHint = 50
                };

                // Load the JPEG2000 image using the specified load options
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save the image as PNG
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
 * 1. When you need to batch‑convert thousands of JP2 images to PNG on a server while keeping memory usage low.
 * 2. When you want to speed up image conversion by processing JPEG2000 files in parallel across multiple CPU cores.
 * 3. When you must preserve the original folder hierarchy while exporting JP2 files to a different format.
 * 4. When you are working with limited RAM and need to hint the loader to use a specific buffer size for large JP2 images.
 * 5. When you require automated error handling for missing files during bulk image processing in a .NET application.
 */
