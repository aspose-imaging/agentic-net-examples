using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input directory and output file paths
            string inputDirectory = "InputImages";
            string outputPath = "Output\\merged.jpg";

            // Validate input directory existence
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Gather JPEG files from the input directory
            string[] imagePaths = Directory.GetFiles(inputDirectory, "*.jpg");
            if (imagePaths.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Cancellation token source for aborting the operation
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in imagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    continue;
                }

                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            if (sizes.Count == 0)
            {
                Console.Error.WriteLine("No valid images to process.");
                return;
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Size sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight) maxHeight = sz.Height;
            }

            // Prepare JPEG options with bound output source
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outputSource,
                Quality = 90
            };

            // Create the canvas image bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in imagePaths)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Merge operation cancelled.");
                        break;
                    }

                    if (!File.Exists(path))
                    {
                        Console.Error.WriteLine($"File not found: {path}");
                        continue;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image (already bound to output path)
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
 * 1. When a web service needs to generate a single panoramic JPEG from a batch of uploaded photos and must allow the request to be cancelled if the client disconnects.
 * 2. When a desktop application creates a side‑by‑side comparison image of product photos for a catalog and wants to abort the merge if the user clicks a “Cancel” button.
 * 3. When an automated reporting tool stitches together daily screenshot JPEGs into a single overview image but must stop processing if the scheduled job exceeds its time budget.
 * 4. When a mobile backend merges user‑generated JPEG thumbnails into a wide banner for social sharing and needs to respect a cancellation token to free server resources on timeout.
 * 5. When a batch image‑processing script combines scanned document JPEG pages into a single horizontal strip and should terminate early if a cancellation request is issued by an administrator.
 */