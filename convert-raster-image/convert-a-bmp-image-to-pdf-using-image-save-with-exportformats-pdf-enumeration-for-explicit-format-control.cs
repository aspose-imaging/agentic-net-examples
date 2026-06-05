using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input and output file paths.
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.pdf";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image.
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options.
                PdfOptions pdfOptions = new PdfOptions();

                // Save the image as PDF using the explicit format control.
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any error message without crashing the application.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}