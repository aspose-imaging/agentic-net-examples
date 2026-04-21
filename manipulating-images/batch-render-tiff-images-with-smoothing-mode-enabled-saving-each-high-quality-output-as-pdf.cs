using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input TIFF files
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.tif",
                @"C:\Images\Input2.tif"
            };

            // Corresponding output PDF files
            string[] outputPaths = new string[]
            {
                @"C:\Images\Output1.pdf",
                @"C:\Images\Output2.pdf"
            };

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

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF save options with high‑quality smoothing
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            // Enable anti‑aliasing for smoother rendering
                            SmoothingMode = SmoothingMode.AntiAlias,
                            // Set background to white (optional)
                            BackgroundColor = Color.White,
                            // Use original image dimensions for the PDF page
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };

                    // Save as PDF
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