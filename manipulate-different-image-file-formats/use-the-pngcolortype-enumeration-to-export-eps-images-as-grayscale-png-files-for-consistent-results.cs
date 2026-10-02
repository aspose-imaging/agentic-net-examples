// HOW-TO: Export EPS to Grayscale PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.Grayscale,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                })
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
 * 1. When you need to convert vector EPS artwork into a lightweight grayscale PNG for web thumbnails.
 * 2. When you must ensure consistent color output across platforms by forcing PNG to grayscale during batch processing.
 * 3. When generating print‑ready preview images from EPS files while preserving only luminance information.
 * 4. When creating PDF or document pipelines that require EPS pages converted to grayscale PNG for OCR preprocessing.
 * 5. When automating a CI/CD build that transforms design assets (EPS) into grayscale PNGs for documentation or UI assets.
 */
