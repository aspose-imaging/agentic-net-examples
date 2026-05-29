using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\multi.tif";
            string outputPath = "Output\\output.apng";

            // Validate input file existence
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
                if (tiffImage is IMultipageImage multipage)
                {
                    // Determine canvas size from the first page
                    Image firstPage = multipage.Pages[0];
                    int canvasWidth = firstPage.Width;
                    int canvasHeight = firstPage.Height;
                    firstPage.Dispose();

                    // Prepare APNG creation options
                    ApngOptions createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    // Create APNG image
                    using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
                    {
                        // Remove the default frame
                        apngImage.RemoveAllFrames();

                        // Add each TIFF page as a frame with duration based on its resolution
                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            Image page = multipage.Pages[i];
                            RasterImage rasterPage = (RasterImage)page;

                            // Add the raster page as a frame
                            apngImage.AddFrame(rasterPage);

                            // Retrieve the newly added frame
                            ApngFrame apngFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                            // Calculate frame duration (ms) from horizontal resolution; fallback to 72 DPI if undefined
                            double hDpi = rasterPage.HorizontalResolution > 0 ? rasterPage.HorizontalResolution : 72;
                            int frameDuration = (int)(1000 / hDpi);
                            apngFrame.FrameTime = frameDuration;

                            // Dispose the page after use
                            rasterPage.Dispose();
                        }

                        // Save the APNG file
                        apngImage.Save();
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}