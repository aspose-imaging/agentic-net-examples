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
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };
        string outputPath = "output.jpg";

        try
        {
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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (FileStream fs = File.OpenRead(path))
                using (JpegImage img = new JpegImage(fs))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare JPEG options for the output image
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = outputSource,
                Quality = 90
            };

            // Create the output canvas
            using (JpegImage canvas = new JpegImage(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (FileStream fs = File.OpenRead(path))
                    using (JpegImage img = new JpegImage(fs))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image (canvas is already bound to the output source)
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
 * 1. When a developer needs to generate a single panoramic view by stitching multiple JPEG photos side‑by‑side for a web gallery, they can use this code to load each image with FileStream, merge them horizontally, and save the result.
 * 2. When an e‑commerce platform wants to display product variants together in one composite JPEG banner, the code can read the variant images, concatenate them horizontally, and output a high‑quality JPEG.
 * 3. When a reporting tool must combine several chart screenshots (saved as JPEG) into a single horizontal image for PDF export, this snippet handles loading, merging, and automatic disposal of streams.
 * 4. When a mobile app backend creates a side‑by‑side before‑and‑after comparison image from two JPEG files, the code merges them horizontally while managing resources with using blocks.
 * 5. When a digital signage system needs to concatenate multiple advertisement JPEGs into one wide image for a scrolling display, this example loads each file, merges them horizontally, and writes the combined JPEG.
 */