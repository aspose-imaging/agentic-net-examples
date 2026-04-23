using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.bmp");
        string outputPath = Path.Combine("Output", "filtered.pdf");

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP, apply median filter
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

            // Prepare PDF page size (A4 in points)
            int pageWidth = 595;   // width
            int pageHeight = 842;  // height

            // Create a blank canvas
            PngOptions canvasOptions = new PngOptions();
            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(canvasOptions, pageWidth, pageHeight))
            {
                // Fill canvas with white background
                int whiteArgb = Aspose.Imaging.Color.White.ToArgb();
                int[] whitePixels = new int[pageWidth * pageHeight];
                for (int i = 0; i < whitePixels.Length; i++) whitePixels[i] = whiteArgb;
                canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, pageWidth, pageHeight), whitePixels);

                // Calculate centered position
                int offsetX = (pageWidth - raster.Width) / 2;
                int offsetY = (pageHeight - raster.Height) / 2;

                // Draw filtered image onto canvas
                canvas.SaveArgb32Pixels(
                    new Aspose.Imaging.Rectangle(offsetX, offsetY, raster.Width, raster.Height),
                    raster.LoadArgb32Pixels(raster.Bounds));

                // Save canvas as PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }
        }
    }
}