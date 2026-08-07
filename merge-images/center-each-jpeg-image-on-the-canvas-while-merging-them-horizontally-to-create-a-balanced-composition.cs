using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "output/merged.jpg";

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

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Create output source and JPEG options
            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            // Create bound JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int offsetY = (canvasHeight - img.Height) / 2; // Center vertically
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
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
 * 1. When a developer needs to generate a single side‑by‑side product catalog page by centering multiple JPEG product photos on a horizontal canvas using Aspose.Imaging for .NET.
 * 2. When an e‑commerce site wants to create a combined promotional banner that aligns different‑size JPEG banners centrally in a horizontal layout with C# and Aspose.Imaging.
 * 3. When a photo‑sharing app must stitch user‑uploaded JPEG snapshots into a balanced panoramic strip, ensuring each image is vertically centered on the canvas via Aspose.Imaging image processing.
 * 4. When a reporting tool has to embed several JPEG charts side by side in a PDF export, first merging them horizontally with centered alignment using C# and Aspose.Imaging before PDF conversion.
 * 5. When a digital signage system prepares a rotating slideshow that combines multiple JPEG advertisements into a single horizontally aligned image, centering each asset on the canvas with Aspose.Imaging for .NET.
 */