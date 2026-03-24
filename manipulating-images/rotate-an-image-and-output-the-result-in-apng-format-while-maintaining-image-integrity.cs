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
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as a raster image
        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!source.IsCached) source.CacheData();

            // Set up APNG creation options with output binding
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG image canvas
            using (ApngImage apng = (ApngImage)Image.Create(createOptions, source.Width, source.Height))
            {
                // Remove default frame and add the source as the first frame
                apng.RemoveAllFrames();
                apng.AddFrame(source);

                // Rotate the image 90 degrees clockwise, resize proportionally, transparent background
                apng.Rotate(90f, true, Color.Transparent);

                // Save the APNG (output path already bound via FileCreateSource)
                apng.Save();
            }
        }
    }
}