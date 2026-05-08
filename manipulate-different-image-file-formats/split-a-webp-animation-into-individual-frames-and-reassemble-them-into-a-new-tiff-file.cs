using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input_animation.webp";
            string outputPath = "output_frames.tif";

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
                int frameCount = (multipage != null) ? multipage.PageCount : 1;

                // Determine canvas size from the source image
                int width = webpImage.Width;
                int height = webpImage.Height;

                // Prepare TIFF options with a FileCreateSource
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                // Create the TIFF image canvas
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Process each frame from the WebP animation
                    for (int i = 0; i < frameCount; i++)
                    {
                        // Retrieve the raster image for the current frame
                        RasterImage frameRaster = (RasterImage)webpImage.Pages[i];

                        // Load pixel data from the frame
                        Color[] pixels = frameRaster.LoadPixels(frameRaster.Bounds);

                        if (i == 0)
                        {
                            // Replace the default frame with the first animation frame
                            tiffImage.SavePixels(tiffImage.ActiveFrame.Bounds, pixels);
                        }
                        else
                        {
                            // Add a new blank frame to the TIFF
                            tiffImage.AddFrame(new TiffFrame(tiffOptions, width, height));

                            // Set the newly added frame as active
                            tiffImage.ActiveFrame = tiffImage.Frames[tiffImage.Frames.Length - 1];

                            // Copy pixel data into the new frame
                            tiffImage.SavePixels(tiffImage.ActiveFrame.Bounds, pixels);
                        }

                        // Dispose the raster frame after use
                        frameRaster.Dispose();
                    }

                    // Save the assembled TIFF file
                    tiffImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}