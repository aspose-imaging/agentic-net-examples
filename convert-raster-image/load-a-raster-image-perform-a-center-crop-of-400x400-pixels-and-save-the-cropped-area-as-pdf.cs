using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input file exists
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
            // Determine the top‑left corner for a 400x400 center crop
            int cropWidth = 400;
            int cropHeight = 400;
            int left = (image.Width - cropWidth) / 2;
            int top = (image.Height - cropHeight) / 2;

            // Perform the crop
            var cropArea = new Rectangle(left, top, cropWidth, cropHeight);
            image.Crop(cropArea);

            // Save the cropped image as PDF
            var pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}