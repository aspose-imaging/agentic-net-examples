// HOW-TO: Abort Long Running Horizontal JPEG Merge With Cancellation Token In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            // Hardcoded input image paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output path
            string outputPath = "output/merged.jpg";

            // Validate each input file exists
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

            // Cancellation token source for aborting the merge
            var cts = new CancellationTokenSource();

            // Collect sizes of all input images
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

            // Create JPEG options with bound output source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90
            };

            // Create the output canvas bound to the file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;

                foreach (var path in inputPaths)
                {
                    // Check for cancellation request
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation cancelled.");
                        return;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image (no path needed)
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
 * 1. When an application needs to combine several high‑resolution JPEG photos side‑by‑side into a single panorama and must allow the user to cancel the operation if it takes too long.
 * 2. When a server‑side service generates composite product images from multiple JPEG assets and requires a cancellation token to stop processing on timeout or client disconnect.
 * 3. When a desktop tool processes large batches of JPEG screenshots into a horizontal strip for reporting and needs to abort the merge when the user presses a cancel button.
 * 4. When integrating Aspose.Imaging into a web API that stitches user‑uploaded JPEGs together and must respect cancellation requests from ASP.NET request tokens.
 * 5. When performing a long‑running image merge in a background worker and you want to free resources promptly if the operation is cancelled due to low memory or shutdown.
 */
