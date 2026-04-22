using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.png";

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
                TiffImage tiff = (TiffImage)tiffImage;
                TiffFrame[] frames = tiff.Frames;

                if (frames.Length == 0)
                {
                    Console.Error.WriteLine("No frames found in the TIFF image.");
                    return;
                }

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create an APNG image using the dimensions of the first frame
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    apngOptions,
                    frames[0].Width,
                    frames[0].Height))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Add each TIFF frame as an APNG frame
                    foreach (TiffFrame tiffFrame in frames)
                    {
                        // Cast the frame to RasterImage (TiffFrame derives from RasterImage)
                        RasterImage raster = (RasterImage)tiffFrame;

                        // Determine frame duration based on resolution (example: area / 1000, minimum 100 ms)
                        uint frameDuration = Math.Max(100u, (uint)(raster.Width * raster.Height / 1000));

                        // Set the default frame time for the next added frame
                        apngImage.DefaultFrameTime = frameDuration;

                        // Add the frame to the APNG
                        apngImage.AddFrame(raster);
                    }

                    // Save the APNG file
                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}