using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats;

// Create a TIFF image, draw a rectangle and some text, then save it.
class CreateTiffExample
{
    static void Main()
    {
        // Output file path
        string outputPath = @"C:\Temp\example.tif";

        // Configure TIFF options for the frame
        TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            BitsPerSample = new ushort[] { 8, 8, 8 },                     // 8 bits per color component
            ByteOrder = TiffByteOrder.BigEndian,                         // Motorola byte order
            Compression = TiffCompressions.Lzw,                          // LZW compression
            Photometric = TiffPhotometrics.Rgb,                          // RGB color model
            PlanarConfiguration = TiffPlanarConfigs.Contiguous          // Single plane storage
        };

        // Create a 200x150 pixel frame using the options
        TiffFrame frame = new TiffFrame(frameOptions, 200, 150);

        // Draw a blue rectangle with a yellow border
        using (Graphics graphics = new Graphics(frame))
        {
            // Fill background with light gray
            graphics.FillRectangle(new SolidBrush(Color.LightGray), frame.Bounds);

            // Draw a blue filled rectangle
            graphics.FillRectangle(new SolidBrush(Color.Blue), 20, 20, 160, 110);

            // Draw a yellow border around the blue rectangle
            graphics.DrawRectangle(new Pen(Color.Yellow, 3), 20, 20, 160, 110);

            // Draw some text in white
            Font font = new Font("Arial", 24);
            graphics.DrawString("Aspose.Imaging", font, new SolidBrush(Color.White), 30, 60);
        }

        // Create a TIFF image from the frame
        using (TiffImage tiffImage = new TiffImage(frame))
        {
            // Save the TIFF image to disk
            tiffImage.Save(outputPath);
        }

        Console.WriteLine($"TIFF image saved to: {outputPath}");
    }
}