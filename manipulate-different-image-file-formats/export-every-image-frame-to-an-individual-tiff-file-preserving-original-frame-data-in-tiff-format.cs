using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class ExportFramesToTiff
{
    static void Main()
    {
        // Path to the source multi‑frame image (any supported format)
        string sourcePath = @"C:\Images\multiframe_input.tif";

        // Load the source image
        using (Image sourceImage = Image.Load(sourcePath))
        {
            // Ensure the image supports multiple pages/frames
            if (sourceImage is IMultipageImage multipage && multipage.PageCount > 0)
            {
                // Iterate through each frame/page
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Retrieve the current page as a RasterImage
                    using (RasterImage page = multipage.Pages[i] as RasterImage)
                    {
                        // Create a TIFF frame from the raster page
                        TiffFrame tiffFrame = new TiffFrame(page);

                        // Wrap the frame in a TiffImage
                        using (TiffImage tiffImage = new TiffImage(tiffFrame))
                        {
                            // Build the output file name (e.g., frame_0.tif, frame_1.tif, ...)
                            string outputPath = $@"C:\Images\frame_{i}.tif";

                            // Save the single‑frame TIFF image
                            tiffImage.Save(outputPath);
                        }

                        // The TiffImage disposes the frame automatically,
                        // but we can explicitly dispose the frame if desired:
                        // tiffFrame.Dispose();
                    }
                }
            }
            else
            {
                Console.WriteLine("The loaded image does not contain multiple frames.");
            }
        }
    }
}