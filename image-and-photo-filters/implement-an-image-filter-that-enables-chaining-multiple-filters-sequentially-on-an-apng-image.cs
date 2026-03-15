using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output_apng.png";

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Define a list of filter options to be applied sequentially
            var filterOptions = new List<Aspose.Imaging.ImageFilters.FilterOptions.FilterOptionsBase>
            {
                new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5),
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0),
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0)
            };

            // Create APNG options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add the original (unfiltered) frame as the first frame
                apngImage.AddFrame(sourceImage);

                // Generate frames with cumulative filters
                for (int i = 0; i < filterOptions.Count; i++)
                {
                    // Load a fresh copy of the source image for each frame
                    using (RasterImage frame = (RasterImage)Image.Load(inputPath))
                    {
                        // Apply all filters up to the current index (cumulative effect)
                        for (int j = 0; j <= i; j++)
                        {
                            frame.Filter(frame.Bounds, filterOptions[j]);
                        }

                        // Add the processed frame to the APNG
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the APNG image
                apngImage.Save();
            }
        }
    }
}