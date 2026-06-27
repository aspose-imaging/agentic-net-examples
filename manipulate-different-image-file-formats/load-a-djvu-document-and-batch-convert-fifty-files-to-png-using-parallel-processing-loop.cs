using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\DjvuInput";
            string outputDir = @"C:\PngOutput";

            // Prepare list of 50 DjVu files (input0.djvu … input49.djvu)
            var inputFiles = new List<string>();
            for (int i = 0; i < 50; i++)
            {
                inputFiles.Add(Path.Combine(inputDir, $"input{i}.djvu"));
            }

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DjVu document from a file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        // Save each page as a separate PNG file
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            string baseName = Path.GetFileNameWithoutExtension(inputPath);
                            string outputPath = Path.Combine(outputDir, $"{baseName}_page{page.PageNumber}.png");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            page.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to migrate a large archive of scanned DjVu technical manuals into high‑resolution PNG images for web publishing, they can use this parallel batch conversion code.
 * 2. When an automated document‑processing pipeline must extract every page of multiple DjVu e‑books and store them as PNG thumbnails for a digital library catalog, this example shows how to do it efficiently in C#.
 * 3. When a cloud‑based service has to convert fifty DjVu files uploaded by users into PNG format for downstream OCR or image analysis, the parallel loop speeds up the workload.
 * 4. When a legacy system stores engineering drawings in DjVu and a new application requires PNG assets for integration with a reporting tool, the code demonstrates batch loading and page‑wise saving.
 * 5. When a DevOps script needs to validate the integrity of DjVu files by rendering each page to PNG and checking the output files, this parallel processing approach provides a fast, automated solution.
 */