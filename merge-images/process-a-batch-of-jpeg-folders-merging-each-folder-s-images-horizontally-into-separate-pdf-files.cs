// HOW-TO: Merge JPEG Images in Each Folder Horizontally into PDF using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output root directories
        string inputRoot = @"C:\InputImages";
        string outputRoot = @"C:\OutputPdfs";

        try
        {
            // Process each subfolder in the input root
            foreach (string folderPath in Directory.GetDirectories(inputRoot))
            {
                // Get all JPEG files in the current folder
                string[] jpegFiles = Directory.GetFiles(folderPath, "*.jpg");

                if (jpegFiles.Length == 0)
                    continue; // Skip folders without JPEGs

                // Load each JPEG image
                List<Image> loadedImages = new List<Image>();
                foreach (string jpegPath in jpegFiles)
                {
                    if (!File.Exists(jpegPath))
                    {
                        Console.Error.WriteLine($"File not found: {jpegPath}");
                        continue;
                    }

                    Image img = Image.Load(jpegPath);
                    loadedImages.Add(img);
                }

                if (loadedImages.Count == 0)
                    continue; // No images successfully loaded

                // Create a single PDF containing all images (each image on its own page)
                PdfOptions pdfOptions = new PdfOptions();

                // Ensure the output directory exists
                string folderName = new DirectoryInfo(folderPath).Name;
                string outputPath = Path.Combine(outputRoot, folderName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Merge images horizontally into a single PDF page
                // (Aspose.Imaging merges the images side‑by‑side when using Image.Create with an array)
                using (Image merged = Image.Create(loadedImages.ToArray()))
                {
                    merged.Save(outputPath, pdfOptions);
                }

                // Dispose loaded images
                foreach (Image img in loadedImages)
                {
                    img.Dispose();
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
 * 1. When you need to automatically combine all photos from multiple product‑shoot folders into single landscape‑style PDFs for easy client review.
 * 2. When a digital archiving system must generate a PDF per event folder, placing each JPEG side‑by‑side on one page to preserve the original layout.
 * 3. When a reporting tool has to batch‑process scanned receipts stored in separate directories and output a consolidated PDF per day without manual intervention.
 * 4. When a marketing team wants to create printable catalogs by merging promotional JPEGs from each campaign folder into a single PDF page per campaign.
 * 5. When a document management workflow requires converting groups of JPEG screenshots into PDFs, keeping each group’s images aligned horizontally for consistent presentation.
 */
