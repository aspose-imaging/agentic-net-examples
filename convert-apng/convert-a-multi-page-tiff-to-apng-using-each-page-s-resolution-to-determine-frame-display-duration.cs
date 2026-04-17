using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/multipage.tif";
        string outputPath = "output/animation.apng";

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
            if (tiffImage is IMultipageImage multipage)
            {
                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Use the first page to define canvas size
                using (RasterImage firstPage = (RasterImage)multipage.Pages[0])
                {
                    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, firstPage.Width, firstPage.Height))
                    {
                        // Remove the default frame that exists upon creation
                        apngImage.RemoveAllFrames();

                        // Add each TIFF page as a frame, setting duration based on resolution
                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            using (RasterImage page = (RasterImage)multipage.Pages[i])
                            {
                                apngImage.AddFrame(page);

                                // Retrieve the frame just added
                                ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                                // Example: duration inversely proportional to horizontal DPI
                                uint duration = (uint)(1000.0 / page.HorizontalResolution);
                                frame.FrameTime = (int)duration;
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