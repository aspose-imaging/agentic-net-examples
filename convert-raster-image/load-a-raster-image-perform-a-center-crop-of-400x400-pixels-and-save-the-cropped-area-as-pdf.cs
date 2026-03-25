using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to use Crop
            RasterImage raster = (RasterImage)image;

            // Define a 400x400 centre crop rectangle
            const int cropWidth = 400;
            const int cropHeight = 400;

            // Calculate top‑left corner so the rectangle is centred
            int left = Math.Max(0, (raster.Width - cropWidth) / 2);
            int top = Math.Max(0, (raster.Height - cropHeight) / 2);

            // If the source image is smaller than the desired crop size,
            // adjust the rectangle size to the image dimensions
            int actualWidth = Math.Min(cropWidth, raster.Width);
            int actualHeight = Math.Min(cropHeight, raster.Height);

            var area = new Rectangle(left, top, actualWidth, actualHeight);

            // Perform the crop
            raster.Crop(area);

            // Save the cropped area as PDF
            var pdfOptions = new PdfOptions();
            raster.Save(outputPath, pdfOptions);
        }
    }
}