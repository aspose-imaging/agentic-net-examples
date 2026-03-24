using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded output PDF file
        string outputPath = @"C:\Output\merged.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary directory for BMP conversions
        string tempBmpDir = Path.Combine(Path.GetTempPath(), "AsposeBmpTemp");
        Directory.CreateDirectory(tempBmpDir);

        // List to hold BMP images
        List<Image> bmpImages = new List<Image>();

        try
        {
            foreach (string jpegPath in inputPaths)
            {
                // Load JPEG image
                using (Image jpegImage = Image.Load(jpegPath))
                {
                    // Define BMP temporary file path
                    string bmpPath = Path.Combine(
                        tempBmpDir,
                        Path.GetFileNameWithoutExtension(jpegPath) + ".bmp");

                    // Save JPEG as BMP
                    jpegImage.Save(bmpPath, new BmpOptions());

                    // Load the BMP image and keep it for multipage creation
                    Image bmpImage = Image.Load(bmpPath);
                    bmpImages.Add(bmpImage);
                }
            }

            // Create a multipage image from the BMP images
            Image multipageImage = Image.Create(bmpImages.ToArray());

            // Save the multipage image as a PDF
            multipageImage.Save(outputPath, new PdfOptions());

            // Dispose the multipage image
            multipageImage.Dispose();
        }
        finally
        {
            // Dispose all BMP images
            foreach (var img in bmpImages)
            {
                img.Dispose();
            }

            // Optionally clean up temporary BMP files
            try
            {
                if (Directory.Exists(tempBmpDir))
                {
                    Directory.Delete(tempBmpDir, true);
                }
            }
            catch
            {
                // Suppress any cleanup errors
            }
        }
    }
}