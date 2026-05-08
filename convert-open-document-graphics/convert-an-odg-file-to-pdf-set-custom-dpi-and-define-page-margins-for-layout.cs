using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure rasterization options (margins, background, page size)
                Aspose.Imaging.ImageOptions.OdgRasterizationOptions rasterOptions = new Aspose.Imaging.ImageOptions.OdgRasterizationOptions();
                rasterOptions.BackgroundColor = Aspose.Imaging.Color.White;
                rasterOptions.BorderX = 20; // left/right margin in pixels
                rasterOptions.BorderY = 30; // top/bottom margin in pixels
                rasterOptions.PageSize = image.Size; // preserve original size

                // Configure PDF save options with custom DPI
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = rasterOptions;
                pdfOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300); // DPI X, DPI Y

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}