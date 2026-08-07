using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged_output.jpg";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Collect dimensions
            List<(int width, int height)> dims = new List<(int, int)>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    dims.Add((img.Width, img.Height));
                }
            }

            // Calculate canvas size for horizontal merge
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (var d in dims)
            {
                totalWidth += d.width;
                if (d.height > maxHeight) maxHeight = d.height;
            }

            // Create JPEG canvas bound to output file
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                // Merge images horizontally
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Add semi‑transparent watermark text
                Graphics graphics = new Graphics(canvas);
                Aspose.Imaging.Color watermarkColor = Aspose.Imaging.Color.FromArgb(128, 255, 255, 255); // 50% opacity white
                using (SolidBrush brush = new SolidBrush(watermarkColor))
                {
                    Font font = new Font("Arial", 48);
                    // Position watermark near bottom‑right corner
                    int x = canvas.Width - 300;
                    int y = canvas.Height - 60;
                    graphics.DrawString("Watermark", font, brush, new Point(x, y));
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
 * 1. When a marketing team needs to combine product photos side‑by‑side into a single JPEG banner and embed a semi‑transparent brand logo or copyright text to protect the assets.
 * 2. When an e‑commerce platform generates a horizontal collage of multiple product images and wants to overlay a faint promotional tagline so the watermark remains visible without obscuring details.
 * 3. When a real‑estate portal merges interior and exterior photos of a property into one JPEG panorama and adds a translucent “Confidential – For Internal Use” watermark for secure sharing.
 * 4. When a photo‑journalist creates a side‑by‑side comparison of before‑and‑after shots and applies a low‑opacity watermark to credit the photographer while preserving image clarity.
 * 5. When a document management system automatically stitches scanned pages into a single JPEG strip and appends a semi‑transparent “Company Confidential” text to enforce data protection policies.
 */