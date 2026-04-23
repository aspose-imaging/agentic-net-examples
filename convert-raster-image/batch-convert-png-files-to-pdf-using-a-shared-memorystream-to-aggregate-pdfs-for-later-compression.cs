using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of PNG files to convert
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.png",
            @"C:\Images\image2.png",
            @"C:\Images\image3.png"
        };

        // Path for the aggregated PDF file
        string aggregatedPdfPath = @"C:\Output\combined.pdf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(aggregatedPdfPath));

        // Shared memory stream that will hold all PDF data
        using (MemoryStream sharedStream = new MemoryStream())
        {
            foreach (string inputPath in inputPaths)
            {
                // Verify the input PNG exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the image as PDF into the shared stream
                    image.Save(sharedStream, pdfOptions);
                }
            }

            // Write the aggregated PDF data to the final file
            sharedStream.Position = 0;
            using (FileStream fileStream = new FileStream(aggregatedPdfPath, FileMode.Create, FileAccess.Write))
            {
                sharedStream.CopyTo(fileStream);
            }
        }
    }
}