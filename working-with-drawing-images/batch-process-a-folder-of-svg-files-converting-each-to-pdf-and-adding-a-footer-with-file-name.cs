using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputPdfs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each SVG file in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.svg"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Read original SVG content
                string svgContent = File.ReadAllText(inputPath, Encoding.UTF8);

                // Insert a footer text element with the file name before the closing </svg> tag
                int insertPos = svgContent.LastIndexOf("</svg>", StringComparison.OrdinalIgnoreCase);
                if (insertPos >= 0)
                {
                    // Simple footer positioned near the bottom; y-coordinate is set to 20 for demonstration.
                    // In a real scenario, you might calculate the height from viewBox or other attributes.
                    string footerText = $"<text x=\"10\" y=\"20\" font-size=\"12\" fill=\"black\">{fileNameWithoutExt}</text>";
                    svgContent = svgContent.Insert(insertPos, footerText);
                }

                // Load the modified SVG from a memory stream
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(svgContent)))
                using (Image image = Image.Load(ms))
                {
                    // Save as PDF using default PdfOptions
                    image.Save(outputPath, new PdfOptions());
                }
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
 * 1. When a developer needs to batch‑process a folder of SVG files, converting each to PDF with Aspose.Imaging for .NET and appending a footer that shows the original file name for traceability.
 * 2. When a marketing automation script must turn a collection of vector SVG logos into printable PDFs using C# and Aspose.Imaging, adding the logo’s filename as a footer to identify each asset.
 * 3. When an engineering workflow requires generating PDF schematics from SVG diagrams, using Aspose.Imaging to preserve vector quality while inserting the diagram’s filename as a footer for documentation standards.
 * 4. When a document management system automates the conversion of SVG illustrations to PDF format with Aspose.Imaging and adds a filename footer to support audit trails and searchable metadata.
 * 5. When a CI/CD pipeline validates that all SVG icons in a repository are correctly rendered as PDFs, employing Aspose.Imaging in C# to add a footer with the source file name for quality‑assurance reporting.
 */