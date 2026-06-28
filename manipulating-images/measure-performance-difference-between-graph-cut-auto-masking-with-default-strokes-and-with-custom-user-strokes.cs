using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        const string inputPath = "input.jpg";
        const string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
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
 * 1. When a developer needs to convert user‑uploaded JPEG photos to lossless PNG files with an alpha channel for web applications that require transparent backgrounds.
 * 2. When a batch‑processing script must verify the existence of source images, create missing output folders, and reliably save converted PNGs using Aspose.Imaging in a .NET service.
 * 3. When integrating image conversion into a C# desktop tool that reads JPEGs, applies Aspose.Imaging’s PngOptions, and outputs PNGs for downstream graphics pipelines.
 * 4. When handling error‑prone file I/O in an automated workflow, a developer can use the try‑catch pattern shown to log missing files or conversion failures.
 * 5. When optimizing storage, a developer may convert high‑resolution JPEGs to PNG with TruecolorWithAlpha to preserve color fidelity while enabling transparency for later compositing.
 */