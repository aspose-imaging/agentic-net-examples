// HOW-TO: Batch Compress GIF Files and Log Size Reduction in C# (Aspose.Imaging for .NET)
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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Retrieve all GIF files from the input directory
            string[] gifFiles = Directory.GetFiles(inputDir, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify that the input file actually exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine the output file path (same file name, different folder)
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDir, fileName);

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Record original file size
                long originalSize = new FileInfo(inputPath).Length;

                // Load the GIF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure lossy compression options
                    GifOptions saveOptions = new GifOptions
                    {
                        MaxDiff = 80,               // Recommended value for good lossy compression
                        DoPaletteCorrection = true // Improves visual quality
                    };

                    // Save the compressed GIF
                    image.Save(outputPath, saveOptions);
                }

                // Record compressed file size
                long compressedSize = new FileInfo(outputPath).Length;

                // Log the results
                Console.WriteLine($"Processed: {fileName}");
                Console.WriteLine($"Original size: {originalSize} bytes, Compressed size: {compressedSize} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the bandwidth of a website by compressing a large collection of GIF animations while tracking how much each file shrinks.
 * 2. When you are preparing GIF assets for a mobile app and want to automate loss‑y compression and record original versus compressed sizes for quality assurance.
 * 3. When a digital marketing team requires a nightly job that processes new GIFs, applies Aspose.Imaging compression settings, and logs size metrics for reporting.
 * 4. When you are migrating legacy GIF archives to a storage‑optimized format and need to batch compress them with C# while capturing size statistics for cost analysis.
 * 5. When you want to benchmark different GifOptions parameters by compressing multiple GIFs and comparing the before‑and‑after file sizes in a .NET application.
 */
