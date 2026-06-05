using System;
using System.IO;
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

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine file name without extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);

                // Read original SVG content
                string svgContent = File.ReadAllText(inputPath);

                // Simple footer: add a <text> element before the closing </svg> tag
                // Position is approximate; adjust as needed for real use cases
                string footerText = $"<text x=\"10\" y=\"20\" font-size=\"12\" fill=\"black\">{fileName}</text>";
                string modifiedSvgContent = svgContent.Replace("</svg>", footerText + "\n</svg>");

                // Write modified SVG to a temporary file
                string tempSvgPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.svg");
                File.WriteAllText(tempSvgPath, modifiedSvgContent);

                // Load the modified SVG image
                using (Image image = Image.Load(tempSvgPath))
                {
                    // Prepare output PDF path
                    string outputPath = Path.Combine(outputFolder, $"{fileName}.pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PDF
                    image.Save(outputPath, new PdfOptions());
                }

                // Clean up temporary SVG file
                if (File.Exists(tempSvgPath))
                {
                    File.Delete(tempSvgPath);
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
 * 1. When a company needs to automatically convert a large collection of vector graphics (SVG) into printable PDFs while appending the original file name as a footer for traceability.
 * 2. When an e‑learning platform wants to generate downloadable PDF handouts from SVG lesson diagrams and include the diagram title at the bottom of each page.
 * 3. When a marketing team must archive campaign assets by batch‑processing SVG logos into PDF files that display the asset name as a reference footer.
 * 4. When a GIS application exports map SVG files to PDF reports and adds a footer with the map’s filename for easy identification in the final document.
 * 5. When a legal compliance system converts SVG schematics into PDF records and inserts the file name as a footer to satisfy audit‑trail requirements.
 */