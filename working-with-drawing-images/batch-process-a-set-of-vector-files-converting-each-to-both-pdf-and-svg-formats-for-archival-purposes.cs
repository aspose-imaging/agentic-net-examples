using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; create if missing
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Derive output file names
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string pdfOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
            string svgOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

            // Ensure output directories exist (unconditional as per rules)
            Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // ---------- Convert to PDF ----------
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };
                image.Save(pdfOutputPath, pdfOptions);

                // ---------- Convert to SVG ----------
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };
                image.Save(svgOutputPath, svgOptions);
            }
        }
    }
}