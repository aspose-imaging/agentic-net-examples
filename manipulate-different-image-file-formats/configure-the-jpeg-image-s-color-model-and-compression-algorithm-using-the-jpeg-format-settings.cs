using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging;

// Define the folder where the images are located.
string dataDir = @"c:\temp\";

// Load an existing image (any supported format, e.g., BMP).
using (Image image = Image.Load(dataDir + "input.bmp"))
{
    // Create JPEG save options.
    JpegOptions jpegOptions = new JpegOptions();

    // Set the compression algorithm to Progressive JPEG.
    jpegOptions.CompressionType = JpegCompressionMode.Progressive;

    // Choose the desired color model (e.g., YCbCr – standard JPEG color space).
    jpegOptions.ColorType = JpegCompressionColorMode.YCbCr;

    // Optional: set image quality (1‑100). Higher value = better quality, larger file.
    jpegOptions.Quality = 90;

    // Optional: configure bits per channel and resolution.
    jpegOptions.BitsPerChannel = 8;
    jpegOptions.ResolutionSettings = new ResolutionSetting(96.0, 96.0);
    jpegOptions.ResolutionUnit = ResolutionUnit.Inch;

    // Save the image as JPEG using the configured options.
    image.Save(dataDir + "output.jpg", jpegOptions);
}