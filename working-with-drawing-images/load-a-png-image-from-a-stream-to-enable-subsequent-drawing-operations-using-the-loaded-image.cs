using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class LoadPngFromStream
{
    static void Main()
    {
        // Path to the directory containing the PNG file.
        string dir = @"c:\temp\";

        // Open a file stream for the PNG image.
        using (Stream stream = File.OpenRead(Path.Combine(dir, "sample.png")))
        {
            // Load the PNG image from the stream using the PngImage(Stream) constructor.
            using (PngImage pngImage = new PngImage(stream))
            {
                // Example drawing operation: fill the entire image with solid red.
                Graphics graphics = new Graphics(pngImage);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, pngImage.Bounds);

                // Save the modified image to a new file.
                pngImage.Save(Path.Combine(dir, "sample_modified.png"));
            }
        }
    }
}