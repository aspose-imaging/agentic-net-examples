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

                // Process the first frame to obtain dimensions
                RasterImage firstFrame = (RasterImage)webpImage.Pages[0];
                int frameWidth = firstFrame.Width;
                int frameHeight = firstFrame.Height;

                // Prepare TIFF options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Create a TIFF image with the size of the frames
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, frameWidth, frameHeight))
                {
                    // Save pixels of the first frame into the initial TIFF frame
                    tiffImage.SavePixels(tiffImage.ActiveFrame.Bounds, firstFrame.LoadPixels(firstFrame.Bounds));

                    // Iterate remaining frames and add them to the TIFF
                    for (int i = 1; i < multipage.PageCount; i++)
                    {
                        // Add a new blank frame to the TIFF
                        tiffImage.AddFrame(new TiffFrame(tiffOptions, frameWidth, frameHeight));

                        // Retrieve the current WebP frame as a raster image
                        RasterImage currentFrame = (RasterImage)webpImage.Pages[i];

                        // Save pixels into the newly added TIFF frame
                        tiffImage.Frames[i].SavePixels(tiffImage.Frames[i].Bounds, currentFrame.LoadPixels(currentFrame.Bounds));
                    }

                    // Save the assembled multi-page TIFF to disk
                    tiffImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract each frame from an animated WebP file and store them as separate pages in a multi‑page TIFF for archival or printing purposes.
 * 2. When a web application must convert user‑uploaded WebP animations into a TIFF format that preserves all frames for compatibility with legacy image viewers.
 * 3. When an image‑processing pipeline requires splitting a WebP animation into individual raster images before applying per‑frame transformations and then re‑assembling them into a single TIFF document.
 * 4. When a digital asset management system needs to ingest animated WebP assets and generate a multi‑page TIFF preview that can be indexed by search engines.
 * 5. When a developer wants to programmatically validate the dimensions of a WebP animation’s first frame and create a TIFF file with matching size to ensure consistent layout in a reporting tool.
 */