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
        // Hardcoded input JPEG file paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output JPEG file path
        string outputPath = "output.jpg";

        try
        {
            // Validate each input file exists
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

            // Determine canvas size: max width and sum of heights
            int maxWidth = 0;
            int totalHeight = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    if (img.Width > maxWidth)
                        maxWidth = img.Width;
                    totalHeight += img.Height;
                }
            }

            // Create JPEG options with bound source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 100
            };

            // Create the output canvas bound to the file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                for (int i = 0; i < inputPaths.Length; i++)
                {
                    string path = inputPaths[i];
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Copy pixels of the current image onto the canvas
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                        offsetY += img.Height;
                    }

                    // Log progress percentage after each image is added
                    int percent = (i + 1) * 100 / inputPaths.Length;
                    Console.WriteLine($"Progress: {percent}%");
                }

                // Save the bound canvas (no need to pass path again)
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
 * 1. When a developer needs to combine multiple product photos into a single tall JPEG for an e‑commerce catalog while showing a progress percentage after each image is added.
 * 2. When building a C# utility that stitches scanned pages of a document into one continuous JPEG and wants to log the merge progress for user feedback.
 * 3. When creating an automated report generator that merges daily screenshot JPEGs into a vertical timeline image and needs to track the percentage completed during the merge.
 * 4. When developing a photo‑journalism app that concatenates a series of event images into a single JPEG banner and displays real‑time progress updates to the editor.
 * 5. When implementing a server‑side image processing pipeline that assembles advertisement banner slices into a full‑width JPEG and logs each step’s progress for monitoring and debugging.
 */