using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\CroppedOutput.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for cropping
            RasterImage rasterImage = (RasterImage)image;

            // Determine the top‑left corner of a 200x200 rectangle centered in the image
            int cropWidth = 200;
            int cropHeight = 200;
            int left = (rasterImage.Width - cropWidth) / 2;
            int top = (rasterImage.Height - cropHeight) / 2;

            // Create the cropping rectangle
            Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight);

            // Perform the crop
            rasterImage.Crop(cropArea);

            // Save the cropped image as PDF
            PdfOptions pdfOptions = new PdfOptions();
            rasterImage.Save(outputPath, pdfOptions);
        }
    }
}