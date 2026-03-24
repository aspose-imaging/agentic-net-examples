using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Validate input files
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Output PNG path
        string pngOutputPath = @"C:\Images\combined.png";
        Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

        // Collect image sizes
        List<Size> sizes = new List<Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal layout)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create PNG canvas and merge images
        Source pngSource = new FileCreateSource(pngOutputPath, false);
        PngOptions pngOptions = new PngOptions { Source = pngSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the PNG image (bound to source)
            canvas.Save();
        }

        // Load the created PNG for embedding
        using (RasterImage pngImage = (RasterImage)Image.Load(pngOutputPath))
        {
            // Output EMZ path
            string emzOutputPath = @"C:\Images\combined.emz";
            Directory.CreateDirectory(Path.GetDirectoryName(emzOutputPath));

            // Create EMF canvas
            using (EmfImage emfCanvas = new EmfImage(canvasWidth, canvasHeight))
            {
                // Draw the PNG onto the EMF canvas
                Graphics graphics = new Graphics(emfCanvas);
                graphics.DrawImage(pngImage, new Rectangle(0, 0, pngImage.Width, pngImage.Height));

                // Save as compressed EMF (EMZ)
                EmfOptions emfOptions = new EmfOptions
                {
                    Compress = true,
                    Source = new FileCreateSource(emzOutputPath, false)
                };
                emfCanvas.Save(emzOutputPath, emfOptions);
            }
        }
    }
}