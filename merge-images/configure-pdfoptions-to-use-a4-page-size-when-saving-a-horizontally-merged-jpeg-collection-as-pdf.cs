using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                Source source = new FileCreateSource(outputPath, false);
                using (PngOptions options = new PngOptions { Source = source })
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When a developer needs to convert high‑resolution JPEG photographs to lossless PNG files for web publishing while preserving transparency support.
 * 2. When an application must verify that a source image exists before processing to avoid runtime errors in a batch image conversion routine.
 * 3. When a C# service creates the output directory dynamically to store converted PNG assets in a structured folder hierarchy.
 * 4. When error handling is required to capture and log exceptions that may occur during image loading or saving with Aspose.Imaging.
 * 5. When a .NET project uses Aspose.Imaging’s Image.Load and PngOptions classes to efficiently transform JPEG input streams into PNG output streams for downstream image analysis.
 */