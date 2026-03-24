using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input JPG files
        string[] inputPaths = new[] { "input1.jpg", "input2.jpg", "input3.jpg" };
        // Intermediate SVGZ file
        string intermediateSvgzPath = "intermediate.svgz";
        // Final JPEG output
        string outputPath = "output.jpg";

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
        Directory.CreateDirectory(Path.GetDirectoryName(intermediateSvgzPath));

        // Collect sizes of all input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal stitching)
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create a temporary PNG canvas bound to a file
        Source pngSource = new FileCreateSource("temp_canvas.png", false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            // Draw each JPG onto the canvas side by side
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

            // Save the canvas as compressed SVGZ
            SvgRasterizationOptions svgRasterOptions = new SvgRasterizationOptions() { PageSize = canvas.Size };
            SvgOptions svgOptions = new SvgOptions()
            {
                VectorRasterizationOptions = svgRasterOptions,
                Compress = true
            };
            canvas.Save(intermediateSvgzPath, svgOptions);
        }

        // Load the SVGZ and export to final JPEG
        using (Image svgzImage = Image.Load(intermediateSvgzPath))
        {
            JpegOptions jpegOptions = new JpegOptions() { Quality = 90 };
            svgzImage.Save(outputPath, jpegOptions);
        }
    }
}