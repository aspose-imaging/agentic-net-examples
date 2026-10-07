// HOW-TO: Rasterize CMX Vector to PNG at Specific DPI Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.ResolutionSettings = new ResolutionSetting(96, 96);
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to display legacy CorelDRAW CMX artwork on a website, you can rasterize it to a PNG at web‑friendly DPI.
 * 2. When converting vector logos stored in CMX format to high‑quality PNG thumbnails for product catalogs, this code automates the process in C#.
 * 3. When generating printable previews of CMX diagrams at a consistent resolution for a document management system, you can use Aspose.Imaging to rasterize them.
 * 4. When building an automated pipeline that transforms batch CMX files into web‑optimized PNG images with a white background, this snippet provides the necessary steps.
 * 5. When integrating CMX support into a .NET application that must serve images at 96 dpi to match other UI assets, the code shows how to load, rasterize, and save the files.
 */
