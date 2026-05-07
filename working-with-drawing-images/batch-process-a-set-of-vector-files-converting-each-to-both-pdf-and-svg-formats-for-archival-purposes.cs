using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input, and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            // Ensure directories exist
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDir);

            foreach (var inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                // Convert to PDF
                string pdfOutputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    image.Save(pdfOutputPath, pdfOptions);
                }

                // Convert to SVG
                string svgOutputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                using (Image image = Image.Load(inputPath))
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageSize = image.Size
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