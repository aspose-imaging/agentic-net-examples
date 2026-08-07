using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "high_res_output.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create TIFF options with 300 DPI resolution
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);
            tiffOptions.ResolutionUnit = TiffResolutionUnits.Inch;
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 1000x1000 pixel TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 1000, 1000))
            {
                // Fill the image with a gradient
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(tiffImage.Width, tiffImage.Height),
                    Color.Blue,
                    Color.Yellow);
                Graphics graphics = new Graphics(tiffImage);
                graphics.FillRectangle(gradientBrush, tiffImage.Bounds);

                // Save the image (output path already bound)
                tiffImage.Save();
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
 * 1. When a developer needs to generate a 300‑DPI TIFF file for high‑quality print production, such as brochures or posters, and wants to ensure the image retains color fidelity with LZW compression.
 * 2. When an application must create a large raster image (e.g., 1000 × 1000 pixels) for archival storage in a lossless TIFF format that can be opened by legacy imaging software.
 * 3. When a GIS or mapping tool requires a high‑resolution, georeferenced TIFF canvas to overlay vector data and the developer wants to pre‑fill it with a gradient background for visual reference.
 * 4. When a medical‑imaging system needs to export diagnostic scans as 300‑DPI TIFF files with consistent resolution metadata for compliance with DICOM standards.
 * 5. When a document‑management workflow automates the creation of TIFF images with embedded resolution settings so that downstream OCR or digital‑signature verification processes can rely on accurate DPI information.
 */