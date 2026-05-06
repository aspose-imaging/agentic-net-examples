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
            // Input EMF files (hardcoded relative paths)
            string[] inputFiles = new[]
            {
                "Input/file1.emf",
                "Input/file2.emf",
                "Input/file3.emf"
            };

            // Output PDF file (hardcoded relative path)
            string outputPath = "Output/merged.pdf";

            // Validate input files
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare vector rasterization options for each page
            VectorRasterizationOptions[] pageOptions = new VectorRasterizationOptions[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                using (Image img = Image.Load(inputFiles[i]))
                {
                    pageOptions[i] = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = img.Size
                    };
                }
            }

            // Load the first EMF to act as the source image for saving
            using (Image firstImage = Image.Load(inputFiles[0]))
            {
                // Configure PDF options with multipage settings
                PdfOptions pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new MultiPageOptions { PageRasterizationOptions = pageOptions },
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = firstImage.Size
                    }
                };

                // Save all EMF pages into a single PDF
                firstImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}