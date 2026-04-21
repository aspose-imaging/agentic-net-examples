using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input JPEG files and logo PNG
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            string logoPath = "logo.png";
            string outputPath = "Output\\merged.png";

            // Validate existence of all input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas size for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create a PNG canvas bound to the output file
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Merge JPEG images side by side
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Overlay the logo at bottom‑right corner
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    int posX = canvas.Width - logo.Width;
                    int posY = canvas.Height - logo.Height;
                    Rectangle logoRect = new Rectangle(posX, posY, logo.Width, logo.Height);
                    canvas.SaveArgb32Pixels(logoRect, logo.LoadArgb32Pixels(logo.Bounds));
                }

                // Save the bound canvas (output path already set in options)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}