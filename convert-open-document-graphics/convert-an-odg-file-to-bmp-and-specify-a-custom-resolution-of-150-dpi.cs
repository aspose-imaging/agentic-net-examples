using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists before any save operation
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage to access specific features if needed
            OdgImage odgImage = (OdgImage)image;

            // Set up rasterization options for vector to raster conversion
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                // Use the original image size as the page size
                PageSize = odgImage.Size,
                // Optional: set background color
                BackgroundColor = Color.White
            };

            // Configure BMP save options and attach rasterization options
            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as BMP
            odgImage.Save(outputPath, bmpOptions);
        }

        // Load the saved BMP to adjust its resolution
        using (Image bmpImage = Image.Load(outputPath))
        {
            BmpImage bmp = (BmpImage)bmpImage;

            // Set custom resolution to 150 DPI for both axes
            bmp.SetResolution(150.0, 150.0);

            // Save the BMP again (overwrites the previous file)
            bmp.Save(outputPath);
        }
    }
}