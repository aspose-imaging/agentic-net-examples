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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create options for the new frame with a custom photometric interpretation
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.MinIsBlack; // custom photometric
                frameOptions.Compression = TiffCompressions.Jpeg; // JPEG compression for the frame (optional)

                // Create a new frame (100x100 pixels)
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Fill the new frame with a simple gradient
                Graphics graphics = new Graphics(newFrame);
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(newFrame.Width, newFrame.Height),
                    Color.White,
                    Color.Black);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Add the new frame to the existing TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the updated TIFF image using JPEG compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.Photometric = TiffPhotometrics.Rgb;

                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to embed a high‑resolution preview image inside a multi‑page TIFF document for a medical imaging archive, using Aspose.Imaging for .NET to add a frame with MinIsBlack photometric interpretation and JPEG compression to reduce file size.
 * 2. When creating a multi‑layer GIS map where each layer is stored as a separate TIFF frame, a developer can use Aspose.Imaging for .NET to set a custom photometric (MinIsBlack) and apply JPEG compression to keep the dataset compact.
 * 3. When generating a digital archive of scanned historical photographs and wants to add a thumbnail frame with a gradient background, Aspose.Imaging for .NET enables adding the frame with a custom photometric interpretation and JPEG compression to balance quality and storage.
 * 4. When building a document management system that stores scanned contracts as multi‑page TIFFs and requires an additional watermarked preview frame, a developer can use Aspose.Imaging for .NET to add the frame with MinIsBlack photometric settings and JPEG compression for efficient storage.
 * 5. When developing a scientific imaging pipeline that appends calibration charts as extra TIFF frames, Aspose.Imaging for .NET allows setting the photometric to MinIsBlack and compressing the frame with JPEG to maintain compatibility with analysis software.
 */