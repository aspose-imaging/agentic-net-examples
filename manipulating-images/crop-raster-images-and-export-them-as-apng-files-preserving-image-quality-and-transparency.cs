using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Optional: cache data for better performance
            if (!sourceImage.IsCached)
                sourceImage.CacheData();

            // Define crop rectangle (example: 10px inset from each side)
            int cropLeft = 10;
            int cropTop = 10;
            int cropWidth = Math.Max(0, sourceImage.Width - 2 * cropLeft);
            int cropHeight = Math.Max(0, sourceImage.Height - 2 * cropTop);
            Rectangle cropRect = new Rectangle(cropLeft, cropTop, cropWidth, cropHeight);

            // Crop the image
            sourceImage.Crop(cropRect);

            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 1000 // 1 second per frame
            };

            // Create APNG image bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove default frame and add the cropped image as the sole frame
                apngImage.RemoveAllFrames();
                apngImage.AddFrame(sourceImage);

                // Save the APNG (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}