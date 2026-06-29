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
        // Hardcoded input and output paths
        string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
        string outputPath = "output.jpg";

        try
        {
            // Validate input files and collect their sizes
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (JpegImage img = new JpegImage(fs))
                    {
                        sizes.Add(img.Size);
                    }
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Prepare JPEG options with bound output source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 100
            };

            // Create the output canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (JpegImage img = new JpegImage(fs))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }
                }

                // Save the merged image (output is already bound)
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
 * 1. When a developer needs to combine multiple product photos stored as JPEG files into a single side‑by‑side banner for an e‑commerce website, they can use this code to load the images with FileStream, merge them horizontally, and save the result.
 * 2. When an automated reporting tool must generate a composite thumbnail strip from a series of JPEG screenshots, the snippet demonstrates how to read each file, calculate the canvas size, and create the merged image in C#.
 * 3. When a photo‑gallery application wants to create a panoramic preview by stitching several portrait‑oriented JPEG images together without loading them all into memory at once, the example shows the proper use of using blocks to manage streams.
 * 4. When a batch‑processing script has to ensure that output directories exist and write a high‑quality JPEG collage from user‑uploaded images, this code illustrates how to configure JpegOptions and safely write the file.
 * 5. When a developer is building a digital signage system that needs to display multiple advertisement JPEGs side by side on a single screen, the sample provides a straightforward way to merge the images horizontally while automatically closing the streams.
 */