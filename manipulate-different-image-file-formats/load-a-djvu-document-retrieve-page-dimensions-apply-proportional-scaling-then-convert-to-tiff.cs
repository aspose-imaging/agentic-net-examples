using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDirectory = "output";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            int pageIndex = 1;
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Retrieve original page dimensions
                int originalWidth = page.Width;
                int originalHeight = page.Height;

                // Define a proportional scaling factor (e.g., 50% reduction)
                double scaleFactor = 0.5;
                int newWidth = (int)(originalWidth * scaleFactor);
                int newHeight = (int)(originalHeight * scaleFactor);

                // Apply proportional scaling to the page
                page.Resize(newWidth, newHeight);

                // Build the output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.tiff");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the scaled page as a TIFF image
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                page.Save(outputPath, tiffOptions);

                pageIndex++;
            }
        }
    }
}