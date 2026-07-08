using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Configure PNG save options with vector rasterization for EMF
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Color.White // optional background
                    }
                };

                // Save as PNG
                emfImage.Save(outputPath, pngOptions);
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
 * 1. When a Windows desktop application needs to display legacy vector graphics (EMF files) on a web page, a developer can convert the EMF to a PNG bitmap using Aspose.Imaging for .NET.
 * 2. When generating PDF reports that embed high‑resolution thumbnails of vector diagrams, a developer can rasterize the EMF to a PNG image to ensure consistent rendering across platforms.
 * 3. When an automated document‑conversion service receives EMF attachments and must store them as web‑friendly PNG files for indexing and preview, this code provides the necessary C# conversion.
 * 4. When a batch‑processing job must create printable PNG assets from a collection of EMF logos while preserving background color and dimensions, the Aspose.Imaging rasterization options simplify the task.
 * 5. When a mobile app backend needs to serve EMF icons to iOS and Android devices that only support raster images, developers can use this snippet to convert the EMF to PNG on the server side.
 */