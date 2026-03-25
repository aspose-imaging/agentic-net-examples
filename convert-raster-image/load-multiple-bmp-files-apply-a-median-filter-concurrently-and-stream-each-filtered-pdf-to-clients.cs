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
        // Hard‑coded input BMP files
        var inputPaths = new List<string>
        {
            @"C:\temp\image1.bmp",
            @"C:\temp\image2.bmp",
            @"C:\temp\image3.bmp"
        };

        // Process each file concurrently
        Parallel.ForEach(inputPaths, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Derive output PDF path (same folder, same name, .pdf extension)
            string outputPath = Path.ChangeExtension(inputPath, ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filter
                RasterImage rasterImage = (RasterImage)image;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Save filtered image to a memory stream as PDF
                using (var pdfStream = new MemoryStream())
                {
                    image.Save(pdfStream, pdfOptions);
                    pdfStream.Position = 0; // Reset for reading

                    // Simulate streaming to a client by writing the stream to the output file
                    using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        pdfStream.CopyTo(fileStream);
                    }
                }
            }
        });
    }
}