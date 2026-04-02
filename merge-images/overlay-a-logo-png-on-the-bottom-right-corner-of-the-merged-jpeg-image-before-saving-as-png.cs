using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input JPEG images to merge
        string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
        // Logo PNG to overlay
        string logoPath = "logo.png";
        // Output PNG path
        string outputPath = "merged_with_logo.png";

        // Validate input JPEG files
        foreach (string path in inputPaths)
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
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal merge)
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create output source and PNG options
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outputSource };

        // Create canvas image
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            // Merge input images horizontally
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Load logo image
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Position logo at bottom-right corner
                int posX = canvas.Width - logo.Width;
                int posY = canvas.Height - logo.Height;
                Aspose.Imaging.Rectangle logoBounds = new Aspose.Imaging.Rectangle(posX, posY, logo.Width, logo.Height);
                canvas.SaveArgb32Pixels(logoBounds, logo.LoadArgb32Pixels(logo.Bounds));
            }

            // Save the bound canvas
            canvas.Save();
        }
    }
}