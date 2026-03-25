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
        string inputPath = "input.tif";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

        // Load the multi‑page TIFF
        using (Image tiffImage = Image.Load(inputPath))
        {
            if (tiffImage is IMultipageImage multipage)
            {
                // Use the first page to define canvas size
                using (RasterImage firstPage = (RasterImage)multipage.Pages[0])
                {
                    int canvasWidth = firstPage.Width;
                    int canvasHeight = firstPage.Height;

                    // Prepare APNG creation options
                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create the APNG image
                    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
                    {
                        apngImage.RemoveAllFrames();

                        // Iterate through each TIFF page
                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            using (RasterImage page = (RasterImage)multipage.Pages[i])
                            {
                                apngImage.AddFrame(page);
                                ApngFrame addedFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                                double avgResolution = (page.HorizontalResolution + page.VerticalResolution) / 2.0;
                                uint frameDuration = (uint)(avgResolution * 10);
                                addedFrame.FrameTime = (int)frameDuration;
                            }
                        }

                        // Save the resulting APNG
                        apngImage.Save();
                    }
                }
            }
        }
    }
}