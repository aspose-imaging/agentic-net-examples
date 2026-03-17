using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Path to the source raster image (any supported format, e.g., PNG, JPEG, BMP)
        string sourcePath = @"C:\Images\input.png";

        // Desired output TIFF file path
        string outputPath = @"C:\Images\output_deflate.tif";

        // Load the raster image using Aspose.Imaging's load rule
        using (Image rasterImage = Image.Load(sourcePath))
        {
            // Create TIFF save options (default expected format)
            TiffOptions tiffSaveOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Apply Deflate compression to reduce file size
            tiffSaveOptions.Compression = TiffCompressions.Deflate;

            // Optional: set common TIFF parameters (bits per sample, photometric, etc.)
            tiffSaveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };                     // 8 bits per color component
            tiffSaveOptions.Photometric = TiffPhotometrics.Rgb;                         // RGB color model
            tiffSaveOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;        // Single plane storage

            // Save the image as a TIFF using the defined options (save rule)
            rasterImage.Save(outputPath, tiffSaveOptions);
        }
    }
}