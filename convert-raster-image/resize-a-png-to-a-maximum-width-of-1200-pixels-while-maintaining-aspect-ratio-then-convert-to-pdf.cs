using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Determine if resizing is needed (max width 1200)
                const int maxWidth = 1200;
                if (image.Width > maxWidth)
                {
                    // Calculate new height to maintain aspect ratio
                    double scale = (double)maxWidth / image.Width;
                    int newHeight = (int)Math.Round(image.Height * scale);

                    // Resize the image
                    image.Resize(maxWidth, newHeight);
                }

                // Convert and save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}