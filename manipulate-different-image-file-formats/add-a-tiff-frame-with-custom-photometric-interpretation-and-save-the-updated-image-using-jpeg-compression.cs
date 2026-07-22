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
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create options for the new frame with custom photometric interpretation
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8 };
                frameOptions.Photometric = TiffPhotometrics.MinIsBlack;
                frameOptions.Compression = TiffCompressions.None;

                // Create a new 100x100 frame
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Fill the new frame with a grayscale gradient
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(newFrame.Width, newFrame.Height),
                    Color.White,
                    Color.Black))
                {
                    Graphics graphics = new Graphics(newFrame);
                    graphics.FillRectangle(brush, newFrame.Bounds);
                }

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the updated TIFF image using JPEG compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.CompressedQuality = 75;
                saveOptions.Photometric = TiffPhotometrics.Rgb;
                saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

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
 * 1. When a developer needs to embed a grayscale calibration chart as an extra frame in a multi‑page TIFF file for medical imaging, using a MinIsBlack photometric interpretation and JPEG compression to keep the file size low.
 * 2. When a GIS application must add a 100 × 100 elevation heat‑map layer to an existing satellite TIFF dataset, specifying custom photometric settings and compressing the result with JPEG for faster transmission.
 * 3. When a document management solution has to insert a low‑resolution preview page into a scanned multi‑page TIFF archive, using a linear gradient background to indicate page boundaries while applying JPEG compression to reduce storage costs.
 * 4. When a printing workflow requires adding a grayscale proofing frame to a multi‑page TIFF proof file, setting the photometric interpretation to MinIsBlack and saving with JPEG compression to meet printer bandwidth constraints.
 * 5. When a digital asset management system needs to attach a thumbnail frame with a custom gradient to a high‑resolution TIFF image, using custom photometric settings and JPEG compression to ensure quick thumbnail loading without altering the original frames.
 */