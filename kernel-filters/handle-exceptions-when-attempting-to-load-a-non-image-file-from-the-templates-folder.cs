// HOW-TO: How To Handle ImageLoadException When Loading Non‑Image Files In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"templates\sample.txt";
        string outputPath = @"output\result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Attempt to load the file as an image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image to the output path (e.g., convert to PNG)
                image.Save(outputPath);
            }
        }
        catch (ImageLoadException ile)
        {
            // Handle loading of a non‑image file
            Console.Error.WriteLine($"Unable to load image: {ile.Message}");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must convert user‑uploaded documents to PNG but needs to gracefully skip or report files that are not valid images.
 * 2. When processing a batch of files from a templates folder, you want to ensure missing files or unsupported formats do not crash the program.
 * 3. When generating thumbnails from a mixed collection of image and text files, you need exception handling for ImageLoadException to avoid runtime errors.
 * 4. When automating image conversion in a server‑side service, you must verify the input path, create the output directory, and catch loading errors for non‑image inputs.
 * 5. When building a document‑to‑image pipeline, you need to detect and log attempts to load non‑image files such as .txt or .pdf to maintain audit trails.
 */
