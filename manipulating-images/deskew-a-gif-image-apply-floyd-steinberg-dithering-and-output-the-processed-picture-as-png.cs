using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "C:\\temp\\input.gif";
            string outputPath = "C:\\temp\\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Deskew the image (remove any skew angle)
                gifImage.NormalizeAngle();

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette (black & white)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the processed image as PNG
                gifImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to automatically correct the orientation of scanned GIF receipts and convert them to high‑contrast black‑and‑white PNGs for archival, a developer can use this code.
 * 2. When an e‑learning platform receives user‑uploaded animated GIF diagrams that are slightly skewed and must be displayed as static PNG images with Floyd‑Steinberg dithering for better readability on low‑bandwidth devices, this snippet is applicable.
 * 3. When a batch‑processing tool must normalize the angle of legacy GIF icons, apply 1‑bit dithering to reduce file size, and output PNG files for modern UI themes, the code provides the required steps.
 * 4. When a document‑management system imports scanned forms saved as GIF, needs to deskew them, convert them to black‑white PNG using Floyd‑Steinberg dithering for OCR preprocessing, a developer can implement this routine.
 * 5. When a mobile app backend processes user‑submitted GIF screenshots, removes any tilt, applies Floyd‑Steinberg dithering to enhance contrast, and stores the result as PNG for consistent rendering across platforms, this example is useful.
 */