using System;
using System.IO;
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
            // Hardcoded list of DjVu files to process
            string[] inputFiles = new string[]
            {
                @"C:\Input\sample1.djvu",
                @"C:\Input\sample2.djvu"
                // Add more file paths as needed
            };

            // Output directory for PNG files
            string outputDirectory = @"C:\Output";

            // Process each DjVu file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu document
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                    {
                        // Iterate through each page of the DjVu document
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            // Build output file name: <originalname>_page<Number>.png
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.PageNumber}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

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
 * 1. When a developer needs to batch‑convert a collection of multi‑page DjVu documents into individual PNG images for web preview, using C# and Aspose.Imaging with Parallel.ForEach to speed up the process.
 * 2. When an archival system must extract each page of scanned DjVu files and store them as lossless PNG files for downstream OCR pipelines, leveraging parallel execution in .NET.
 * 3. When a digital publishing workflow requires converting large DjVu e‑books into PNG page assets for mobile apps, and the developer wants to process many files concurrently to reduce conversion time.
 * 4. When a document management solution has to generate thumbnail PNGs from every page of incoming DjVu uploads, using Aspose.Imaging's DjvuImage and parallel processing to handle high‑volume uploads.
 * 5. When a migration tool needs to transform legacy DjVu assets into PNG format for compatibility with modern image viewers, and the developer wants to automate the task across multiple files with C# parallel loops.
 */