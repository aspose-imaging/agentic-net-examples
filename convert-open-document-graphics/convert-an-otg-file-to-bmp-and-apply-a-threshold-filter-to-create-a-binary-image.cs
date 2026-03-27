using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string bmpOutputPath = @"C:\Images\sample.bmp";
        string binaryOutputPath = @"C:\Images\sample_binary.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(bmpOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(binaryOutputPath));

        // Load OTG image and save as BMP using rasterization options
        using (Image otgImage = Image.Load(inputPath))
        {
            var bmpOptions = new BmpOptions();
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            bmpOptions.VectorRasterizationOptions = otgRasterOptions;

            otgImage.Save(bmpOutputPath, bmpOptions);
        }

        // Load the BMP, apply Otsu thresholding, and save the binary image
        using (Image bmpImage = Image.Load(bmpOutputPath))
        {
            var rasterImage = bmpImage as RasterImage;
            if (rasterImage != null)
            {
                rasterImage.BinarizeOtsu();

                var bmpOptions = new BmpOptions();
                rasterImage.Save(binaryOutputPath, bmpOptions);
            }
        }
    }
}