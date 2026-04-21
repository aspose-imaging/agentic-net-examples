using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input CMX files
        string[] inputPaths = new string[]
        {
            @"C:\Images\file1.cmx",
            @"C:\Images\file2.cmx",
            @"C:\Images\file3.cmx"
        };

        // Hardcoded output composite image (PNG)
        string outputPath = @"C:\Images\merged.png";

        // Validate input files
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes and temporary rasterized PNG paths
        List<Size> sizes = new List<Size>();
        List<string> tempRasterPaths = new List<string>();

        // Rasterize each CMX to a temporary PNG
        foreach (var cmxPath in inputPaths)
        {
            using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
            {
                sizes.Add(cmx.Size);

                string tempPng = Path.ChangeExtension(Path.GetTempFileName(), ".png");
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CmxRasterizationOptions()
                };
                cmx.Save(tempPng, pngOptions);
                tempRasterPaths.Add(tempPng);
            }
        }

        // Determine canvas size (maximum width and height)
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create output PNG canvas bound to the output file
        Source outSource = new FileCreateSource(outputPath, false);
        var outOptions = new PngOptions { Source = outSource };
        using (RasterImage canvas = (RasterImage)Image.Create(outOptions, canvasWidth, canvasHeight))
        {
            // Merge each rasterized image onto the canvas preserving order
            foreach (var rasterPath in tempRasterPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(rasterPath))
                {
                    var bounds = new Rectangle(0, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                }
            }

            // Save the composite image
            canvas.Save();
        }

        // Clean up temporary files
        foreach (var temp in tempRasterPaths)
        {
            try { File.Delete(temp); } catch { }
        }
    }
}