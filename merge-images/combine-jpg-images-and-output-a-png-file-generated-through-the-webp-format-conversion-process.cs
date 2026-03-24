using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG paths
        string[] inputPaths = new string[]
        {
            "C:\\Images\\image1.jpg",
            "C:\\Images\\image2.jpg",
            "C:\\Images\\image3.jpg"
        };
        // Output PNG path
        string outputPath = "C:\\Images\\merged_output.png";
        // Temporary WebP path
        string tempWebPPath = "C:\\Images\\temp_merge.webp";

        // Validate input files
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempWebPPath));

        // Collect sizes of input images
        List<Size> sizes = new List<Size>();
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

        // Create a WebP canvas
        Source webpSource = new FileCreateSource(tempWebPPath, false);
        WebPOptions webpOptions = new WebPOptions() { Source = webpSource, Lossless = true };
        using (WebPImage canvas = (WebPImage)Image.Create(webpOptions, canvasWidth, canvasHeight))
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
            // Save the merged image as WebP
            canvas.Save();
        }

        // Load the WebP image and save it as PNG
        using (WebPImage webp = new WebPImage(tempWebPPath))
        {
            webp.Save(outputPath, new PngOptions());
        }
    }
}