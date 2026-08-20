// HOW-TO: Convert EPS to PNG in C# with Automatic Resource Disposal (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/result.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EPS image and automatically dispose it after use
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert vector EPS artwork to a raster PNG for web display while ensuring the image object is properly released.
 * 2. When building a C# service that processes user‑uploaded EPS files and returns PNG thumbnails without leaking memory.
 * 3. When integrating Aspose.Imaging into an automated build pipeline that transforms EPS assets into PNG assets for mobile apps.
 * 4. When creating a desktop utility that validates EPS files exist, creates output folders, and safely saves them as PNG using a using block.
 * 5. When handling large numbers of EPS files in a loop and want each Image instance to be disposed immediately after saving to PNG to avoid out‑of‑memory errors.
 */
