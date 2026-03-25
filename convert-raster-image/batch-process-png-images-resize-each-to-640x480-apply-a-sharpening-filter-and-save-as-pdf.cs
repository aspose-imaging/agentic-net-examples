using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input PNG files and corresponding output PDF files
        string[] inputPaths = { "input1.png", "input2.png" };
        string[] outputPaths = { "output1.pdf", "output2.pdf" };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Resize to 640x480 using nearest neighbour resampling
                image.Resize(640, 480, ResizeType.NearestNeighbourResample);

                // Apply sharpening filter
                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                image.Filter(image.Bounds, sharpenOptions);

                // Save as PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}