using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When a developer needs to display legacy WMF vector graphics on a modern website that only supports PNG with an alpha channel, this code converts the WMF to a transparent PNG.
 * 2. When a desktop application must generate thumbnail previews of WMF files for a file explorer UI, the code rasterizes the vector image to a PNG while keeping its transparent background.
 * 3. When an automated reporting tool creates PDF or HTML reports and must embed WMF logos as PNG assets with preserved transparency, this snippet performs the required format conversion.
 * 4. When a batch processing script migrates a legacy document repository from WMF icons to PNG assets for cross‑platform compatibility, the code ensures each image retains its transparent background.
 * 5. When a C# service integrates with a third‑party API that accepts only PNG images with alpha transparency, this example converts incoming WMF files to the required format without losing transparency.
 */