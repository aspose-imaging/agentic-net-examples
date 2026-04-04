using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // Check for alpha channel if the format supports it
            bool hasAlpha = false;
            if (image is DjvuImage djvuImg)
                hasAlpha = djvuImg.HasAlpha;
            else if (image is DicomImage dicomImg)
                hasAlpha = dicomImg.HasAlpha;

            Console.WriteLine($"Alpha channel present: {hasAlpha}");

            // Apply dithering (requires RasterImage)
            if (image is RasterImage rasterImg)
                rasterImg.Dither(DitheringMethod.FloydSteinbergDithering, 8);

            // Save the processed image as GIF
            image.Save(outputPath, new GifOptions());
        }
    }
}