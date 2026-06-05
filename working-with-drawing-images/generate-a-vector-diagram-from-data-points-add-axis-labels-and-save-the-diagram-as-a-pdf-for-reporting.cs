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
            // Hardcoded input SVG path
            string inputPath = @"C:\Data\diagram.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output PDF path
            string outputPath = @"C:\Data\report.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read original SVG content
            string svgContent = File.ReadAllText(inputPath);

            // Define axis lines and labels as SVG elements
            string axesAndLabels = @"
  <line x1='50' y1='550' x2='750' y2='550' stroke='black' stroke-width='2'/>
  <line x1='50' y1='550' x2='50' y2='50' stroke='black' stroke-width='2'/>
  <text x='400' y='580' font-family='Arial' font-size='16' text-anchor='middle'>X Axis</text>
  <text x='20' y='300' font-family='Arial' font-size='16' text-anchor='middle' transform='rotate(-90 20,300)'>Y Axis</text>";

            // Insert the new elements before the closing </svg> tag
            string modifiedSvg = svgContent.Replace("</svg>", axesAndLabels + "\n</svg>");

            // Write the modified SVG to a temporary file
            string tempSvgPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.svg");
            File.WriteAllText(tempSvgPath, modifiedSvg);

            // Load the temporary SVG and save it as PDF
            using (Image image = Image.Load(tempSvgPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }

            // Optionally delete the temporary SVG file
            if (File.Exists(tempSvgPath))
            {
                File.Delete(tempSvgPath);
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
 * 1. When a financial analyst needs to convert a generated SVG chart of stock performance into a PDF report with labeled X and Y axes for distribution to stakeholders.
 * 2. When an engineering team wants to embed a vector diagram of a circuit layout into a PDF technical manual, adding axis labels automatically via C# and Aspose.Imaging.
 * 3. When a data‑science application produces SVG scatter plots that must be merged into a printable PDF summary, requiring on‑the‑fly insertion of axis lines and text.
 * 4. When a marketing automation script creates SVG infographics and needs to produce PDF assets with proper axis annotations for client presentations.
 * 5. When a compliance system archives SVG‑based process flow diagrams as searchable PDF files, adding axis labels to meet documentation standards using Aspose.Imaging for .NET.
 */