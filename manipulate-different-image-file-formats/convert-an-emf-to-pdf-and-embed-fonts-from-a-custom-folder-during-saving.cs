using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.pdf";
            string customFontsFolder = @"C:\CustomFonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Preserve original font folders to restore later
            string[] originalFontFolders = FontSettings.GetFontsFolders();

            // Point Aspose.Imaging to the custom fonts folder
            FontSettings.SetFontsFolder(customFontsFolder);

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options with vector rasterization so fonts are embedded
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        // Optional: improve text rendering quality
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                    }
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }

            // Restore original font folders
            FontSettings.SetFontsFolders(originalFontFolders, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}