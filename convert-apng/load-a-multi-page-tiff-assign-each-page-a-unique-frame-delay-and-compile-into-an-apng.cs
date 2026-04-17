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
        string inputPath = "Input/multipage.tif";
        string outputPath = "Output/animation.apng";

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
            if (tiffImage is IMultipageImage multipageImage)
            {
                // Obtain dimensions from the first page
                RasterImage firstPage = (RasterImage)multipageImage.Pages[0];
                int width = firstPage.Width;
                int height = firstPage.Height;

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apngImage.RemoveAllFrames();

                    // Add each TIFF page as a frame with a unique delay
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        using (RasterImage page = (RasterImage)multipageImage.Pages[i])
                        {
                            uint frameDelay = (uint)((i + 1) * 100);
                            apngImage.AddFrame(page, frameDelay);
                        }
                    }

                    // Save the APNG (output path already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
        }
    }
}