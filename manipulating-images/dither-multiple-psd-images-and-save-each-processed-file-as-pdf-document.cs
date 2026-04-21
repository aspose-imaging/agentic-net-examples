using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD files
            string[] inputPaths = new string[]
            {
                @"C:\Images\sample1.psd",
                @"C:\Images\sample2.psd",
                @"C:\Images\sample3.psd"
            };

            // Corresponding output PDF files
            string[] outputPaths = new string[]
            {
                @"C:\Processed\sample1.pdf",
                @"C:\Processed\sample2.pdf",
                @"C:\Processed\sample3.pdf"
            };

            // Process each file
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

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
                    // Cast to RasterImage for dithering
                    if (image is RasterImage rasterImage)
                    {
                        // Apply Floyd‑Steinberg dithering with 1‑bit palette
                        rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                    }

                    // Save as PDF using default options
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}