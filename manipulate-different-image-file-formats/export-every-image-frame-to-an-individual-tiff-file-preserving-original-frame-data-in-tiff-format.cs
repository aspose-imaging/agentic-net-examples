using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Path to the source multi‑frame image (e.g., GIF, TIFF, etc.)
        string inputPath = @"C:\Images\input.gif";

        // Directory where individual TIFF frames will be saved
        string outputDir = @"C:\Images\Frames\";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the source image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Check if the loaded image supports multiple pages/frames
            if (image is IMultipageImage multipage)
            {
                // Iterate through each page/frame
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Retrieve the current page as a separate Image instance
                    using (Image page = multipage.Pages[i])
                    {
                        // Create a TIFF frame from the page's raster data
                        using (TiffFrame tiffFrame = new TiffFrame(page as RasterImage))
                        {
                            // Wrap the frame into a TiffImage (single‑frame TIFF)
                            using (TiffImage tiffImage = new TiffImage(tiffFrame))
                            {
                                // Build the output file name (e.g., frame_1.tif)
                                string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.tif");

                                // Save the TIFF image using Aspose.Imaging's save rule
                                tiffImage.Save(outputPath);
                            }
                        }
                    }
                }
            }
            else
            {
                // The source image has only one frame; save it directly as TIFF
                string outputPath = Path.Combine(outputDir, "frame_1.tif");
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
            }
        }
    }
}