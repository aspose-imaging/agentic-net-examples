using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Output TIFF file path
        string outputPath = @"C:\temp\ellipse.tiff";

        // Ensure the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the TIFF image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new StreamSource(stream);

            // Create a new TIFF image (500x500 pixels)
            using (Image image = Image.Create(tiffOptions, 500, 500))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Clear the background with a light color
                graphics.Clear(Color.Wheat);

                // Define a pen (black, thickness 2)
                Pen pen = new Pen(Color.Black, 2);

                // Define the bounding rectangle for the ellipse
                RectangleF ellipseRect = new RectangleF(50f, 50f, 300f, 300f);

                // Draw the ellipse on the image
                graphics.DrawEllipse(pen, ellipseRect);

                // Save the image (writes to the stream)
                image.Save();
            }
        }
    }
}