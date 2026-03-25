using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input CMX file and desired output format
        string inputPath = "sample.cmx";
        string outputFormat = "png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Determine output file path based on requested format
        string outputPath = Path.ChangeExtension(inputPath, outputFormat);

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Save using the appropriate options for the requested format
            if (outputFormat.Equals("png", StringComparison.OrdinalIgnoreCase))
            {
                image.Save(outputPath, new PngOptions());
            }
            else if (outputFormat.Equals("jpg", StringComparison.OrdinalIgnoreCase) ||
                     outputFormat.Equals("jpeg", StringComparison.OrdinalIgnoreCase))
            {
                image.Save(outputPath, new JpegOptions());
            }
            else if (outputFormat.Equals("bmp", StringComparison.OrdinalIgnoreCase))
            {
                image.Save(outputPath, new BmpOptions());
            }
            else if (outputFormat.Equals("gif", StringComparison.OrdinalIgnoreCase))
            {
                image.Save(outputPath, new GifOptions());
            }
            else if (outputFormat.Equals("webp", StringComparison.OrdinalIgnoreCase))
            {
                image.Save(outputPath, new WebPOptions());
            }
            else if (outputFormat.Equals("tiff", StringComparison.OrdinalIgnoreCase))
            {
                image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
            }
            else
            {
                // Fallback to PNG if format is unsupported
                image.Save(outputPath, new PngOptions());
            }
        }
    }
}