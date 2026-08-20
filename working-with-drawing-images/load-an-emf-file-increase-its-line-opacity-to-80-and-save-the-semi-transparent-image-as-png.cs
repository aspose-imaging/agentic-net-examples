// HOW-TO: Convert EMF to PNG with 80% Opacity Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
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

        try
        {
            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for EMF to PNG conversion
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized PNG to a temporary memory stream
                using (var tempStream = new MemoryStream())
                {
                    emfImage.Save(tempStream, pngOptions);
                    tempStream.Position = 0;

                    // Load the rasterized PNG for pixel manipulation
                    using (RasterImage pngImage = (RasterImage)Image.Load(tempStream))
                    {
                        // Increase opacity of each pixel to 80%
                        // (multiply existing alpha by 0.8)
                        for (int y = 0; y < pngImage.Height; y++)
                        {
                            for (int x = 0; x < pngImage.Width; x++)
                            {
                                var color = pngImage.GetPixel(x, y);
                                byte newAlpha = (byte)(color.A * 0.8);
                                var newColor = Aspose.Imaging.Color.FromArgb(newAlpha, color.R, color.G, color.B);
                                pngImage.SetPixel(x, y, newColor);
                            }
                        }

                        // Save the final PNG with adjusted opacity
                        pngImage.Save(outputPath);
                    }
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
 * 1. When you need to embed a vector graphic from an EMF file into a web page that only supports PNG images, but want the graphic to appear semi‑transparent.
 * 2. When generating reports that combine EMF charts with other raster images and require the charts to have a uniform 80 % opacity for visual consistency.
 * 3. When creating slide decks where EMF logos must be converted to PNG with reduced opacity to act as watermarks behind text.
 * 4. When processing batch conversions of legacy EMF assets for a mobile app, and you need each PNG output to be partially transparent to blend with background colors.
 * 5. When automating a design workflow that rasterizes EMF icons to PNG and applies 80 % opacity so they can be layered over UI components without fully obscuring them.
 */
