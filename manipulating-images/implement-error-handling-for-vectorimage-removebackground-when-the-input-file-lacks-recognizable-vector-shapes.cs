// HOW-TO: Remove Background From Vector Image With Error Handling In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.cdr";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Check that the loaded image is a vector image
                if (image is VectorImage vectorImage)
                {
                    try
                    {
                        // Attempt to remove background
                        vectorImage.RemoveBackground();
                    }
                    catch (Exception ex)
                    {
                        // Handle case where background removal fails (e.g., no recognizable vector shapes)
                        Console.Error.WriteLine($"Background removal failed: {ex.Message}");
                        // Continue without background removal
                    }

                    // Save the result as PNG
                    var pngOptions = new PngOptions();
                    vectorImage.Save(outputPath, pngOptions);
                }
                else
                {
                    Console.Error.WriteLine("The provided file is not a vector image.");
                }
            }
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
 * 1. When you need to automatically strip the background from a CorelDRAW (.cdr) vector file and save it as a PNG while safely handling files that may not contain any vector shapes.
 * 2. When your application must verify that an input file exists and is a vector image before processing, preventing runtime crashes in batch image conversion jobs.
 * 3. When you want to integrate Aspose.Imaging’s RemoveBackground method into a C# service and gracefully log failures instead of terminating the workflow.
 * 4. When you are converting legacy vector graphics to raster PNGs for web display and need to ensure the output directory is created automatically.
 * 5. When you require a generic try‑catch structure around image loading and saving to capture unexpected errors such as unsupported formats or I/O issues.
 */
