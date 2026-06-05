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
            string outputPath = "merged.jpg";

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

            // Cancellation token source (can be triggered elsewhere)
            var cts = new System.Threading.CancellationTokenSource();

            // Collect sizes of all input images
            var sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create output source and JPEG options
            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outSource,
                Quality = 90
            };

            // Create bound JPEG canvas
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
                        var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image (output path already set in options)
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
 * 1. When a photo‑gallery web service needs to generate a single panoramic preview from several user‑uploaded JPEGs and must allow the request to be cancelled if the client disconnects.
 * 2. When an automated reporting tool combines multiple chart images into a wide JPEG banner for a PDF report, using Aspose.Imaging for .NET and a cancellation token to stop the merge if the report generation times out.
 * 3. When a desktop application creates a side‑by‑side product comparison image from three product photos and wants to abort the operation if the user presses a “Cancel” button during the long‑running merge.
 * 4. When a cloud‑based image‑processing pipeline stitches together scanned document pages into a single JPEG strip and needs to respect cancellation signals from the orchestration service.
 * 5. When a batch script processes thousands of advertisement banners by horizontally merging JPEG assets and employs a cancellation token to gracefully halt the job when system resources become constrained.
 */