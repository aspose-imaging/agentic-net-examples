using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main(string[] args)
    {
        // Default TIFF options (no compression, RGB)
        TiffOptions defaultOptions = new TiffOptions(TiffExpectedFormat.Default);
        defaultOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        defaultOptions.ByteOrder = TiffByteOrder.LittleEndian;
        defaultOptions.Compression = TiffCompressions.None;
        defaultOptions.Photometric = TiffPhotometrics.Rgb;
        defaultOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // LZW compressed TIFF (good for lossless compression)
        TiffOptions lzwOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
        lzwOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        lzwOptions.Compression = TiffCompressions.Lzw;
        lzwOptions.Photometric = TiffPhotometrics.Rgb;
        lzwOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        lzwOptions.Predictor = TiffPredictor.Horizontal; // optional predictor for LZW

        // CCITT Group 3 (black & white) TIFF
        TiffOptions ccittOptions = new TiffOptions(TiffExpectedFormat.TiffCcittFax3);
        ccittOptions.BitsPerSample = new ushort[] { 1 };
        ccittOptions.Compression = TiffCompressions.CcittFax3;
        ccittOptions.Photometric = TiffPhotometrics.MinIsBlack;
        ccittOptions.ByteOrder = TiffByteOrder.LittleEndian;

        // JPEG compressed TIFF (lossy, suitable for photographs)
        TiffOptions jpegOptions = new TiffOptions(TiffExpectedFormat.TiffJpegRgb);
        jpegOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        jpegOptions.Compression = TiffCompressions.Jpeg;
        jpegOptions.Photometric = TiffPhotometrics.Ycbcr;
        jpegOptions.CompressedQuality = 90; // quality 0-100
        jpegOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // BigTIFF options (for very large images)
        BigTiffOptions bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default);
        bigTiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        bigTiffOptions.Compression = TiffCompressions.AdobeDeflate;
        bigTiffOptions.Photometric = TiffPhotometrics.Rgb;
        bigTiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // Create a simple TIFF using default options
        using (TiffImage tiff = (TiffImage)Image.Create(defaultOptions, 100, 100))
        {
            Graphics graphics = new Graphics(tiff);
            graphics.Clear(Aspose.Imaging.Color.LightGray);
            tiff.Save("default.tif");
        }

        // Create an LZW compressed TIFF
        using (TiffImage tiff = (TiffImage)Image.Create(lzwOptions, 100, 100))
        {
            Graphics graphics = new Graphics(tiff);
            graphics.Clear(Aspose.Imaging.Color.LightBlue);
            tiff.Save("lzw.tif");
        }

        // Create a CCITT compressed TIFF
        using (TiffImage tiff = (TiffImage)Image.Create(ccittOptions, 200, 200))
        {
            Graphics graphics = new Graphics(tiff);
            graphics.Clear(Aspose.Imaging.Color.White);
            tiff.Save("ccitt.tif");
        }

        // Create a JPEG compressed TIFF
        using (TiffImage tiff = (TiffImage)Image.Create(jpegOptions, 150, 150))
        {
            Graphics graphics = new Graphics(tiff);
            graphics.Clear(Aspose.Imaging.Color.LightGreen);
            tiff.Save("jpeg.tif");
        }

        // Create a BigTIFF image
        using (BigTiffImage bigTiff = (BigTiffImage)Image.Create(bigTiffOptions, 500, 500))
        {
            Graphics graphics = new Graphics(bigTiff);
            graphics.Clear(Aspose.Imaging.Color.LightCoral);
            bigTiff.Save("big.tif");
        }
    }
}