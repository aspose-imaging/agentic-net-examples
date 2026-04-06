using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Validate each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for horizontal stitching
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Define output paths
        string pngOutputPath = Path.Combine("output", "combined.png");
        string emzOutputPath = Path.Combine("output", "combined.emz");

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(emzOutputPath));

        // Create PNG canvas bound to the output file
        Source pngSource = new FileCreateSource(pngOutputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };
        using (Image pngCanvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            // Merge JPG images horizontally onto the PNG canvas
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    ((RasterImage)pngCanvas).SaveArgb32Pixels(bounds, pixels);
                    offsetX += img.Width;
                }
            }
            // Save the bound PNG image
            pngCanvas.Save();
        }

        // Load the created PNG image
        using (RasterImage pngImage = (RasterImage)Image.Load(pngOutputPath))
        {
            // Create EMF canvas bound to the EMZ output file with compression
            Source emfSource = new FileCreateSource(emzOutputPath, false);
            EmfOptions emfOptions = new EmfOptions() { Source = emfSource, Compress = true };
            using (Image emfCanvas = Image.Create(emfOptions, pngImage.Width, pngImage.Height))
            {
                // Draw the PNG onto the EMF canvas
                Graphics graphics = new Graphics(emfCanvas);
                graphics.DrawImage(pngImage, 0, 0);
                // Save the bound EMF (compressed as EMZ)
                emfCanvas.Save();
            }
        }
    }
}