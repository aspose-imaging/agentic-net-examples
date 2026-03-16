using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output TIFF file path
        string outputPath = "output.tif";

        // Configure TIFF options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a blank TIFF image (200x200 pixels)
        using (Image image = Image.Create(tiffOptions, 200, 200))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Define a pen for the rectangle outline
            Pen pen = new Pen(Color.Blue, 5);

            // Draw a rectangle at (20,20) with width 160 and height 160
            graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 160));

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}