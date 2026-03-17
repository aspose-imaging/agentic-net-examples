using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        // Input DNG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.dng";
        // Output JPG file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.jpg";

        // Load DNG image
        using (DngImage dng = (DngImage)Image.Load(inputPath))
        {
            // Ensure image data is cached before processing
            if (!dng.IsCached)
                dng.CacheData();

            // Adjust brightness (+20)
            dng.AdjustBrightness(20);
            // Adjust contrast (+0.2)
            dng.AdjustContrast(0.2f);
            // Rotate 15 degrees, resize canvas to fit, fill background with light gray
            dng.Rotate(15f, true, Color.LightGray);

            // Save processed image as JPEG (DNG cannot be saved as DNG)
            dng.Save(outputPath, new JpegOptions());
        }
    }
}