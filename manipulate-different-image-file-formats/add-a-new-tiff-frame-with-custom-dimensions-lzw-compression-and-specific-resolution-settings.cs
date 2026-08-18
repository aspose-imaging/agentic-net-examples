// HOW-TO: Add a New TIFF Frame with LZW Compression and Custom DPI in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input\\source.tif";
            string outputPath = "output\\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load existing TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Define options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                frameOptions.ResolutionUnit = TiffResolutionUnits.Inch;
                frameOptions.Xresolution = new TiffRational(300, 1); // 300 DPI
                frameOptions.Yresolution = new TiffRational(300, 1); // 300 DPI

                // Create new frame with custom dimensions
                int frameWidth = 200;
                int frameHeight = 200;
                TiffFrame newFrame = new TiffFrame(frameOptions, frameWidth, frameHeight);

                // Optional: fill the frame with a gradient
                LinearGradientBrush gradient = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(newFrame.Width, newFrame.Height),
                    Color.Blue,
                    Color.Yellow);
                Graphics graphics = new Graphics(newFrame);
                graphics.FillRectangle(gradient, newFrame.Bounds);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the updated TIFF image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create or append a high‑resolution page to an existing multi‑page TIFF document, such as adding a scanned invoice to a batch file.
 * 2. When you must generate a TIFF thumbnail with specific dimensions and LZW compression for faster web preview while preserving image quality.
 * 3. When you are preparing printable graphics that require exact 300 DPI resolution and lossless compression for professional publishing workflows.
 * 4. When you are archiving medical or scientific images in a TIFF container and need each frame to use LZW compression and standardized DPI for compliance.
 * 5. When you are building a GIS or mapping application that stores raster tiles as TIFF frames with custom size and resolution settings for accurate georeferencing.
 */
