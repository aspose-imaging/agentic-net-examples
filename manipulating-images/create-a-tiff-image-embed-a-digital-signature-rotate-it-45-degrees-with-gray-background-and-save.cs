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
        try
        {
            // Output file path
            string outputPath = "output/output.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new TIFF image (200x200 pixels)
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 200, 200))
            {
                // Fill the image with a simple gradient
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(tiffImage.Width, tiffImage.Height),
                    Color.Red,
                    Color.Blue);
                Graphics graphics = new Graphics(tiffImage);
                graphics.FillRectangle(brush, tiffImage.Bounds);

                // Embed a digital signature using a valid password
                tiffImage.EmbedDigitalSignature("secure123");

                // Rotate the image 45 degrees with a gray background, resizing proportionally
                tiffImage.Rotate(45f, true, Color.Gray);

                // Save the image (output path is already bound)
                tiffImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}