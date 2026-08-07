using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "merged_output.jpg";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect dimensions
            var dimensions = new List<(int Width, int Height)>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    dimensions.Add((img.Width, img.Height));
                }
            }

            // Calculate canvas size for horizontal merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var dim in dimensions)
            {
                canvasWidth += dim.Width;
                if (dim.Height > canvasHeight)
                    canvasHeight = dim.Height;
            }

            // Create JPEG canvas with background color
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                // Fill background
                Graphics graphics = new Graphics(canvas);
                using (SolidBrush brush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, canvasWidth, canvasHeight));
                }

                // Merge images horizontally
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image
                canvas.Save();
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
 * 1. When creating a product catalog page that combines multiple product photos side‑by‑side, a developer can use this code to merge JPEG images on a uniform background color before saving the final catalog image.
 * 2. When generating an email newsletter that displays a horizontal strip of promotional banners, this code ensures the banners are merged with a consistent background and output as a single JPEG for reliable email rendering.
 * 3. When building a social‑media collage where user‑uploaded JPEG pictures need to be aligned horizontally with a solid color backdrop to match the brand palette, the code provides the necessary canvas preparation and merging.
 * 4. When producing a PDF report that includes a combined header image made from several JPEG charts, a developer can apply a uniform background color and merge the charts horizontally before embedding the JPEG into the document.
 * 5. When an e‑commerce platform creates a combined thumbnail of related items for a product detail page, this code merges the JPEG thumbnails on a consistent background color to generate a single, optimized JPEG thumbnail.
 */