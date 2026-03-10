using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG image paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg"
            // Add more paths as needed
        };

        // Output BigTIFF file path
        string outputPath = "merged_output.tif";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create file source for the output image
        Source fileSource = new FileCreateSource(outputPath, false);

        // Configure BigTIFF options
        BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default)
        {
            Source = fileSource
        };

        // Create a BigTIFF canvas
        using (BigTiffImage canvas = (BigTiffImage)Image.Create(options, canvasWidth, canvasHeight))
        {
            // Merge images horizontally onto the canvas
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

            // Save the bound BigTIFF image
            canvas.Save();
        }
    }
}