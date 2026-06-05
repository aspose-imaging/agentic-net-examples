using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string outputPath = "output\\converted.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Preserve orientation value if present
                var originalOrientation = otgImage.ExifData?.Orientation;

                // Set up rasterization options for OTG to JPEG conversion
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                // JPEG save options with vector rasterization
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save the rasterized image as JPEG
                otgImage.Save(outputPath, jpegOptions);

                // If the original image had EXIF orientation, copy it to the JPEG
                if (originalOrientation.HasValue)
                {
                    // Reload the saved JPEG to set EXIF data
                    using (JpegImage jpegImage = (JpegImage)Image.Load(outputPath))
                    {
                        jpegImage.ExifData.Orientation = originalOrientation.Value;
                        // Overwrite the JPEG with updated EXIF orientation
                        jpegImage.Save(outputPath);
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