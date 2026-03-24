using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image (could be animated)
        using (Image image = Image.Load(inputPath))
        {
            // Check if the image has multiple pages (animation)
            if (image is IMultipageImage multipage)
            {
                // Use the dimensions of the first frame for the APNG canvas
                using (RasterImage firstFrame = (RasterImage)multipage.Pages[0])
                {
                    int width = firstFrame.Width;
                    int height = firstFrame.Height;

                    // Prepare APNG creation options
                    ApngOptions createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = 100, // 100 ms per frame
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create the APNG image
                    using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                    {
                        apngImage.RemoveAllFrames();

                        // Process each frame: apply blur and add to APNG
                        foreach (var page in multipage.Pages)
                        {
                            using (RasterImage raster = (RasterImage)page)
                            {
                                // Apply Gaussian blur filter
                                raster.Filter(raster.Bounds,
                                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

                                apngImage.AddFrame(raster);
                            }
                        }

                        // Save the animated PNG
                        apngImage.Save();
                    }
                }
            }
            else
            {
                // Single-frame image handling
                using (RasterImage raster = (RasterImage)image)
                {
                    // Apply Gaussian blur filter
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

                    // Prepare APNG creation options
                    ApngOptions createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = 100,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create the APNG image
                    using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, raster.Width, raster.Height))
                    {
                        apngImage.RemoveAllFrames();
                        apngImage.AddFrame(raster);
                        apngImage.Save();
                    }
                }
            }
        }
    }
}