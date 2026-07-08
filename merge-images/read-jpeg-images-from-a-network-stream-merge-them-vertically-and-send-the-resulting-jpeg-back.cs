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
            // Hardcoded input JPEG file paths (simulating network streams)
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            // Hardcoded output path
            string outputPath = "merged.jpg";

            // Validate each input file exists
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
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Prepare JPEG options with bound source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90
            };

            // Create JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
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

                // Save the bound canvas (no need to pass path/options again)
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
 * 1. When a web service needs to combine multiple user‑uploaded JPEG photos into a single tall image for a printable photo collage, it can read the JPEG streams, merge them vertically, and return the merged JPEG.
 * 2. When an e‑commerce platform generates a product‑detail banner by stacking several JPEG thumbnails received from a CDN, the code can assemble them into one image before sending it to the front‑end.
 * 3. When a digital signage system receives separate JPEG advertisements over a network and must display them as a continuous vertical scroll, the developer can use this code to merge the streams into one JPEG file.
 * 4. When a mobile app uploads scanned JPEG pages to a server that needs to create a single PDF‑like image by stacking the pages vertically, the server can apply this code to produce the combined JPEG.
 * 5. When a document‑management workflow receives individual JPEG pages from different scanners via network streams and must return a single merged JPEG for archival, this code provides the necessary processing.
 */