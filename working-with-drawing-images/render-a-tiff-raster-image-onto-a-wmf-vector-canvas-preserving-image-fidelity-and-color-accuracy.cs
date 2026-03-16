using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input TIFF and output WMF
        string inputTiffPath = "input.tif";
        string outputWmfPath = "output.wmf";

        // Load the TIFF raster image
        using (RasterImage tiffImage = (RasterImage)Image.Load(inputTiffPath))
        {
            int width = tiffImage.Width;
            int height = tiffImage.Height;
            int dpi = 96; // Standard screen DPI

            // Create a WMF recorder graphics object with the same size as the TIFF
            var frame = new Aspose.Imaging.Rectangle(0, 0, width, height);
            var graphics = new Aspose.Imaging.FileFormats.Wmf.Graphics.WmfRecorderGraphics2D(frame, dpi);

            // Draw the TIFF onto the WMF canvas preserving original size and colors
            graphics.DrawImage(
                tiffImage,
                new Aspose.Imaging.Rectangle(0, 0, width, height),
                new Aspose.Imaging.Rectangle(0, 0, width, height),
                Aspose.Imaging.GraphicsUnit.Pixel);

            // Finalize recording and obtain the WMF image
            using (Aspose.Imaging.FileFormats.Wmf.WmfImage wmfImage = graphics.EndRecording())
            {
                // Save the WMF file
                wmfImage.Save(outputWmfPath);
            }
        }
    }
}