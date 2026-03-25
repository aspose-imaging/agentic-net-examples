using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.apng";

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
            // Cast to multipage interface
            if (tiffImage is IMultipageImage multipage)
            {
                // Prepare APNG creation options with bound output file
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Assume all pages have the same dimensions as the first page
                int width = tiffImage.Width;
                int height = tiffImage.Height;

                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add each TIFF page as a frame with a unique delay
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Retrieve the page image
                        Image page = multipage.Pages[i];

                        // Cast to RasterImage for adding as a frame
                        RasterImage rasterPage = (RasterImage)page;

                        // Example unique delay: (i + 1) * 100 ms
                        uint frameDelay = (uint)((i + 1) * 100);

                        // Add the frame with the specified delay
                        apngImage.AddFrame(rasterPage, frameDelay);

                        // Dispose the page image after use
                        page.Dispose();
                    }

                    // Save the APNG (output file is already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
            else
            {
                Console.Error.WriteLine("The loaded image is not a multipage image.");
            }
        }
    }
}