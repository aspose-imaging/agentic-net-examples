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
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output.jpg";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Size> sizeList = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizeList.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizeList)
            {
                if (sz.Width > newWidth) newWidth = sz.Width;
                newHeight += sz.Height;
            }

            // Prepare JPEG options with 4:2:0 subsampling
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = src,
                Quality = 90,
                HorizontalSampling = new byte[] { 2, 1, 1 }, // 4:2:0
                VerticalSampling = new byte[] { 2, 1, 1 }    // 4:2:0
            };

            // Create bound JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetY = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When a developer needs to combine multiple portrait‑oriented JPEG photos into a single vertical strip for a web gallery while keeping the file size low, they can use this code to merge the images and apply 4:2:0 subsampling.
 * 2. When building an automated receipt‑scanning pipeline that stacks scanned JPEG pages into one document, the code helps create a vertically merged image with reduced bandwidth by setting JPEGOptions subsampling to 4:2:0.
 * 3. When generating printable photo collages for e‑commerce product listings, a developer can merge individual product images vertically and use 4:2:0 chroma subsampling to meet size limits without noticeable quality loss.
 * 4. When creating a continuous scrolling banner for a mobile app, the code allows the developer to stitch several banner segments together and compress the result with JPEGOptions quality 90 and 4:2:0 sampling for faster download.
 * 5. When implementing a server‑side image‑processing service that consolidates user‑uploaded JPEG screenshots into a single tall image, the code ensures the output JPEG uses 4:2:0 subsampling to reduce storage costs while preserving visual fidelity.
 */