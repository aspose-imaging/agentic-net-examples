using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.webp";
            string bmpPath = "Output/sample.bmp";
            string tiffPath = "Output/sample.tiff";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));

            // Load WebP image and save as BMP
            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    webpImage.Save(bmpPath, bmpOptions);
                }
            }

            // Load the BMP image and save as TIFF with LZW compression
            using (Image bmpImage = Image.Load(bmpPath))
            {
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    bmpImage.Save(tiffPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}