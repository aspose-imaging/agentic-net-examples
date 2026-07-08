using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
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
 * 1. When a developer needs to convert an ODG (OpenDocument Graphics) file to a high‑resolution PNG for web preview, they can use VectorRasterizationOptions to set the page size and background before saving with PngOptions.
 * 2. When generating thumbnail images from ODG drawings for a file‑manager UI, the code rasterizes the vector content at a defined resolution and outputs a PNG that browsers can display instantly.
 * 3. When exporting vector‑based ODG diagrams as raster PNGs for inclusion in PDF reports, the developer sets the rasterization options (width, height, background) and saves the image using Aspose.Imaging’s PngOptions.
 * 4. When preparing ODG artwork for email attachments where only PNG is supported, the code loads the ODG, applies a white background, defines the raster resolution, and saves the result as a PNG file.
 * 5. When automating a batch conversion of ODG assets to PNG in a C# build pipeline, the developer uses VectorRasterizationOptions to control resolution and page dimensions, then saves each file with PngOptions for consistent image output.
 */