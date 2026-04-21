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
            string inputPath1 = "input1.jpg";
            string inputPath2 = "input2.jpg";
            string outputPath = "output/merged.jpg";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List of input image paths
            string[] imagePaths = new[] { inputPath1, inputPath2 };

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions with padding
            int padding = 20;
            int maxWidth = sizes.Max(s => s.Width);
            int totalHeight = sizes.Sum(s => s.Height);
            int canvasWidth = maxWidth + padding * 2;
            int canvasHeight = totalHeight + padding * (sizes.Count + 1); // top, bottom and between images

            // Create JPEG canvas bound to output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = padding;
                foreach (string path in imagePaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int offsetX = (canvasWidth - img.Width) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height + padding;
                    }
                }

                // Save the bound image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}