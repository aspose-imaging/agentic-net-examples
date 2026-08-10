// HOW-TO: Add Semi Transparent Watermark to Horizontally Merged JPEG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            // Hardcoded input image paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Validate each input file
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Hardcoded output path
            string outputPath = "merged_output.jpg";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas with bound source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 90
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                // Merge images side by side
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

                // Add semi‑transparent watermark text
                Graphics graphics = new Graphics(canvas);
                Font font = new Font("Arial", 48);
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255)); // 50% transparent white
                // Position watermark near bottom‑right corner
                PointF position = new PointF(canvas.Width - 250, canvas.Height - 70);
                graphics.DrawString("Sample Watermark", font, brush, position);

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
 * 1. When you need to combine product photos side‑by‑side and brand them with a translucent logo before publishing online.
 * 2. When generating a single panoramic view from multiple camera shots and want to overlay copyright text without obscuring the image.
 * 3. When creating a printable catalog page that stitches several JPEGs together and requires a faint watermark for intellectual‑property protection.
 * 4. When automating batch processing of scanned documents, merging them horizontally and adding a semi‑transparent disclaimer for compliance.
 * 5. When developing a web service that returns a combined JPEG banner with a subtle watermark to identify the source application.
 */
