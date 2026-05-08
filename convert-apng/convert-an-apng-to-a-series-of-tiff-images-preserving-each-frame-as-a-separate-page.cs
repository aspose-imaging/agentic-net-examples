using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the APNG image
            using (Image loadedImage = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apngImage = (ApngImage)loadedImage;

                // Prepare TIFF options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Ensure there is at least one frame
                if (apngImage.PageCount == 0)
                {
                    Console.Error.WriteLine("APNG contains no frames.");
                    return;
                }

                // Create the first TIFF frame from the first APNG frame
                RasterImage firstFrame = (RasterImage)apngImage.Pages[0];
                TiffFrame firstTiffFrame = new TiffFrame(firstFrame);

                // Create the multi-page TIFF image with the first frame
                using (TiffImage tiffImage = new TiffImage(firstTiffFrame))
                {
                    // Add remaining frames, if any
                    for (int i = 1; i < apngImage.PageCount; i++)
                    {
                        RasterImage frame = (RasterImage)apngImage.Pages[i];
                        TiffFrame tiffFrame = new TiffFrame(frame);
                        tiffImage.AddFrame(tiffFrame);
                    }

                    // Save the resulting TIFF file
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