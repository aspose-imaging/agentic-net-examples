// HOW-TO: Convert EPS to PNG with Validation and Resize in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and validate it is an EPS image
            using (var image = Image.Load(inputPath) as EpsImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Loaded file is not an EPS image.");
                    return;
                }

                // Example conversion: resize the EPS image
                image.Resize(400, 400, ResizeType.Mitchell);

                // Save the result as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to ensure an uploaded file is a genuine EPS before converting it to a PNG for web display.
 * 2. When you must resize a vector EPS logo to a fixed pixel dimension while preserving quality before saving as PNG.
 * 3. When processing batch jobs that convert EPS artwork to PNG thumbnails and need to skip non‑EPS files gracefully.
 * 4. When integrating Aspose.Imaging into a C# service that validates image type, rescales, and stores the result in a specific output folder.
 * 5. When building a desktop utility that checks the file format, adjusts image size, and outputs a PNG for further editing or publishing.
 */
