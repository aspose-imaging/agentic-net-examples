using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG path
        string inputSvgPath = @"C:\temp\input.svg";

        // Verify input file exists
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Temporary BMP path (result of SVG conversion)
        string tempBmpPath = @"C:\temp\temp.bmp";

        // Ensure directory for temporary BMP exists
        Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));

        // Load SVG and save as BMP
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24 // 24‑bpp BMP
            };
            svgImage.Save(tempBmpPath, bmpOptions);
        }

        // Final rotated BMP output path
        string outputBmpPath = @"C:\temp\rotated.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

        // Load the BMP, rotate 90° clockwise, and save
        using (BmpImage bmpImage = new BmpImage(tempBmpPath))
        {
            bmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bmpImage.Save(outputBmpPath);
        }

        // Optional: clean up temporary file
        try
        {
            File.Delete(tempBmpPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}