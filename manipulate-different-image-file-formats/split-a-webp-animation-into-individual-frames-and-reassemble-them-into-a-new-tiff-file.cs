using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\animation.webp";
            string outputPath = "Output\\result.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = webpImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The WebP image does not contain any frames.");
                    return;
                }

                // Get dimensions from the first frame
                RasterImage firstFrame = multipage.Pages[0] as RasterImage;
                if (firstFrame == null)
                {
                    Console.Error.WriteLine("Unable to retrieve the first frame as a raster image.");
                    return;
                }
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                // Prepare TIFF options
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    // Create a new TIFF image canvas
                    using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                    {
                        // Iterate through each WebP frame and copy its pixels to the TIFF
                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            RasterImage frame = multipage.Pages[i] as RasterImage;
                            if (frame == null)
                                continue;

                            // Add a new frame to the TIFF after the first one
                            if (i > 0)
                            {
                                tiffImage.AddFrame(new TiffFrame(tiffOptions, width, height));
                            }

                            // Copy pixel data
                            var pixels = frame.LoadPixels(frame.Bounds);
                            tiffImage.Frames[i].SavePixels(tiffImage.Frames[i].Bounds, pixels);
                        }

                        // Save the assembled TIFF file
                        tiffImage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}