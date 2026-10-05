// HOW-TO: Crop EMF File to PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image emfImage = Image.Load(inputPath))
            {
                int width = emfImage.Width;
                int height = emfImage.Height;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(emfImage, new Rectangle(0, 0, width, height));

                    // Define crop bounds (example: inset by 10 pixels)
                    int cropX = 10;
                    int cropY = 10;
                    int cropWidth = width - 20;
                    int cropHeight = height - 20;

                    if (cropWidth > 0 && cropHeight > 0)
                    {
                        Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                        canvas.Crop(cropRect);
                    }

                    canvas.Save();
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
 * 1. When you need to convert vector EMF graphics to raster PNG for web display while removing unwanted borders.
 * 2. When you must generate thumbnail images from EMF drawings by cropping a fixed margin before saving.
 * 3. When an automated report generator creates EMF charts that must be trimmed and stored as PNG files for email attachments.
 * 4. When a batch processing tool has to standardize the size of EMF assets by cropping and converting them to PNG for a mobile app.
 * 5. When a legacy Windows application exports diagrams as EMF and you need to programmatically extract a centered portion and save it as PNG for documentation.
 */
