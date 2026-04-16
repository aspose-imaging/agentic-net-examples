using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf; // Ensure PDF format support
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access cropping functionality
            RasterImage rasterImage = (RasterImage)image;

            // Determine the top-left corner of the 200x200 central region
            int cropWidth = 200;
            int cropHeight = 200;
            int left = (rasterImage.Width - cropWidth) / 2;
            int top = (rasterImage.Height - cropHeight) / 2;

            // Create the cropping rectangle
            Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight);

            // Perform the crop
            rasterImage.Crop(cropArea);

            // Save the cropped image as PDF
            PdfOptions pdfOptions = new PdfOptions(); // Default PDF options
            rasterImage.Save(outputPath, pdfOptions);
        }
    }
}