using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputDjvu";
        string outputDirectory = @"C:\OutputPng";

        try
        {
            // Get up to 50 DjVu files from the input directory
            var inputFiles = Directory.GetFiles(inputDirectory, "*.djvu")
                                      .Take(50)
                                      .ToArray();

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load the DjVu document
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                    {
                        // Iterate through each page and save as PNG
                        foreach (DjvuPage djvuPage in djvuImage.Pages)
                        {
                            // Build output file name: original name + page number
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{djvuPage.PageNumber}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            djvuPage.Save(outputPath, new PngOptions());
                        }
                    }
                }
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
 * 1. When a publishing company needs to quickly convert up to fifty scanned DjVu documents into high‑resolution PNG images for web preview, they can use this C# parallel batch conversion code.
 * 2. When a legal firm wants to extract each page of multiple DjVu case files and store them as separate PNG files for inclusion in an e‑discovery system, this code provides an automated solution.
 * 3. When a digital archiving service must process a large batch of DjVu blueprints and generate PNG thumbnails for a searchable catalog, the parallel loop speeds up the conversion.
 * 4. When a software vendor integrates Aspose.Imaging into a C# application to transform DjVu manuals into PNG assets for mobile apps, this example shows how to handle up to fifty files concurrently.
 * 5. When an educational platform needs to pre‑render DjVu lecture notes as PNG pages for offline viewing on tablets, the code demonstrates efficient batch processing with file‑system checks.
 */