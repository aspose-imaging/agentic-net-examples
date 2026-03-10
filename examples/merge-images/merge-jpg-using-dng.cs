using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input paths
        string dngPath = "input.dng";
        string[] jpgPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPath = "merged.jpg";

        // Load DNG to obtain canvas dimensions
        int canvasWidth;
        int canvasHeight;
        using (RasterImage dngImage = (RasterImage)Image.Load(dngPath))
        {
            canvasWidth = dngImage.Width;
            canvasHeight = dngImage.Height;
        }

        // Create output source and JPEG options
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outputSource,
            Quality = 100
        };

        // Create JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string jpgPath in jpgPaths)
            {
                using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
                {
                    // Determine placement rectangle
                    Rectangle bounds = new Rectangle(offsetX, 0, jpgImage.Width, jpgImage.Height);
                    // Copy JPG pixels onto the canvas
                    canvas.SaveArgb32Pixels(bounds, jpgImage.LoadArgb32Pixels(jpgImage.Bounds));
                    // Update horizontal offset
                    offsetX += jpgImage.Width;
                }
            }

            // Save the bound JPEG canvas
            canvas.Save();
        }
    }
}