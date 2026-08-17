// HOW-TO: Merge Two JPEG Images Vertically With 4:2:0 Subsampling In C# (Aspose.Imaging for .NET)
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            string[] inputPaths = new string[] { inputPath1, inputPath2 };
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Create JPEG options with 4:2:0 subsampling
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90,
                HorizontalSampling = new byte[] { 2, 1, 1 },
                VerticalSampling = new byte[] { 2, 1, 1 }
            };

            // Create bound JPEG canvas using Image.Create
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the merged image (bound image, so just Save())
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
 * 1. When you need to combine multiple JPEG photos into a single tall image while keeping the output file size low by applying 4:2:0 chroma subsampling.
 * 2. When generating printable photo strips or receipts that require vertically stacked JPEGs with consistent width and optimized compression.
 * 3. When creating a web‑ready collage of product images where the combined JPEG must meet bandwidth constraints through reduced chroma resolution.
 * 4. When automating the preparation of scanned document pages saved as JPEGs into one continuous page without sacrificing visual quality.
 * 5. When building a C# service that merges user‑uploaded JPEG avatars into a single banner and wants to use Aspose.Imaging to control JPEG quality and subsampling.
 */
