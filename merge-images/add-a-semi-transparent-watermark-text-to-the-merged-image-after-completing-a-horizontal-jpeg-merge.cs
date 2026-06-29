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
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Create output file source and JPEG options
            Source fileSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = fileSource,
                Quality = 90
            };

            // Create canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
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

                // Add semi‑transparent watermark text
                Graphics graphics = new Graphics(canvas);
                Font font = new Font("Arial", 36);
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255)); // 50% transparent white
                PointF position = new PointF(canvasWidth - 250, canvasHeight - 50); // bottom‑right corner
                graphics.DrawString("Watermark", font, brush, position);

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
 * 1. When a photographer wants to combine multiple product photos into a single horizontal banner and embed a semi‑transparent brand logo as a watermark before publishing online.
 * 2. When an e‑commerce platform needs to merge several catalog images side‑by‑side and add a faint copyright notice to protect the images from unauthorized reuse.
 * 3. When a marketing team creates a composite promotional JPEG for social media and wants to overlay a translucent campaign tagline across the merged image.
 * 4. When a document management system automatically stitches scanned pages horizontally and applies a light watermark with the company name for compliance auditing.
 * 5. When a real‑estate website merges property interior shots into a panoramic view and adds a semi‑transparent “Sample” watermark to indicate preview status before the final purchase.
 */