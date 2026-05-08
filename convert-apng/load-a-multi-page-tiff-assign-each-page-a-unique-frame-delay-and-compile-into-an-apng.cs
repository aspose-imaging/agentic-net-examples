using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\multi.tif";
            string outputPath = "Output\\animated.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Check that the loaded image supports multiple pages
                if (tiffImage is IMultipageImage multiPage)
                {
                    // Use size of the first page for the APNG canvas
                    int width = multiPage.Pages[0].Width;
                    int height = multiPage.Pages[0].Height;

                    // Prepare APNG creation options
                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create the APNG image
                    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                    {
                        // Remove the default empty frame
                        apngImage.RemoveAllFrames();

                        // Add each TIFF page as a frame with a unique delay
                        for (int i = 0; i < multiPage.PageCount; i++)
                        {
                            // Cast page to RasterImage and ensure it is cached
                            RasterImage pageImage = (RasterImage)multiPage.Pages[i];
                            if (!pageImage.IsCached)
                                pageImage.CacheData();

                            // Example unique delay: 100 ms increments
                            uint frameDelay = (uint)((i + 1) * 100);

                            // Add the frame with the specified delay
                            apngImage.AddFrame(pageImage, frameDelay);
                        }

                        // Save the resulting APNG
                        apngImage.Save();
                    }
                }
                else
                {
                    Console.Error.WriteLine("The input image is not a multipage image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}