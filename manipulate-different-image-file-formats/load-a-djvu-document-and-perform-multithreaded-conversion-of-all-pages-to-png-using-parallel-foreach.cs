using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Parallel conversion of each page to PNG
                Parallel.ForEach(
                    Enumerable.Range(0, djvuImage.PageCount),
                    pageIndex =>
                    {
                        // Retrieve the page
                        DjvuPage djvuPage = (DjvuPage)djvuImage.Pages[pageIndex];

                        // Construct output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG
                        djvuPage.Save(outputPath, new PngOptions());
                    });
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
 * 1. When a document management system must quickly generate preview thumbnails for every page of a multi‑page DjVu file, a developer can use this code to load the DjVu document and convert each page to PNG in parallel.
 * 2. When a web application needs to serve high‑resolution PNG images of scanned books stored as DjVu, the parallel conversion reduces processing time and improves responsiveness.
 * 3. When a batch‑processing pipeline has to archive DjVu archives as lossless PNG images for compliance or backup, this code enables multithreaded page‑by‑page conversion.
 * 4. When an e‑learning platform wants to extract individual lesson slides from a DjVu presentation and store them as PNG files for offline viewing, the code provides a fast, thread‑safe solution.
 * 5. When a digital forensics tool must render every page of a DjVu evidence file as PNG for analysis while minimizing CPU idle time, the Parallel.ForEach approach accelerates the conversion.
 */