using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the vector image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Rasterize the vector image to a PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions rasterOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = vectorImage.Size,
                            BackgroundColor = Aspose.Imaging.Color.White
                        }
                    };
                    vectorImage.Save(ms, rasterOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply color overlay (e.g., semi‑transparent red)
                        Graphics graphics = new Graphics(raster);
                        SolidBrush overlayBrush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, 255, 0, 0));
                        graphics.FillRectangle(overlayBrush, raster.Bounds);

                        // Save the final PNG
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert an SVG icon to a PNG thumbnail and apply a semi‑transparent red overlay to match a brand color scheme.
 * 2. When a web application must generate PNG previews of vector diagrams with a uniform color tint for consistent UI theming.
 * 3. When an e‑commerce platform wants to rasterize product vector illustrations and add a translucent overlay to indicate a sale or discount status.
 * 4. When a reporting tool has to embed vector charts as PNG images with a colored overlay to highlight a specific data range.
 * 5. When a mobile app prepares PNG assets from SVG assets and applies a color filter to create a night‑mode version of the graphics.
 */