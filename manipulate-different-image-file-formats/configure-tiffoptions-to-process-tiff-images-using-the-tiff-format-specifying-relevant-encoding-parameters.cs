// Specify the output directory
string outputDir = @"c:\temp\";

// Configure TIFF saving options with desired encoding parameters
Aspose.Imaging.ImageOptions.TiffOptions tiffOptions = new Aspose.Imaging.ImageOptions.TiffOptions(
    Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

// 8 bits per color component (RGB)
tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

// Use Big Endian byte order (Motorola)
tiffOptions.ByteOrder = Aspose.Imaging.FileFormats.Tiff.Enums.TiffByteOrder.BigEndian;

// Apply LZW compression
tiffOptions.Compression = Aspose.Imaging.FileFormats.Tiff.Enums.TiffCompressions.Lzw;

// Use horizontal predictor to improve LZW compression efficiency
tiffOptions.Predictor = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPredictor.Horizontal;

// Set the photometric interpretation to RGB
tiffOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb;

// Store all color components in a single plane
tiffOptions.PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous;

// Create a raster image (BMP) to be saved as TIFF
using (Aspose.Imaging.Image bmpImage = new Aspose.Imaging.FileFormats.Bmp.BmpImage(100, 100))
{
    // Fill the image with a blue‑yellow linear gradient
    Aspose.Imaging.Brushes.LinearGradientBrush gradientBrush = new Aspose.Imaging.Brushes.LinearGradientBrush(
        new Aspose.Imaging.Point(0, 0),
        new Aspose.Imaging.Point(bmpImage.Width, bmpImage.Height),
        Aspose.Imaging.Color.Blue,
        Aspose.Imaging.Color.Yellow);

    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(bmpImage);
    graphics.FillRectangle(gradientBrush, bmpImage.Bounds);

    // Save the image as a TIFF file using the configured options
    bmpImage.Save(System.IO.Path.Combine(outputDir, "output.tif"), tiffOptions);
}