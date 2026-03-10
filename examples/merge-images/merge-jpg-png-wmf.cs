using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input JPG file path
            string inputJpgPath = "input.jpg";
            // Output PNG file path
            string outputPngPath = "output.png";

            // Load the JPG image as a raster image
            using (RasterImage jpgImage = (RasterImage)Image.Load(inputJpgPath))
            {
                // Create a WMF canvas with the same dimensions as the JPG
                using (WmfImage wmfCanvas = new WmfImage(jpgImage.Width, jpgImage.Height))
                {
                    // Draw the JPG onto the WMF canvas
                    Graphics graphics = new Graphics(wmfCanvas);
                    graphics.DrawImage(jpgImage, new Point(0, 0));

                    // Prepare PNG export options with vector rasterization settings for WMF
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new WmfRasterizationOptions
                        {
                            PageSize = wmfCanvas.Size
                        }
                    };

                    // Save the WMF canvas as a PNG file
                    wmfCanvas.Save(outputPngPath, pngOptions);
                }
            }
        }
    }
}