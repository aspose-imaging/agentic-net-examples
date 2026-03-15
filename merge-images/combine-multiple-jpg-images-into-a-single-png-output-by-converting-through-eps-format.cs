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
    static void Main(string[] args)
    {
        // Input JPG files
        string[] jpgPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect sizes of each JPG
        List<Size> sizes = new List<Size>();
        foreach (string path in jpgPaths)
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

        // Create output PNG canvas
        string outputPath = "combined.png";
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = outputSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string jpgPath in jpgPaths)
            {
                // Convert JPG to temporary EPS
                string tempEpsPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".eps");
                using (Image jpgImg = Image.Load(jpgPath))
                {
                    jpgImg.Save(tempEpsPath, new Aspose.Imaging.FileFormats.Eps.EpsOptions());
                }

                // Convert EPS to temporary PNG using rasterization options
                string tempPngPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImg = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(tempEpsPath))
                {
                    var epsRasterOptions = new Aspose.Imaging.ImageOptions.EpsRasterizationOptions
                    {
                        PageWidth = epsImg.Width,
                        PageHeight = epsImg.Height
                    };
                    var tempPngOptions = new PngOptions { VectorRasterizationOptions = epsRasterOptions };
                    epsImg.Save(tempPngPath, tempPngOptions);
                }

                // Load the rasterized PNG and paste onto canvas
                using (RasterImage tempPngImg = (RasterImage)Image.Load(tempPngPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, tempPngImg.Width, tempPngImg.Height);
                    canvas.SaveArgb32Pixels(bounds, tempPngImg.LoadArgb32Pixels(tempPngImg.Bounds));
                    offsetX += tempPngImg.Width;
                }

                // Clean up temporary files
                if (File.Exists(tempEpsPath)) File.Delete(tempEpsPath);
                if (File.Exists(tempPngPath)) File.Delete(tempPngPath);
            }

            // Save the final combined PNG
            canvas.Save();
        }
    }
}