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
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Adjust brightness
            tiffImage.AdjustBrightness(30);

            // Resize the image using nearest neighbour resampling
            tiffImage.Resize(200, 200, ResizeType.NearestNeighbourResample);

            // Create a new frame with gradient fill
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions.Photometric = TiffPhotometrics.Rgb;
            frameOptions.Compression = TiffCompressions.Lzw;
            frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            TiffFrame newFrame = new TiffFrame(frameOptions, 200, 200);

            // Fill the new frame with a blue‑yellow gradient
            Graphics graphics = new Graphics(newFrame);
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(newFrame.Width, newFrame.Height),
                Color.Blue,
                Color.Yellow);
            graphics.FillRectangle(brush, newFrame.Bounds);

            // Add the new frame to the TIFF image
            tiffImage.AddFrame(newFrame);

            // Save the modified TIFF image
            tiffImage.Save(outputPath);
        }
    }
}