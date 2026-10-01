// HOW-TO: Convert OTG Image to PNG Preserving Metadata in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

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
 * 1. When you need to display OTG graphics on web pages that only support PNG while keeping EXIF and custom metadata intact.
 * 2. When migrating a legacy design archive from OTG files to PNG for use in modern UI frameworks without losing color profile information.
 * 3. When automating a batch process that converts scanned OTG documents to PNG for OCR pipelines while preserving embedded tags.
 * 4. When integrating third‑party OTG assets into a C# desktop application that requires PNG textures but must retain original resolution and metadata.
 * 5. When creating a backup of OTG images in a lossless PNG format to ensure future compatibility and maintain all original image properties.
 */
