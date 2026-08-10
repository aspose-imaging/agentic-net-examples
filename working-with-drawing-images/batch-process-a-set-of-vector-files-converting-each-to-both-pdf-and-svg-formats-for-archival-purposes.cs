// HOW-TO: Batch Convert Vector Files To PDF And SVG With Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories (relative to the current working directory)
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file paths for PDF and SVG
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string pdfOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                string svgOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                // Ensure directories for each output file exist
                Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                // Load the vector image
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    // Common vector rasterization options
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageSize = image.Size
                    };

                    // Save as PDF
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };
                    image.Save(pdfOutputPath, pdfOptions);

                    // Save as SVG
                    SvgOptions svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };
                    image.Save(svgOutputPath, svgOptions);
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
 * 1. When a company needs to archive a large collection of design assets, they can batch‑convert AI, EPS, or SVG drawings to PDF and SVG for long‑term storage using C# and Aspose.Imaging.
 * 2. When a web service must provide downloadable printable versions of user‑uploaded vector graphics, this code can automatically generate PDF and SVG files for each upload.
 * 3. When a migration project moves legacy vector files into a standardized document repository, developers can use the script to convert all files in a folder to PDF for viewing and SVG for editing.
 * 4. When an automated build pipeline has to include vector illustrations in both PDF reports and scalable web assets, the batch conversion ensures both formats are produced without manual steps.
 * 5. When a compliance system requires preserving the original appearance of vector diagrams while also offering a web‑friendly format, the code creates PDF for audit trails and SVG for browser rendering.
 */
