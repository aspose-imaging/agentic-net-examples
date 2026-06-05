using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                raster.Filter(raster.Bounds, filterOptions);

                raster.Save(outputPath);
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
 * 1. When a developer needs to detect horizontal edges in a PNG photograph to highlight road markings for an autonomous‑vehicle training dataset, they can use this Aspose.Imaging C# code to apply a Sobel 3×3 convolution filter.
 * 2. When building a document‑scanning application that must enhance the contrast of text lines in scanned PDFs saved as PNG, the code can be used to perform horizontal edge detection before OCR.
 * 3. When creating a medical‑imaging tool that isolates bone structures in X‑ray images stored as PNG, the Sobel filter helps extract horizontal gradients for further analysis.
 * 4. When developing a security‑camera system that flags motion across a fence, the developer can run this convolution on each frame to emphasize horizontal edges and reduce false positives.
 * 5. When preparing product‑catalog images for an e‑commerce site, the code can be employed to generate edge maps that assist in automatic background removal by detecting horizontal boundaries.
 */