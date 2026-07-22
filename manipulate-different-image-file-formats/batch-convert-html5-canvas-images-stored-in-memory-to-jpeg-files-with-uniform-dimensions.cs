using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Uniform output dimensions
            int targetWidth = 800;
            int targetHeight = 600;

            // Input HTML5 Canvas files (stored on disk for this example)
            List<string> inputPaths = new List<string>
            {
                "canvas1.html",
                "canvas2.html"
            };

            // Output directory
            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            int index = 0;
            foreach (string inputPath in inputPaths)
            {
                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Read the canvas data into memory
                byte[] canvasData = File.ReadAllBytes(inputPath);

                // Define output file path
                string outputPath = Path.Combine(outputDirectory, $"image_{index}.jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (MemoryStream memoryStream = new MemoryStream(canvasData))
                {
                    using (RasterImage image = (RasterImage)Image.Load(memoryStream))
                    {
                        // Resize to uniform dimensions
                        image.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                        // JPEG save options with bound source
                        Source source = new FileCreateSource(outputPath, false);
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Source = source,
                            Quality = 90
                        };

                        // Save the image as JPEG
                        image.Save(outputPath, jpegOptions);
                    }
                }

                index++;
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
 * 1. When a web application needs to archive user‑drawn HTML5 Canvas sketches as uniformly sized JPEG thumbnails for a gallery view.
 * 2. When an e‑learning platform converts in‑memory Canvas diagrams into JPEG assets of fixed width and height for inclusion in PDF course materials.
 * 3. When a reporting tool batch processes Canvas‑based charts stored as HTML files and generates JPEG images that fit a predefined layout in a dashboard.
 * 4. When a mobile backend receives Canvas image data via API, resizes it to 800×600 pixels, and saves it as JPEG files for efficient storage and delivery.
 * 5. When a content management system migrates legacy Canvas illustrations to JPEG format with consistent dimensions to ensure compatibility with legacy browsers.
 */