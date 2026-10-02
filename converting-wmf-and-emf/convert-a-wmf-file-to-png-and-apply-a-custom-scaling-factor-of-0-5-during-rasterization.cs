// HOW-TO: Convert WMF to PNG with 50% Scaling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.wmf";
        string outputPath = "output/output.png";

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
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                double scale = 0.5;
                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    PageWidth = newWidth,
                    PageHeight = newHeight,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                PngOptions pngOptions = new PngOptions
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
 * 1. When a developer needs to generate smaller thumbnail PNGs from legacy WMF vector drawings for web previews.
 * 2. When an application must batch‑process WMF icons and reduce their size by half before embedding them into a mobile app.
 * 3. When a reporting tool converts WMF charts to PNG images while applying a custom scale to fit a fixed‑size PDF page.
 * 4. When a document conversion service rasterizes WMF logos at 50 % of their original dimensions to save storage space.
 * 5. When a C# program creates PNG assets from WMF files with a white background and specific pixel dimensions for UI design.
 */
