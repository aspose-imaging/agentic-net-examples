using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Ensure output directory exists (unconditional as per requirements)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load existing TIFF image
            using (Aspose.Imaging.FileFormats.Tiff.TiffImage tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure options for the new frame with custom compression
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.Compression = TiffCompressions.CcittFax3; // custom compression
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create a new frame (size 100x100)
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Fill the new frame with a simple gradient
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(newFrame.Width, newFrame.Height),
                    Aspose.Imaging.Color.Blue,
                    Aspose.Imaging.Color.Yellow);
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(newFrame);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the updated TIFF to the output path
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}