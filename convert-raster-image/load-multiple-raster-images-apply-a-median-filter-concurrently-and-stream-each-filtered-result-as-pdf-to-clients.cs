using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input image file paths
            var inputPaths = new List<string>
            {
                @"C:\Images\input1.png",
                @"C:\Images\input2.jpg",
                @"C:\Images\input3.bmp"
            };

            // Corresponding output PDF file paths
            var outputPaths = new List<string>
            {
                @"C:\Output\output1.pdf",
                @"C:\Output\output2.pdf",
                @"C:\Output\output3.pdf"
            };

            // Validate that each input file exists
            for (int i = 0; i < inputPaths.Count; i++)
            {
                string inputPath = inputPaths[i];
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directories exist
            foreach (var outputPath in outputPaths)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            }

            // Process images concurrently
            Parallel.ForEach(
                Enumerable.Range(0, inputPaths.Count),
                index =>
                {
                    string inputPath = inputPaths[index];
                    string outputPath = outputPaths[index];

                    // Load the raster image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Cast to RasterImage to apply filters
                        RasterImage rasterImage = (RasterImage)image;

                        // Apply median filter with size 5 to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                        // Prepare PDF save options
                        var pdfOptions = new PdfOptions();

                        // Save the filtered image as PDF to the output path
                        rasterImage.Save(outputPath, pdfOptions);
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
 * 1. When a web service needs to batch‑process user‑uploaded photos (PNG, JPG, BMP) to remove noise with a median filter and instantly return each cleaned image as a PDF document.
 * 2. When an e‑commerce platform wants to generate printable product catalogs by converting high‑resolution product images into PDF pages after applying a median filter to improve visual consistency.
 * 3. When a medical imaging application must quickly de‑noise multiple DICOM‑derived raster scans in parallel and stream the filtered results as PDFs to clinicians for review.
 * 4. When a digital archiving system has to ingest large collections of scanned documents, apply a median filter to reduce scanning artifacts, and deliver the cleaned pages as searchable PDF files via an API.
 * 5. When a mobile backend processes batches of user‑submitted screenshots, applies a median filter concurrently to enhance readability, and streams each result as a PDF attachment to email or messaging services.
 */