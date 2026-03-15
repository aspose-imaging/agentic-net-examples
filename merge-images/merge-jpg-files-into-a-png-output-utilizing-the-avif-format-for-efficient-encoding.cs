using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputFiles = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Output PNG file path
        string outputPath = "merged.png";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create PNG canvas with bound file source
        Source pngSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            // Merge images horizontally onto the canvas
            int offsetX = 0;
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged PNG image
            canvas.Save();
        }

        // Attempt to utilize AVIF encoding (unsupported in Aspose.Imaging)
        try
        {
            // Placeholder for AVIF encoding logic
            // Since AVIF is not supported, we explicitly throw an exception
            throw new NotSupportedException("AVIF format is not supported by Aspose.Imaging.");
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"AVIF encoding skipped: {ex.Message}");
        }
    }
}