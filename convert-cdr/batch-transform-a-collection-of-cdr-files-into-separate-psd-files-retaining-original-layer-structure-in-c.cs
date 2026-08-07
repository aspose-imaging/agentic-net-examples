using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Set up input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all CDR files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output PSD path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".psd");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PSD options
                    var psdOptions = new PsdOptions();

                    // Preserve each page as a separate layer
                    if (image is IMultipageImage multipageImage)
                    {
                        psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipageImage.PageCount));
                    }

                    // Set vector rasterization options to retain vector layers
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Save as PSD
                    image.Save(outputPath, psdOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a graphic design studio needs to migrate a library of CorelDRAW (.cdr) assets to Photoshop (.psd) format while keeping each page as an individual layer for further editing.
 * 2. When an e‑learning platform automates the conversion of multi‑page CDR illustrations into layered PSD files to integrate them into interactive course modules.
 * 3. When a printing company processes client‑submitted CDR artwork in bulk and generates PSD files with preserved layers for color‑proofing and pre‑press adjustments.
 * 4. When a marketing team builds a C# tool that nightly converts newly added CDR brand assets into PSDs so designers can instantly open them in Adobe Photoshop with the original layer hierarchy intact.
 * 5. When a software vendor creates a migration utility that scans a folder of legacy CDR files and outputs corresponding PSD files, ensuring each vector page becomes a separate Photoshop layer for seamless integration into modern design workflows.
 */