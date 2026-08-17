// HOW-TO: Apply Custom Dashed Border to SVG and Export as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output/output.pdf";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector drawing
            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                // Create a PDF canvas with the same dimensions
                PdfOptions pdfOptions = new PdfOptions();
                using (Image pdfImage = Image.Create(pdfOptions, width, height))
                {
                    // Obtain graphics object for drawing
                    Graphics graphics = new Graphics(pdfImage);
                    graphics.Clear(Color.White);

                    // Render the loaded vector image onto the PDF canvas
                    graphics.DrawImage(vectorImage, new Rectangle(0, 0, width, height));

                    // Create a pen with a custom dash pattern
                    Pen dashPen = new Pen(Color.Black, 2);
                    dashPen.DashPattern = new float[] { 5f, 2f, 1f, 2f }; // dash, space, dash, space

                    // Draw a rectangle border using the custom dashed pen
                    graphics.DrawRectangle(dashPen, new Rectangle(0, 0, width - 1, height - 1));

                    // Save the styled PDF
                    pdfImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a printable PDF from an SVG diagram and highlight its edges with a custom dashed border.
 * 2. When you want to programmatically add a stylized rectangle around a vector logo before embedding it in a PDF report.
 * 3. When a web service must convert user‑uploaded SVG files to PDF while applying brand‑specific dash patterns to the artwork.
 * 4. When automating batch processing of engineering drawings, you require a consistent dashed frame around each PDF output for visual reference.
 * 5. When creating PDF invoices that include scalable SVG icons with a custom dash style to match corporate design guidelines.
 */
