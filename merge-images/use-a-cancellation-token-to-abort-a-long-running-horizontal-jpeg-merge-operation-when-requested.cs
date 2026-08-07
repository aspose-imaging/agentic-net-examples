using System;
using System.IO;
using System.Collections.Generic;
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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
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

            // Cancellation token source (could be triggered elsewhere)
            var cts = new System.Threading.CancellationTokenSource();
            var token = cts.Token;

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
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

            // Create output JPEG canvas bound to the file
            FileCreateSource outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation cancelled.");
                        return;
                    }

                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        canvas.SaveArgb32Pixels(bounds, pixels);
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
 * 1. When generating a panoramic view from multiple high‑resolution JPEG photos in a web service, a developer can use this code with a cancellation token to stop the merge if the client aborts the request.
 * 2. When a desktop batch‑processing tool stitches together scanned document pages into a single JPEG and needs to remain responsive, the cancellation token allows the user to cancel the operation mid‑process.
 * 3. When an automated reporting system creates a side‑by‑side comparison image of product screenshots and must respect a timeout policy, the token can abort the long‑running merge to avoid blocking the scheduler.
 * 4. When a cloud‑based image‑hosting platform builds a horizontal collage of user‑uploaded JPEGs and wants to free resources if the operation exceeds a cost‑limit, the cancellation token provides a safe way to terminate the task.
 * 5. When a mobile app assembles a wide‑angle JPEG from several camera captures and needs to react to a loss of network connectivity, the cancellation token can instantly halt the merge to preserve battery life.
 */