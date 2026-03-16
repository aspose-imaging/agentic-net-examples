using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF and output WMF file paths
        string gifPath = "input.gif";
        string wmfPath = "output.wmf";

        // Load the GIF image
        using (GifImage gif = (GifImage)Image.Load(gifPath))
        {
            int width = gif.Width;
            int height = gif.Height;

            // Define the WMF canvas size matching the GIF dimensions
            Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, width, height);
            int dpi = 96; // Standard screen resolution

            // Create a WMF recorder graphics object
            WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(frame, dpi);

            // Draw the GIF onto the WMF canvas
            graphics.DrawImage(
                gif,
                new Aspose.Imaging.Rectangle(0, 0, width, height),
                new Aspose.Imaging.Rectangle(0, 0, width, height),
                Aspose.Imaging.GraphicsUnit.Pixel);

            // Finalize and obtain the WMF image
            using (WmfImage wmfImage = graphics.EndRecording())
            {
                // Save the WMF image to file
                wmfImage.Save(wmfPath);
            }
        }
    }
}