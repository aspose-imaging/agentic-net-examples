using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? string.Empty);

        // Load the vector image
        using (VectorImage vectorImage = (VectorImage)Image.Load(inputPath))
        {
            // Remove background from the vector image
            vectorImage.RemoveBackground();

            // Rasterize the vector image to a PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Prepare APNG creation options
                    var apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = 500, // 500 ms per frame
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create the APNG image
                    using (ApngImage apngImage = (ApngImage)Image.Create(
                        apngOptions,
                        rasterImage.Width,
                        rasterImage.Height))
                    {
                        // Remove the default frame and add our rasterized frame
                        apngImage.RemoveAllFrames();
                        apngImage.AddFrame(rasterImage);

                        // Save the APNG file
                        apngImage.Save();
                    }
                }
            }
        }
    }
}