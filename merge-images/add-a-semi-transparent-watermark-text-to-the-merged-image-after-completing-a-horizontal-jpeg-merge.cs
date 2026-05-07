using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

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

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Prepare output options and source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 90 };

            // Create canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Merge images horizontally
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Add semi‑transparent watermark text
                Graphics graphics = new Graphics(canvas);
                string watermarkText = "Sample Watermark";
                Font font = new Font("Arial", 48);
                Color semiTransparentWhite = Color.FromArgb(128, 255, 255, 255);
                SolidBrush brush = new SolidBrush(semiTransparentWhite);
                // Position watermark near bottom‑right corner
                Point position = new Point(newWidth - 300, newHeight - 80);
                graphics.DrawString(watermarkText, font, brush, position);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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