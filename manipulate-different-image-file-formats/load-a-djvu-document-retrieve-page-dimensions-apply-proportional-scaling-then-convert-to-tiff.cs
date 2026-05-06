using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Define a proportional scaling factor (e.g., 50%)
                const double scaleFactor = 0.5;

                // Iterate through each page in the DjVu document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Retrieve original dimensions
                    int originalWidth = page.Width;
                    int originalHeight = page.Height;

                    // Calculate new dimensions while preserving aspect ratio
                    int newWidth = (int)(originalWidth * scaleFactor);
                    int newHeight = (int)(originalHeight * scaleFactor);

                    // Resize the page proportionally
                    page.Resize(newWidth, newHeight);

                    // Prepare output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.tiff");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the resized page as TIFF
                    TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                    page.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}