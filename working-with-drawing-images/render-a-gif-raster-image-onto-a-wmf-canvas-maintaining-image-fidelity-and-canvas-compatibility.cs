using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.ImageOptions;

namespace GifToWmfExample
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputGifPath = @"C:\temp\input.gif";
            string outputWmfPath = @"C:\temp\output.wmf";

            // Verify input file exists
            if (!File.Exists(inputGifPath))
            {
                Console.Error.WriteLine($"File not found: {inputGifPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputWmfPath));

            // Load the GIF image as a raster image
            using (RasterImage gifImage = (RasterImage)Image.Load(inputGifPath))
            {
                // Determine canvas size based on GIF dimensions
                int canvasWidth = gifImage.Width;
                int canvasHeight = gifImage.Height;
                int dpi = 96; // default screen resolution

                // Define the frame rectangle for the WMF canvas (measured in twips)
                Rectangle frame = new Rectangle(0, 0, canvasWidth, canvasHeight);

                // Create a WMF recorder graphics object
                WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(frame, dpi);

                // Draw the GIF onto the WMF canvas, scaling to fit the full canvas
                graphics.DrawImage(
                    gifImage,
                    new Rectangle(0, 0, canvasWidth, canvasHeight),   // destination rectangle on WMF
                    new Rectangle(0, 0, canvasWidth, canvasHeight),   // source rectangle from GIF
                    GraphicsUnit.Pixel);

                // Finalize recording and obtain the WMF image
                using (WmfImage wmfImage = graphics.EndRecording())
                {
                    // Save the WMF image to the specified output path
                    wmfImage.Save(outputWmfPath);
                }
            }
        }
    }
}