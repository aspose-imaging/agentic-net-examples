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
        try
        {
            // Hardcoded input JPEG files and output path
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.jpg";

            // Verify each input file exists
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

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions (horizontal merge, vertical centering)
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas bound to the output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Center image vertically on the canvas
                        int offsetY = (canvasHeight - img.Height) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
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
 * 1. When building a product catalog website that needs to display multiple product photos side‑by‑side in a single JPEG banner, a developer can use this code to horizontally merge the images and vertically center each picture on the canvas.
 * 2. When generating printable marketing flyers where several promotional JPEG images must appear in a balanced row, the code provides a quick way to create a high‑quality merged JPEG with all pictures centered vertically.
 * 3. When creating a slideshow thumbnail strip that combines several JPEG frames into one image for faster loading, developers can employ this routine to stitch the frames horizontally while keeping each frame centered on the common canvas.
 * 4. When automating the preparation of social‑media carousel posts that require a single JPEG containing multiple images aligned in a row, the code ensures each image is centered vertically and the final composition meets the platform’s size constraints.
 * 5. When developing a desktop application that assembles scanned JPEG pages into a single panoramic view, this snippet lets developers merge the pages horizontally and maintain vertical centering to produce a seamless composite image.
 */