using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.png";
        string outputPath = "Output/zoomed.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for cropping operations
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Cache data for better performance
            if (!raster.IsCached)
                raster.CacheData();

            // Calculate a central rectangle that is 90% of the original size (10% zoom)
            int cropWidth = (int)(raster.Width * 0.9);
            int cropHeight = (int)(raster.Height * 0.9);
            int offsetX = (raster.Width - cropWidth) / 2;
            int offsetY = (raster.Height - cropHeight) / 2;
            Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(offsetX, offsetY, cropWidth, cropHeight);

            // Perform the crop
            raster.Crop(cropRect);

            // Save the cropped region as a PDF document
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                raster.Save(outputPath, pdfOptions);
            }
        }
    }
}