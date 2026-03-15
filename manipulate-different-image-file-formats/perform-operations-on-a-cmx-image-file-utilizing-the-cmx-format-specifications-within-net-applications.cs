using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths – adjust as needed
        string cmxPath = "canvas.cmx";
        string outputPath = "merged.png";
        string[] rasterPaths = new string[] { "image1.jpg", "image2.png", "image3.bmp" };

        // Load CMX canvas to obtain its dimensions
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Prepare output file source
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outSource };

            // Create a raster canvas bound to the output file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;

                // Merge each raster image onto the canvas horizontally
                foreach (string rasterPath in rasterPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(rasterPath))
                    {
                        // Define destination rectangle on the canvas
                        Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);

                        // Copy pixel data from source image to canvas
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                        // Update horizontal offset for next image
                        offsetX += img.Width;
                    }
                }

                // Since the canvas is bound to the file source, simply call Save()
                canvas.Save();
            }
        }
    }
}