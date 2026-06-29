using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output/result.png";
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and automatically dispose it with using
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Save the EPS image as PNG
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
 * 1. When a C# desktop application must convert vector EPS files to raster PNG images while ensuring the loaded image resources are released promptly to avoid memory leaks.
 * 2. When an automated build pipeline processes design assets, converting EPS logos to PNG thumbnails and using a using block to guarantee disposal of the EpsImage object after each conversion.
 * 3. When a web API receives EPS uploads and returns PNG previews, the code safely loads and saves the image within a using statement to prevent resource exhaustion under high request volume.
 * 4. When a Windows service monitors a folder of EPS files and generates PNG versions for downstream reporting, the using construct ensures each image is disposed before the next file is processed.
 * 5. When a batch script runs on a server to migrate legacy EPS artwork to PNG format, employing the using statement simplifies cleanup and reduces the risk of running out of file handles.
 */