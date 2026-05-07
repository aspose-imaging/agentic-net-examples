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
            string[] inputPaths = new[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "Output/merged_with_border.jpg";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Define border thickness
            int border = 5;

            // Calculate canvas dimensions including border
            int canvasWidth = sizes.Sum(s => s.Width) + 2 * border;
            int canvasHeight = sizes.Max(s => s.Height) + 2 * border;

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG canvas bound to the output file
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = src, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                // Fill background with white (border color)
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Merge images horizontally inside the border
                int offsetX = border;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle destRect = new Rectangle(offsetX, border, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the final image (bound canvas)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}