using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string dngPath = "input.dng";
        string jpgPath = "input.jpg";
        string outputPath = "output.png";

        // Load DNG image to obtain canvas size
        using (RasterImage dngImage = (RasterImage)Image.Load(dngPath))
        {
            int canvasWidth = dngImage.Width;
            int canvasHeight = dngImage.Height;

            // Prepare output source and PNG options
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };

            // Create PNG canvas bound to the output file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Load JPG image to be merged
                using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
                {
                    // Merge JPG onto the PNG canvas at (0,0)
                    canvas.SaveArgb32Pixels(
                        new Rectangle(0, 0, jpgImage.Width, jpgImage.Height),
                        jpgImage.LoadArgb32Pixels(jpgImage.Bounds));
                }

                // Save the bound PNG canvas
                canvas.Save();
            }
        }
    }
}