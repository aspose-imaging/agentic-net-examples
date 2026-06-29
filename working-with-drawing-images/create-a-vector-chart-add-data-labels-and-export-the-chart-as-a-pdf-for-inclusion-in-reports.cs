using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "chart.svg";
        string outputPath = "chart.pdf";

        // Create a simple SVG vector chart with data labels
        string svgContent = @"<svg width='500' height='300' xmlns='http://www.w3.org/2000/svg'>
  <rect x='50' y='200' width='80' height='80' fill='#4CAF50' />
  <text x='90' y='195' font-family='Arial' font-size='14' text-anchor='middle'>80</text>
  <rect x='150' y='150' width='80' height='130' fill='#2196F3' />
  <text x='190' y='145' font-family='Arial' font-size='14' text-anchor='middle'>130</text>
  <rect x='250' y='100' width='80' height='180' fill='#FF9800' />
  <text x='290' y='95' font-family='Arial' font-size='14' text-anchor='middle'>180</text>
  <rect x='350' y='50' width='80' height='230' fill='#9C27B0' />
  <text x='390' y='45' font-family='Arial' font-size='14' text-anchor='middle'>230</text>
  <line x1='40' y1='250' x2='460' y2='250' stroke='black' />
  <line x1='40' y1='250' x2='40' y2='20' stroke='black' />
</svg>";

        // Write SVG content to the input file
        File.WriteAllText(inputPath, svgContent);

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

            // Load the SVG vector image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Configure vector rasterization options for PDF conversion
                pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                // Save the vector image as PDF
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
 * 1. When a financial analyst needs to generate a sales bar chart in SVG, add data labels, and embed it as a PDF in a quarterly report using C# and Aspose.Imaging.
 * 2. When a marketing team wants to automate the creation of product performance graphics, convert them from vector SVG to PDF for inclusion in PowerPoint presentations.
 * 3. When an engineering dashboard requires dynamic generation of SVG schematics with measurement labels that are then saved as PDF files for archival documentation.
 * 4. When a SaaS platform must provide downloadable PDF invoices that contain vector charts of usage statistics generated from SVG templates.
 * 5. When a scientific research application needs to programmatically produce labeled SVG plots of experimental data and export them as high‑resolution PDF figures for journal submissions.
 */