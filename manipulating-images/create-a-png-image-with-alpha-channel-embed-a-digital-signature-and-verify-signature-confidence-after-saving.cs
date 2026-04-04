using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Define paths
        string outputPath = "output\\signed_image.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image with alpha channel
        using (PngImage png = new PngImage(200, 200, PngColorType.TruecolorWithAlpha))
        {
            // Fill the image with a semi‑transparent gradient
            using (LinearGradientBrush gradient = new LinearGradientBrush(
                new Point(0, 0),
                new Point(png.Width, png.Height),
                Color.Blue,
                Color.Transparent))
            {
                Graphics graphics = new Graphics(png);
                graphics.FillRectangle(gradient, png.Bounds);
            }

            // Embed a digital signature
            string password = "secret";
            png.EmbedDigitalSignature(password);

            // Save the image
            png.Save(outputPath);
        }

        // Verify the digital signature
        using (Image img = Image.Load(outputPath))
        {
            var raster = (RasterCachedImage)img;
            bool isSigned = raster.IsDigitalSigned("secret");
            Console.WriteLine($"Signature verification result: {isSigned}");
        }
    }
}