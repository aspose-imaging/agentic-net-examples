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

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply a sequence of filters to the source image
            sourceImage.Filter(sourceImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            sourceImage.Filter(sourceImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            sourceImage.Filter(sourceImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default frame that exists upon creation
                apngImage.RemoveAllFrames();

                // Add the filtered image as the first frame
                apngImage.AddFrame(sourceImage);

                // Add additional frames with slight gamma adjustments
                int extraFrames = 4;
                for (int i = 0; i < extraFrames; i++)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    frame.FrameTime = 100; // consistent frame duration
                    frame.AdjustGamma(i);   // simple gamma variation per frame
                }

                // Save the APNG (output path is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}