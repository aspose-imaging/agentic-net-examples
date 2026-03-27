using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        string outputPath = @"C:\Temp\multiframe.tif";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Frame 1 options
        TiffOptions frameOptions1 = new TiffOptions(TiffExpectedFormat.Default);
        frameOptions1.BitsPerSample = new ushort[] { 8, 8, 8 };
        frameOptions1.Photometric = TiffPhotometrics.Rgb;
        frameOptions1.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        frameOptions1.Compression = TiffCompressions.Lzw;

        // Frame 2 options
        TiffOptions frameOptions2 = new TiffOptions(TiffExpectedFormat.Default);
        frameOptions2.BitsPerSample = new ushort[] { 8, 8, 8 };
        frameOptions2.Photometric = TiffPhotometrics.Rgb;
        frameOptions2.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        frameOptions2.Compression = TiffCompressions.Deflate;

        // Create frames
        TiffFrame frame1 = new TiffFrame(frameOptions1, 200, 200);
        TiffFrame frame2 = new TiffFrame(frameOptions2, 300, 300);

        // Fill frame 1 with solid blue
        int width1 = frame1.Width;
        int height1 = frame1.Height;
        Color[] pixels1 = new Color[width1 * height1];
        for (int i = 0; i < pixels1.Length; i++)
            pixels1[i] = Color.Blue;
        frame1.SavePixels(frame1.Bounds, pixels1);

        // Fill frame 2 with solid red
        int width2 = frame2.Width;
        int height2 = frame2.Height;
        Color[] pixels2 = new Color[width2 * height2];
        for (int i = 0; i < pixels2.Length; i++)
            pixels2[i] = Color.Red;
        frame2.SavePixels(frame2.Bounds, pixels2);

        // Create multi‑frame TIFF and save
        using (TiffImage tiffImage = new TiffImage(new TiffFrame[] { frame1, frame2 }))
        {
            tiffImage.Save(outputPath);
        }
    }
}