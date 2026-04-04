using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output path for the TIFF image
        string outputPath = "output\\rotated.tif";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure TIFF options with a file create source
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

        // Create a new TIFF image (200x200 pixels)
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
        {
            // Fill the image with a blue‑yellow gradient
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(tiffImage.Width, tiffImage.Height),
                Color.Blue,
                Color.Yellow);
            Graphics graphics = new Graphics(tiffImage);
            graphics.FillRectangle(brush, tiffImage.Bounds);

            // Embed a digital signature using a password
            tiffImage.ActiveFrame.EmbedDigitalSignature("SecretPassword");

            // Rotate the image 45 degrees, resize canvas, gray background
            tiffImage.Rotate(45f, true, Color.Gray);

            // Save the image (output path already bound to the source)
            tiffImage.Save();
        }
    }
}