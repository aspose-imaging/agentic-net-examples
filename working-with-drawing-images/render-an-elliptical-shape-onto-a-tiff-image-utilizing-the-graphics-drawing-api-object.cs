using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class RenderEllipseToTiff
{
    static void Main()
    {
        // Path where the TIFF image will be saved
        string outputPath = @"C:\temp\ellipse_output.tiff";

        // Create a FileStream for writing the TIFF file
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure TIFF options (default format)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new StreamSource(stream);

            // Create a new 500x500 TIFF image
            using (Image image = Image.Create(tiffOptions, 500, 500))
            {
                // Initialize Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the background with a light color
                graphics.Clear(Color.Wheat);

                // Define the bounding rectangle for the ellipse
                Rectangle ellipseBounds = new Rectangle(100, 100, 300, 200); // x, y, width, height

                // Create a Pen to outline the ellipse (black color, 3-pixel width)
                Pen ellipsePen = new Pen(Color.Black, 3);

                // Draw the ellipse onto the graphics surface
                graphics.DrawEllipse(ellipsePen, ellipseBounds);

                // Save all changes to the TIFF file
                image.Save();
            }
        }
    }
}