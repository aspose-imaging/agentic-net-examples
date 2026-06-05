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
            // Hardcoded input and output paths
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output.jpg";

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

            // Determine canvas size (horizontal merge)
            int totalWidth = 0;
            int maxHeight = 0;
            const int loadBufferHint = 50; // MB

            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path, new LoadOptions { BufferSizeHint = loadBufferHint }))
                {
                    totalWidth += img.Width;
                    if (img.Height > maxHeight)
                        maxHeight = img.Height;
                }
            }

            // Create output JPEG canvas with bound source
            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = outSource,
                Quality = 90
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path, new LoadOptions { BufferSizeHint = loadBufferHint }))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
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
 * 1. When a web service needs to combine multiple user‑uploaded JPEG photos into a single panoramic image without exhausting server memory, developers can use this code with ImageLoadOptions.BufferSizeHint to limit memory usage during the horizontal merge.
 * 2. When a desktop photo‑collage application must stitch together high‑resolution JPEG files into a wide‑format print layout on machines with limited RAM, the example shows how to load each image with a buffer hint and create a merged JPEG canvas.
 * 3. When an automated batch‑processing script generates composite product images from several JPEG assets for an e‑commerce catalog, using ImageLoadOptions helps keep the process scalable by controlling memory consumption while merging images side‑by‑side.
 * 4. When a mobile‑oriented backend service creates side‑by‑side comparison images from uploaded JPEG screenshots, the code demonstrates how to safely load each source image with a memory buffer limit before assembling the final JPEG output.
 * 5. When a digital signage system needs to concatenate multiple advertisement JPEGs into a single wide banner on a low‑end Windows server, developers can apply the shown ImageLoadOptions technique to merge the images horizontally while staying within the server’s memory constraints.
 */