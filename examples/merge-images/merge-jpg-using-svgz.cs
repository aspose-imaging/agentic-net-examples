using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputFiles = { "image1.jpg", "image2.jpg" };
        // Output file in compressed SVG (SVGZ) format
        string outputFile = "merged.svgz";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate dimensions for the horizontal canvas
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Create an unbound raster canvas
        using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            // Merge each image onto the canvas
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Prepare SVG options with compression (SVGZ)
            SvgOptions svgOptions = new SvgOptions
            {
                Compress = true,
                VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = canvas.Size }
            };

            // Save the merged image as compressed SVG (SVGZ)
            canvas.Save(outputFile, svgOptions);
        }
    }
}