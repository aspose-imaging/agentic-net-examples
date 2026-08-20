// HOW-TO: Log Progress While Vertically Merging Multiple JPEG Images in C# (Aspose.Imaging for .NET)
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
            string outputPath = "merged_output.jpg";

            // Validate each input file
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Collect sizes of all input images
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

            // Create JPEG canvas bound to output file
            Source fileSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = fileSource, Quality = 100 };
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
 * 1. When you need to combine several scanned JPEG pages into a single long image and display the merge percentage in the console.
 * 2. When generating a vertical sprite sheet from multiple product photos for a web gallery and want to log the processing progress.
 * 3. When creating a tall banner from separate JPEG sections for digital signage and need to monitor the merge progress in a C# application.
 * 4. When preprocessing image datasets for machine learning by stitching individual JPEG samples into one file while tracking completion rate.
 * 5. When automating the assembly of screenshot fragments into a single JPEG report and providing real‑time progress updates to the user.
 */
