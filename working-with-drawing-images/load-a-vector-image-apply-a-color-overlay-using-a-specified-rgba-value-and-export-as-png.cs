// HOW-TO: Apply Semi Transparent Red Overlay to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Rasterize vector image to PNG in memory
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PngOptions rasterOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageSize = vectorImage.Size
                        }
                    };
                    vectorImage.Save(memoryStream, rasterOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                    {
                        // Apply color overlay (semi‑transparent red, RGBA: 128,255,0,0)
                        Graphics graphics = new Graphics(rasterImage);
                        using (SolidBrush overlayBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                        {
                            graphics.FillRectangle(overlayBrush, rasterImage.Bounds);
                        }

                        // Save the final PNG with overlay
                        PngOptions finalOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        rasterImage.Save(outputPath, finalOptions);
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
 * 1. When you need to brand an SVG logo with a company color by adding a translucent overlay before publishing as PNG.
 * 2. When generating thumbnails for vector graphics and want to highlight them with a semi‑transparent color filter.
 * 3. When creating watermarked product images by applying a colored overlay to vector artwork and exporting to PNG for web use.
 * 4. When converting SVG icons to PNG assets while ensuring a consistent color tint across all icons in a UI theme.
 * 5. When preprocessing vector drawings for print previews, adding a colored overlay to simulate ink coverage before saving as PNG.
 */
