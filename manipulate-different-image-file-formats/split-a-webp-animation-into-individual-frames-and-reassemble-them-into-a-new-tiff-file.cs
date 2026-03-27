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
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "Output\\output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (WebPImage webp = new WebPImage(inputPath))
        {
            // Verify that the image supports multiple pages/frames
            IMultipageImage multipage = webp as IMultipageImage;
            if (multipage == null || multipage.PageCount == 0)
            {
                Console.Error.WriteLine("The provided WebP image does not contain animation frames.");
                return;
            }

            // Dimensions of frames (assumed uniform)
            RasterImage firstRaster = (RasterImage)multipage.Pages[0];
            int width = firstRaster.Width;
            int height = firstRaster.Height;

            // Prepare TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Create the first TIFF frame
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Save pixels of the first frame
                TiffFrame tiffFrame0 = tiff.Frames[0];
                tiffFrame0.SavePixels(tiffFrame0.Bounds, firstRaster.LoadPixels(firstRaster.Bounds));

                // Process remaining frames
                for (int i = 1; i < multipage.PageCount; i++)
                {
                    // Add a new blank frame to the TIFF
                    tiff.AddFrame(new TiffFrame(tiffOptions, width, height));

                    // Load raster data of the current WebP frame
                    RasterImage raster = (RasterImage)multipage.Pages[i];

                    // Save its pixels into the corresponding TIFF frame
                    TiffFrame tiffFrame = tiff.Frames[i];
                    tiffFrame.SavePixels(tiffFrame.Bounds, raster.LoadPixels(raster.Bounds));
                }

                // Save the assembled multi-page TIFF
                tiff.Save(outputPath);
            }
        }
    }
}