// HOW-TO: Convert EPS to PSD with RLE Compression Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.eps";
            string outputPath = @"C:\temp\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Set PSD options with desired compression method
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE // Use RLE compression; change to CompressionMethod.Raw for no compression
                };

                // Save the image as PSD using the specified options
                image.Save(outputPath, psdOptions);
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
 * 1. When you need to embed a vector EPS logo into a Photoshop file while keeping file size low by applying RLE compression.
 * 2. When an automated workflow converts batch EPS artwork to layered PSD files for further editing in Adobe Photoshop, and you want to control the compression method.
 * 3. When a web service receives EPS uploads and must store them as PSDs with predictable compression for consistent rendering across platforms.
 * 4. When migrating legacy EPS assets to PSD format for a design system and you require lossless RLE compression to preserve image quality.
 * 5. When generating PSD previews from EPS files in a C# application and you need to specify the compression to balance speed and storage.
 */
