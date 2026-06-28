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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "output/merged.jpg";

            // Validate each input file
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

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create JPEG canvas with bound source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                for (int i = 0; i < inputPaths.Length; i++)
                {
                    string path = inputPaths[i];
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }

                    // Log progress percentage
                    int percent = (i + 1) * 100 / inputPaths.Length;
                    Console.WriteLine($"Progress: {percent}%");
                }

                // Save the bound canvas
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
 * 1. When building a photo‑album generator that combines multiple portrait‑oriented JPEG files into a single scrolling page, a developer can use this C# code to vertically stitch the images while logging the progress percentage after each addition.
 * 2. When creating a batch tool that consolidates scanned document pages saved as JPEGs into one long image for easier printing, the vertical merge with progress logging helps track each page as it is added to the canvas.
 * 3. When developing a web service that receives user‑uploaded JPEG screenshots and returns a single combined image for reporting, this code provides a .NET solution to merge them vertically and report the merge status in real time.
 * 4. When implementing an automated archival system that merges daily camera snapshots (JPEG) into a single timeline image, the progress log informs operators how many snapshots have been processed and what percentage is complete.
 * 5. When designing a desktop utility that assembles product‑catalog photos (JPEG) into a continuous vertical strip for print layout, the code calculates the canvas size, merges the images, and logs the percentage completed after each image is added.
 */