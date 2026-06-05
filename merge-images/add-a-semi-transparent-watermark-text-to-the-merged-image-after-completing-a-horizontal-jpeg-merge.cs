using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "output/merged_output.jpg";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas bound to the output file
            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Merge images horizontally
                int offsetX = 0;
                foreach (var path in inputPaths)
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
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255));
                PointF position = new PointF(canvas.Width - 250, canvas.Height - 50);
                graphics.DrawString("Sample Watermark", font, brush, position);

                // Save the merged image (bound to the file)
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
 * 1. When creating a product catalog, a developer can merge multiple product photos horizontally into a single JPEG and overlay a semi‑transparent brand watermark to protect intellectual property.
 * 2. When generating a social media collage, a developer may need to stitch user‑uploaded JPEG images side‑by‑side and add a faint promotional text watermark before publishing.
 * 3. When preparing a printable banner, a developer can combine several high‑resolution JPEG panels into one wide image and embed a translucent copyright notice using Aspose.Imaging for .NET.
 * 4. When automating a real‑estate listing, a developer might merge room‑by‑room JPEG photos into a panoramic view and apply a semi‑transparent agency logo as a watermark.
 * 5. When building an e‑learning platform, a developer can concatenate diagram JPEGs horizontally and add a light watermark with the course title to deter unauthorized distribution.
 */