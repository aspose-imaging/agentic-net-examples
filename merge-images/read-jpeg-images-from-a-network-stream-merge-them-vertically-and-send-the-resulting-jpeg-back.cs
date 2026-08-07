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
            string inputPath1 = "input1.jpg";
            string inputPath2 = "input2.jpg";
            string outputPath = "output.jpg";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Collect sizes of input images
            List<Size> sizes = new List<Size>();
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            {
                sizes.Add(img1.Size);
            }
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            {
                sizes.Add(img2.Size);
            }

            // Calculate canvas dimensions for vertical merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                if (sz.Width > newWidth) newWidth = sz.Width;
                newHeight += sz.Height;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG options with bound source
            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outSource,
                Quality = 90
            };

            // Create canvas image
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetY = 0;
                string[] inputs = new[] { inputPath1, inputPath2 };
                foreach (var inPath in inputs)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inPath))
                    {
                        // Define where to place the current image on the canvas
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        // Copy pixel data onto the canvas
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound canvas (output already bound to source)
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
 * 1. When a web service must combine multiple JPEG photos received over HTTP into a single vertical image before returning it to the client.
 * 2. When an e‑commerce platform needs to merge a product thumbnail JPEG and a high‑resolution banner JPEG streamed from a CDN into one image for a mobile app.
 * 3. When a document‑management system receives scanned page JPEGs from a network scanner and must stitch them vertically into a single JPEG for archiving.
 * 4. When a social‑media scheduler aggregates user‑uploaded JPEG stories into a vertical collage that is sent back as a single JPEG via an API.
 * 5. When a reporting tool pulls chart JPEGs from remote services, stacks them vertically, and delivers the combined JPEG as an email attachment.
 */