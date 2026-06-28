using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure directories exist
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add CMX files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all CMX files in the input directory
            string[] cmxFiles = Directory.GetFiles(inputDirectory, "*.cmx");

            // Process each file in parallel
            Parallel.ForEach(cmxFiles, inputPath =>
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CMX image and convert to PDF
                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };

                        image.Save(outputPath, pdfOptions);
                    }
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a printing company needs to quickly convert a large collection of legacy CorelDRAW CMX artwork files into PDF for client delivery, they can use this parallel batch conversion code.
 * 2. When an automated document management system must ingest CMX drawings from a shared folder and generate searchable PDF archives without blocking other processes, the code enables concurrent processing.
 * 3. When a cloud‑based design review platform wants to transform user‑uploaded CMX files into PDF thumbnails for preview generation while maintaining high throughput, this parallel conversion approach is ideal.
 * 4. When a legal firm receives batches of CMX‑based technical schematics and must produce PDF evidence files for e‑discovery, the multithreaded conversion ensures timely completion.
 * 5. When a CI/CD pipeline includes a step to validate that all CMX assets in a repository can be rendered as PDF before release, the code provides a fast, parallel verification method.
 */