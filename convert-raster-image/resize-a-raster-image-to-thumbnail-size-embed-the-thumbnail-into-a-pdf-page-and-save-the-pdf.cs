using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.jpg";
        string outputPath = @"C:\Output\thumbnail.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to perform resizing
            if (image is RasterImage rasterImage)
            {
                // Resize to thumbnail dimensions (e.g., 150x150)
                rasterImage.Resize(150, 150);
            }

            // Prepare PDF export options
            var pdfOptions = new PdfOptions
            {
                // Optional: set page size to match the thumbnail
                PageSize = new SizeF(150, 150)
            };

            // Save the resized image as a PDF page
            image.Save(outputPath, pdfOptions);
        }
    }
}