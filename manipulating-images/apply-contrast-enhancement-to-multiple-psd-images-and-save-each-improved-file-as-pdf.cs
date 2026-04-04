using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        // List of PSD files to process
        string[] psdFiles = new[]
        {
            "image1.psd",
            "image2.psd",
            "image3.psd"
        };

        foreach (string fileName in psdFiles)
        {
            // Build full input and output paths
            string inputPath = Path.Combine(inputDir, fileName);
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".pdf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Apply contrast enhancement if the image supports raster operations
                if (image is RasterImage rasterImage)
                {
                    // Increase contrast by 30 (value range depends on library; adjust as needed)
                    rasterImage.AdjustContrast(30);
                }

                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the enhanced image as PDF
                image.Save(outputPath, pdfOptions);
            }

            Console.WriteLine($"Processed and saved: {outputPath}");
        }
    }
}