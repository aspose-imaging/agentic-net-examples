using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input image files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.png",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.tif"
        };

        // Hard‑coded output PDF files (one per input)
        string[] outputPaths = new string[]
        {
            @"C:\Output\image1.pdf",
            @"C:\Output\image2.pdf",
            @"C:\Output\image3.pdf"
        };

        // Ensure each input file exists before processing
        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Process images concurrently
        Parallel.ForEach(
            // Pair each input with its corresponding output
            new List<(string input, string output)>() {
                (inputPaths[0], outputPaths[0]),
                (inputPaths[1], outputPaths[1]),
                (inputPaths[2], outputPaths[2])
            },
            pair =>
            {
                // Create output directory unconditionally
                Directory.CreateDirectory(Path.GetDirectoryName(pair.output));

                // Load the raster image
                using (Image image = Image.Load(pair.input))
                {
                    RasterImage raster = (RasterImage)image;

                    // Apply a median filter of size 5 to the whole image
                    raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save to a memory stream (simulating streaming to a client)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        raster.Save(ms, pdfOptions);
                        // At this point, ms contains the PDF data.
                        // In a real server scenario, you would write ms to the HTTP response.
                    }

                    // Also save to a file for demonstration purposes
                    raster.Save(pair.output, pdfOptions);
                }
            });
    }
}