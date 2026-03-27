using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Define custom dimensions for the new frame
            int newWidth = 200;
            int newHeight = 150;

            // Configure TiffOptions for the new frame
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions.Compression = TiffCompressions.Lzw;
            frameOptions.Photometric = TiffPhotometrics.Rgb;
            frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            frameOptions.Xresolution = new TiffRational(300, 1); // 300 DPI horizontal
            frameOptions.Yresolution = new TiffRational(300, 1); // 300 DPI vertical

            // Create the new TIFF frame
            using (TiffFrame newFrame = new TiffFrame(frameOptions, newWidth, newHeight))
            {
                // Fill the frame with a simple gradient (optional visual content)
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(newFrame.Width, newFrame.Height),
                    Aspose.Imaging.Color.Blue,
                    Aspose.Imaging.Color.Yellow))
                {
                    Graphics graphics = new Graphics(newFrame);
                    graphics.FillRectangle(gradientBrush, newFrame.Bounds);
                }

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);
            }

            // Save the updated TIFF to the output path
            tiffImage.Save(outputPath);
        }
    }
}