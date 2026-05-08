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
                "Input\\image1.jpg",
                "Input\\image2.jpg",
                "Input\\image3.jpg"
            };
            string outputPath = "Output\\merged.jpg";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions (vertical merge with 10‑pixel padding)
            int padding = 10;
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height) + padding * (inputPaths.Length - 1);

            // Create JPEG canvas bound to the output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = source, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(options, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (JpegImage img = (JpegImage)Image.Load(path))
                    {
                        // Define destination rectangle on the canvas
                        Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                        // Copy pixel data
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        // Move offset down, adding padding after each image except the last
                        offsetY += img.Height + padding;
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