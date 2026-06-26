using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Data\input.svg";
        string outputPath = @"C:\Data\output.pdf";
        string fontsFolder = @"C:\Data\fonts";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure Aspose.Imaging to use the custom fonts folder
            FontSettings.SetFontsFolder(fontsFolder);
            // Update internal font cache (required for some formats)
            FontSettings.UpdateFonts();

            // Load the vector image (SVG in this example)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options with vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        // Use white background, preserve original size
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        // High quality text rendering
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save as PDF; fonts from the specified folder will be embedded
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When converting customer‑provided SVG logos to PDF invoices, you embed the corporate fonts from a custom folder to guarantee the logo text appears exactly as designed.
 * 2. When generating printable PDF reports from SVG charts in a C# web service, you use FontSettings to embed the chart’s custom typefaces so the PDFs render correctly on any device.
 * 3. When automating batch conversion of SVG marketing assets to PDF brochures, you specify a fonts directory to ensure all promotional text retains its brand fonts without requiring the end‑user to install them.
 * 4. When creating PDF certificates from SVG templates that contain handwritten or script fonts, you embed those fonts during the Image.Save operation to avoid missing‑font warnings in PDF viewers.
 * 5. When developing a desktop application that exports SVG floor‑plans to PDF, you embed the architectural fonts stored locally so the floor‑plan annotations remain legible across different operating systems.
 */