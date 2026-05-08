using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputSvgPath = @"C:\Images\input.svg";
            string tempBmpPath = @"C:\Images\temp.bmp";
            string outputBmpPath = @"C:\Images\rotated.bmp";

            // Verify input SVG exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                // Set rasterization options for BMP conversion
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save SVG as BMP to a temporary file
                svgImage.Save(tempBmpPath, bmpOptions);
            }

            // Load the temporary BMP image
            using (Image bmpImage = Image.Load(tempBmpPath))
            {
                // Rotate 90 degrees clockwise
                bmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the rotated BMP to the final output path
                bmpImage.Save(outputBmpPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}