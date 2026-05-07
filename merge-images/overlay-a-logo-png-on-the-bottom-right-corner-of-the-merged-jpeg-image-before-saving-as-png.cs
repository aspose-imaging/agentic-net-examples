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
            // Input JPEG files and logo PNG
            string[] inputPaths = { "input1.jpg", "input2.jpg" };
            string logoPath = "logo.png";
            string outputPath = "output.png";

            // Validate input JPEG files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Validate logo file
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of input images
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create PNG canvas bound to output file
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = outSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Merge input JPEGs side by side
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Load logo PNG
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    int posX = canvas.Width - logo.Width;
                    int posY = canvas.Height - logo.Height;
                    var logoBounds = new Rectangle(posX, posY, logo.Width, logo.Height);
                    canvas.SaveArgb32Pixels(logoBounds, logo.LoadArgb32Pixels(logo.Bounds));
                }

                // Save the final PNG image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}