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
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apngImage = (ApngImage)image;

                // No frames? Exit gracefully
                if (apngImage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the APNG image.");
                    return;
                }

                // Prepare TIFF options (RGB, 8 bits per sample)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Use the first frame to create the TIFF image container
                RasterImage firstFrame = (RasterImage)apngImage.Pages[0];
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, firstFrame.Width, firstFrame.Height))
                {
                    // Add the first frame as the initial page
                    tiffImage.AddFrame(new TiffFrame(firstFrame));

                    // Add remaining frames
                    for (int i = 1; i < apngImage.PageCount; i++)
                    {
                        RasterImage frame = (RasterImage)apngImage.Pages[i];
                        TiffFrame tiffFrame = new TiffFrame(frame);
                        tiffImage.AddFrame(tiffFrame);
                    }

                    // Save the multi-page TIFF
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