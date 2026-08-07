using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
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
 * 1. When a developer needs to verify that a PNG file exists on disk and then re‑save it with Aspose.Imaging to ensure it conforms to PNG standards before further processing.
 * 2. When a C# application must duplicate an existing PNG image to a new location while applying Aspose.Imaging’s default PNG encoding for consistent compression.
 * 3. When a web service receives a PNG path, creates the target directory if missing, and uses Aspose.Imaging to write the image to a secure output folder.
 * 4. When a batch job iterates over multiple PNG files, loading each with Aspose.Imaging’s RasterImage class to guarantee proper pixel format handling before saving them with standardized PNG options.
 * 5. When a developer wants to catch and log any exceptions that occur during PNG file loading or saving in a .NET environment using Aspose.Imaging for robust error handling.
 */