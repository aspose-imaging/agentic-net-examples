using System;
using System.IO;
using Aspose.Imaging;
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

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TIFF image
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Create graphics for the active frame
                Graphics graphics = new Graphics(tiff.ActiveFrame);

                // Draw a gradient over the entire image
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(tiff.Width, tiff.Height),
                    Color.Blue,
                    Color.Yellow))
                {
                    graphics.FillRectangle(brush, tiff.Bounds);
                }

                // Save the modified image with overwrite enabled
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiff.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}