using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output TIFF file path
        string outputPath = "output.tif";

        // Ensure the directory exists
        string directory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Configure TIFF options and bind the output file
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        int width = 500;
        int height = 500;

        // Create a new TIFF image
        using (Image image = Image.Create(tiffOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Draw an arc: black pen, rectangle bounds, start angle 0, sweep angle 180
            graphics.DrawArc(new Pen(Color.Black, 2), new Rectangle(100, 100, 300, 200), 0, 180);

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}