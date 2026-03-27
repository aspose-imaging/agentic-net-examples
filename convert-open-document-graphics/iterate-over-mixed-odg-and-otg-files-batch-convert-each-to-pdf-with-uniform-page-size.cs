using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input and output directories (relative to current directory)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
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

        // Get all files from the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        // Uniform page size (A4 in points)
        var uniformPageSize = new SizeF(595f, 842f);

        foreach (string inputPath in files)
        {
            // Process only .odg and .otg files (case-insensitive)
            string extension = Path.GetExtension(inputPath).ToLowerInvariant();
            if (extension != ".odg" && extension != ".otg")
                continue;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output PDF path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Choose appropriate rasterization options based on file type
                VectorRasterizationOptions rasterOptions;
                if (extension == ".odg")
                {
                    var odgOptions = new OdgRasterizationOptions();
                    odgOptions.BackgroundColor = Color.White;
                    odgOptions.PageSize = uniformPageSize;
                    rasterOptions = odgOptions;
                }
                else // .otg
                {
                    var otgOptions = new OtgRasterizationOptions();
                    otgOptions.BackgroundColor = Color.White;
                    otgOptions.PageSize = uniformPageSize;
                    rasterOptions = otgOptions;
                }

                // Set up PDF save options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}