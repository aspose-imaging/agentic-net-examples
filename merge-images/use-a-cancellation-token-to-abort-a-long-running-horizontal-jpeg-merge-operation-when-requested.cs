using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input JPEG files (modify paths as needed)
        string[] inputPaths = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Hard‑coded output file
        string outputPath = @"C:\Images\merged.jpg";

        // Verify that every input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a cancellation token source
        var cts = new System.Threading.CancellationTokenSource();

        // Start a background thread that waits for a key press to cancel the operation
        new System.Threading.Thread(() =>
        {
            Console.WriteLine("Press any key to cancel the merge operation...");
            Console.ReadKey();
            cts.Cancel();
        }).Start();

        // Collect sizes of all input images
        var sizes = new List<Aspose.Imaging.Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Prepare output source and JPEG options
        Source outSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outSource,
            Quality = 90 // Adjust quality as needed
        };

        // Create a bound JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;

            // Merge each image onto the canvas
            foreach (var path in inputPaths)
            {
                // Abort if cancellation was requested
                if (cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Merge operation cancelled by user.");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound image (no path needed because source is already set)
            canvas.Save();
        }

        Console.WriteLine("Horizontal JPEG merge completed successfully.");
    }
}