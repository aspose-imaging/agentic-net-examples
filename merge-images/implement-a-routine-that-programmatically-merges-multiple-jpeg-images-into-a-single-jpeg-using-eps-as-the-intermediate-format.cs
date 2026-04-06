using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Temporary EPS intermediate file
        string tempEpsPath = "temp.eps";

        // Final merged JPEG output
        string outputPath = "merged.jpg";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempEpsPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal merge)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create an unbound raster canvas
        using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), canvasWidth, canvasHeight))
        {
            // Merge each JPEG onto the canvas
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged raster as EPS (intermediate)
            canvas.Save(tempEpsPath, new Aspose.Imaging.FileFormats.Eps.EpsOptions());
        }

        // Load the EPS intermediate and save as final JPEG
        using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImg = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(tempEpsPath))
        {
            epsImg.Save(outputPath, new JpegOptions());
        }
    }
}