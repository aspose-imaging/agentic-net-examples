using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output PSD file path
        string outputPath = "indexed_output.psd";

        // Define image dimensions
        int width = 200;
        int height = 200;

        // Create PSD options for indexed color mode with a palette
        PsdOptions options = new PsdOptions
        {
            Source = new FileCreateSource(outputPath, false),
            ColorMode = ColorModes.Indexed,
            CompressionMethod = CompressionMethod.RLE,
            Version = 6,
            Palette = new ColorPalette(new Color[]
            {
                Color.White,
                Color.Black,
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Cyan,
                Color.Magenta
            })
        };

        // Create a new PSD image with the specified options
        using (Image psdImage = Image.Create(options, width, height))
        {
            // Obtain a Graphics object for drawing
            Graphics graphics = new Graphics(psdImage);

            // Clear background with the first palette color (White)
            graphics.Clear(Color.White);

            // Draw a diagonal line using the second palette color (Black)
            Pen blackPen = new Pen(Color.Black, 2);
            graphics.DrawLine(blackPen, new Point(0, 0), new Point(width, height));

            // Draw a rectangle using the third palette color (Red)
            Pen redPen = new Pen(Color.Red, 2);
            graphics.DrawRectangle(redPen, new Rectangle(20, 20, 160, 160));

            // Save the PSD image (source is already bound to the file)
            psdImage.Save();
        }

        Console.WriteLine("Indexed PSD image saved to: " + outputPath);
    }
}