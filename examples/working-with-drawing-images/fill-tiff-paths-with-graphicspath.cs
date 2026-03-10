using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Drawing; // for Color (if needed)

class FillTiffPaths
{
    static void Main()
    {
        // Load the existing TIFF image
        using (var image = (TiffImage)Image.Load("input.tif"))
        {
            // Convert the TIFF's path resources to a GraphicsPath
            var graphicsPath = PathResourceConverter.ToGraphicsPath(
                image.ActiveFrame.PathResources.ToArray(),
                image.ActiveFrame.Size);

            // Create a Graphics object for drawing on the image
            var graphics = new Graphics(image);

            // Define a solid brush (e.g., semi‑transparent red) to fill the path
            var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));

            // Fill the path with the brush
            graphics.FillPath(brush, graphicsPath);

            // Save the modified image
            image.Save("output_filled.tif");
        }
    }
}