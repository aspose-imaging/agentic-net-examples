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
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.djvu")
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
                            // Build output file name: <originalName>.<pageNumber>.png
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.{djvuPage.PageNumber}.png";
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
 * 1. When a document management system needs to quickly generate thumbnail PNG previews for up to fifty DjVu files stored on a server, this parallel batch conversion code can extract each page as an image.
 * 2. When a digital archiving workflow must convert scanned DjVu manuscripts into lossless PNG files for downstream OCR processing, the code provides a fast C# solution that handles multiple files concurrently.
 * 3. When a web application offers users the ability to download individual pages of a DjVu ebook as PNG images, developers can use this snippet to load the DjVu document and save each page in parallel.
 * 4. When a batch‑processing pipeline has to migrate legacy DjVu assets to a PNG‑based asset library while minimizing CPU time, the parallel loop in the example efficiently processes up to fifty files at once.
 * 5. When an automated reporting tool needs to extract visual charts from DjVu reports and store them as PNG files for inclusion in PowerPoint slides, this C# code automates the page‑by‑page conversion in a scalable way.
 */