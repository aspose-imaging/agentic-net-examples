using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
            // Apply a correction filter (sharpen) to the entire image
            var filterOptions = new SharpenFilterOptions();
            source.Filter(source.Bounds, filterOptions);

            // Set up APNG creation options, preserving transparency
            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 1000 // 1 second per frame (single-frame animation)
            };

            // Create the APNG image and add the filtered frame
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, source.Width, source.Height))
            {
                apng.RemoveAllFrames();          // Remove default frame
                apng.AddFrame(source);           // Add the filtered image as the only frame
                apng.Save();                     // Save the APNG file
            }
        }
    }
}