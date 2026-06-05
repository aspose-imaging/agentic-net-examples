using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputDir = @"C:\Temp\PdfOutput";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (Directory.CreateDirectory handles null safely)
            Directory.CreateDirectory(outputDir);

            // Set memory optimization options (e.g., limit internal buffers to 1 MB)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB
            };

            // Load DjVu document using a file stream and the load options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
            {
                // Iterate through each page and save it as a separate PDF file
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Construct output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.pdf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PDF using PdfOptions
                    page.Save(outputPath, new PdfOptions());
                }
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
 * 1. When a developer needs to batch‑convert a multi‑page DjVu archive into individual PDF files while keeping memory usage low, they can use this code.
 * 2. When an application must process large scanned documents stored as DjVu and generate searchable PDFs without loading the entire file into RAM, the memory‑optimized load options are ideal.
 * 3. When a document‑management system requires extracting each page of a DjVu file to separate PDF pages for indexing or preview, this snippet provides a straightforward C# solution.
 * 4. When a cloud service processes user‑uploaded DjVu files and must store each page as a PDF in a specific output folder while preventing out‑of‑memory errors, the code demonstrates the needed workflow.
 * 5. When a legacy workflow needs to migrate old DjVu manuals to PDF format for compliance or archival purposes, developers can employ this example to automate the conversion page by page.
 */