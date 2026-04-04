using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input PSD files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.psd",
            @"C:\Images\image2.psd",
            @"C:\Images\image3.psd"
        };

        // Corresponding output PDF files
        string[] outputPaths = new string[]
        {
            @"C:\Output\image1.pdf",
            @"C:\Output\image2.pdf",
            @"C:\Output\image3.pdf"
        };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Perform dithering if the image is raster based
                if (image is RasterImage raster)
                {
                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                }

                // Save the processed image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}