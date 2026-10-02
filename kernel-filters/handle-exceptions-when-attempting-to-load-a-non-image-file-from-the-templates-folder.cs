// HOW-TO: Handle Exception When Loading Non‑Image File With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("templates", "nonimage.txt");
            string outputPath = Path.Combine("Output", "result.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to safely attempt to convert a user‑uploaded text file to PNG without crashing the application.
 * 2. When processing batch jobs that read files from a templates folder and you must log errors for unsupported formats.
 * 3. When building a web service that accepts arbitrary file paths and you want to return a clear error if the file is not a valid image.
 * 4. When automating document generation and you need to verify that each source file is an image before applying PNG options.
 * 5. When integrating Aspose.Imaging into a legacy system and you must gracefully handle cases where the expected image file is missing or corrupted.
 */
