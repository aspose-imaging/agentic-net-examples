// HOW-TO: How To Convert EPS To PNG With Error Handling In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "output.png";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image and automatically dispose it after use
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG using default PNG options
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to safely convert a vector EPS file to a raster PNG in a C# application while handling missing files and runtime errors.
 * 2. When an automated batch process must generate PNG previews from EPS assets and ensure the output folder is created if it doesn’t exist.
 * 3. When integrating Aspose.Imaging into a .NET service that receives user‑uploaded EPS files and must return a PNG without crashing on corrupt inputs.
 * 4. When building a desktop tool that validates the presence of an EPS source before converting it to PNG and logs any exceptions for troubleshooting.
 * 5. When deploying a server‑side image pipeline that requires graceful error reporting while converting EPS graphics to PNG format using C#.
 */
