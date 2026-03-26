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
        // Hardcoded input SVG and intermediate/output BMP paths
        string inputSvgPath = @"C:\Images\input.svg";
        string intermediateBmpPath = @"C:\Images\temp.bmp";
        string outputBmpPath = @"C:\Images\output_rotated.bmp";

        // Verify input SVG exists
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(intermediateBmpPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

        // Load SVG, rasterize and save as BMP (intermediate file)
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Set rasterization options based on SVG size
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Save as BMP using BmpOptions with the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            svgImage.Save(intermediateBmpPath, bmpOptions);
        }

        // Load the BMP, rotate 90 degrees clockwise, and save final result
        using (BmpImage bmpImage = new BmpImage(intermediateBmpPath))
        {
            // Rotate 90 degrees clockwise without flipping
            bmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save rotated BMP
            bmpImage.Save(outputBmpPath);
        }
    }
}