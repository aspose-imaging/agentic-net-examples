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
            // Hardcoded input JPEG file paths (simulating network streams)
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            // Hardcoded output path
            string outputPath = "output/merged.jpg";

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

            // Load images and calculate canvas size for vertical merge
            List<RasterImage> images = new List<RasterImage>();
            int canvasWidth = 0;
            int canvasHeight = 0;

            foreach (string inputPath in inputPaths)
            {
                RasterImage img = (RasterImage)Image.Load(inputPath);
                images.Add(img);
                canvasWidth = Math.Max(canvasWidth, img.Width);
                canvasHeight += img.Height;
            }

            // Create JPEG canvas with the calculated dimensions
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (RasterImage img in images)
                {
                    // Define destination rectangle on the canvas
                    Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                    // Copy pixel data from source image to canvas
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }

                // Save the bound canvas (output JPEG)
                canvas.Save();
            }

            // Dispose loaded images
            foreach (RasterImage img in images)
            {
                img.Dispose();
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
 * 1. When a web service receives multiple JPEG photos uploaded via HTTP and must combine them into a single vertically stacked image before returning it to the client.
 * 2. When an e‑commerce platform needs to merge product thumbnail JPEGs received from a remote CDN into a single catalog image for faster page loading.
 * 3. When a mobile app streams JPEG screenshots from different devices and wants to create a continuous vertical report image to send back to the server.
 * 4. When a digital signage system gathers JPEG advertisements from network sources and stacks them vertically into one JPEG banner for display on a large screen.
 * 5. When a document management workflow reads scanned JPEG pages from a network share, merges them into a single JPEG document, and stores the result for downstream processing.
 */