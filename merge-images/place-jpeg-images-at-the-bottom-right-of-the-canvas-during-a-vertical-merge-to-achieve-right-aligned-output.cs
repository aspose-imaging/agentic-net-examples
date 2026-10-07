// HOW-TO: Vertically Merge JPEG Images with Right Alignment in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output/output.jpg";

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        int offsetX = canvasWidth - img.Width;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }
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
 * 1. When you need to combine product photos of different widths into a single tall image for a catalog, keeping each photo aligned to the right edge.
 * 2. When generating a printable receipt that stacks scanned JPEG receipts of varying sizes while maintaining right‑aligned layout for consistent margins.
 * 3. When creating a social‑media story image that vertically stitches user‑uploaded JPEGs, ensuring each picture lines up on the right side of the canvas.
 * 4. When preparing a PDF thumbnail strip by merging page‑preview JPEGs of different dimensions, aligning them to the right to match the document’s layout.
 * 5. When building an automated email attachment that concatenates multiple JPEG screenshots into one image, placing each screenshot at the bottom‑right to preserve a clean right‑aligned appearance.
 */
