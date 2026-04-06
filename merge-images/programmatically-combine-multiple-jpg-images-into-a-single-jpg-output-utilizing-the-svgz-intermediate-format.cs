using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
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

        // Output JPG file
        string outputJpgPath = "merged_output.jpg";

        // Temporary SVGZ intermediate file
        string tempSvgzPath = "temp_intermediate.svgz";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputJpgPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgzPath));

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size (horizontal stitching)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create a blank JPEG canvas (unbound)
        JpegOptions canvasOptions = new JpegOptions();
        using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
        {
            // Merge images side by side
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

            // Save the merged canvas as compressed SVGZ
            SvgOptions svgOptions = new SvgOptions
            {
                Compress = true,
                VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = canvas.Size }
            };
            canvas.Save(tempSvgzPath, svgOptions);
        }

        // Load the SVGZ intermediate and rasterize to final JPEG
        using (Image svgImage = Image.Load(tempSvgzPath))
        {
            JpegOptions finalJpegOptions = new JpegOptions
            {
                Quality = 90,
                Source = new FileCreateSource(outputJpgPath, false)
            };
            svgImage.Save(outputJpgPath, finalJpegOptions);
        }
    }
}