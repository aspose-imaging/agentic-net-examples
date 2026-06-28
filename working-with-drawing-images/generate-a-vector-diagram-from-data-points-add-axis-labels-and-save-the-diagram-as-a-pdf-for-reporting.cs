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
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\diagram.svg";
            string outputPath = @"C:\Temp\diagram.pdf";

            // Ensure the directory for the input file exists and write SVG content
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
            string svgContent = GenerateSvgDiagram();
            File.WriteAllText(inputPath, svgContent, Encoding.UTF8);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG as an Aspose.Imaging image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Generates a simple SVG diagram with data points, axes, and labels
    static string GenerateSvgDiagram()
    {
        // Example data points
        var points = new (double X, double Y)[]
        {
            (10, 80), (30, 60), (50, 70), (70, 40), (90, 50)
        };

        // SVG canvas size
        int width = 200;
        int height = 200;
        int margin = 20;

        var sb = new StringBuilder();
        sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"{height}\">");

        // Draw axes
        sb.AppendLine($"  <line x1=\"{margin}\" y1=\"{height - margin}\" x2=\"{width - margin}\" y2=\"{height - margin}\" stroke=\"black\"/>"); // X axis
        sb.AppendLine($"  <line x1=\"{margin}\" y1=\"{margin}\" x2=\"{margin}\" y2=\"{height - margin}\" stroke=\"black\"/>"); // Y axis

        // Axis labels
        sb.AppendLine($"  <text x=\"{width / 2}\" y=\"{height - 5}\" font-size=\"12\" text-anchor=\"middle\">X Axis</text>");
        sb.AppendLine($"  <text x=\"5\" y=\"{height / 2}\" font-size=\"12\" transform=\"rotate(-90 5,{height / 2})\" text-anchor=\"middle\">Y Axis</text>");

        // Plot points and connect them with lines
        sb.AppendLine("  <polyline fill=\"none\" stroke=\"blue\" stroke-width=\"2\" points=\"");
        foreach (var p in points)
        {
            // Transform data coordinates to SVG coordinates
            double svgX = margin + p.X * (width - 2 * margin) / 100.0;
            double svgY = height - margin - p.Y * (height - 2 * margin) / 100.0;
            sb.Append($"{svgX},{svgY} ");
        }
        sb.AppendLine("\">");
        sb.AppendLine("  </polyline>");

        // Draw individual points
        foreach (var p in points)
        {
            double svgX = margin + p.X * (width - 2 * margin) / 100.0;
            double svgY = height - margin - p.Y * (height - 2 * margin) / 100.0;
            sb.AppendLine($"  <circle cx=\"{svgX}\" cy=\"{svgY}\" r=\"3\" fill=\"red\"/>");
        }

        sb.AppendLine("</svg>");
        return sb.ToString();
    }
}

/*
 * Real-World Use Cases:
 * 1. When a financial analyst needs to generate a vector chart of stock price trends from raw data points, embed axis labels, and export it as a PDF for inclusion in quarterly reports using C# and Aspose.Imaging.
 * 2. When a manufacturing engineer wants to visualize sensor measurements on a calibrated graph, create an SVG diagram with labeled axes, and automatically convert it to a PDF for quality‑control documentation.
 * 3. When a healthcare application must produce patient vital‑sign charts from numeric readings, add descriptive axis titles, and save the result as a PDF for electronic medical records using Aspose.Imaging for .NET.
 * 4. When a marketing team requires a scalable infographic of campaign performance metrics, generate the SVG plot with data points and axis labels in C#, then convert it to a PDF for printable presentations.
 * 5. When an academic researcher needs to programmatically create a scientific plot of experimental data, label the axes, and distribute the figure as a PDF in a research paper, this code provides a straightforward solution.
 */